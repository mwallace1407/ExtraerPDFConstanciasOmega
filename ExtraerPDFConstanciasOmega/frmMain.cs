using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ExtraerPDFConstanciasOmega
{
    public partial class frmMain : Form
    {
        private ResultadoStored_DT ResDT;
        int Anno = 0;
        string Ruta = string.Empty;
        DateTime Inicio;
        double TiempoRestante = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void ProcesarArchivo(string Ruta, byte[] Datos, string MsjError, int Numero_Prestamo, int Anno, string Tipo)
        {
            try
            {
                if (MsjError == "")
                {
                    string Archivo = Path.Combine(Ruta, "Const_" + Numero_Prestamo.ToString() + "_" + Anno.ToString() + "_" + Tipo + ".pdf");
                    System.IO.BinaryWriter binWriter = new System.IO.BinaryWriter(System.IO.File.Open(Archivo, System.IO.FileMode.CreateNew, System.IO.FileAccess.ReadWrite));

                    binWriter.Write(Datos);
                    binWriter.Close();
                    clsBD.RegistrarLog(Numero_Prestamo, Anno, Tipo, "Success", MsjError);
                    clsBD.RegistrarArchivo(Anno, Numero_Prestamo, Tipo, "Const_" + Numero_Prestamo.ToString() + "_" + Anno.ToString() + "_" + Tipo + ".pdf");
                }
                else
                {
                    clsBD.RegistrarLog(Numero_Prestamo, Anno, Tipo, "Warning", MsjError);
                }
            }
            catch (Exception ex)
            {
                clsBD.RegistrarLog(Numero_Prestamo, Anno, Tipo, "Error", ex.Message);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            fbd01.ShowDialog();

            if (Directory.Exists(fbd01.SelectedPath))
            {
                Anno = Convert.ToInt32(numAnno.Value);
                ResDT = clsBD.ObtenerListadoPrestamos(Anno);
                Ruta = fbd01.SelectedPath;

                btnFolder.Enabled = false;
                numAnno.Enabled = false;
                MessageBox.Show("Espere a que finalice el proceso de los " + ResDT.Resultado.Rows.Count.ToString() + " préstamos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Inicio = DateTime.Now;
                wkr01.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("El directorio no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void wkr01_DoWork(object sender, DoWorkEventArgs e)
        {
            WS_PDF.GenerarSoapClient wsGenerarPDF = new WS_PDF.GenerarSoapClient();
            WS_PDF.Archivo archivoPDF;

            for (int w = 0; w < ResDT.Resultado.Rows.Count; w++)
            {
                int Numero_Prestamo;

                int.TryParse(ResDT.Resultado.Rows[w][0].ToString(), out Numero_Prestamo);
                archivoPDF = wsGenerarPDF.GenerarPDF(Numero_Prestamo, WS_PDF.TipoPDF.Acreditado, Anno, 100, "1", true);
                ProcesarArchivo(Ruta, archivoPDF.Datos, archivoPDF.MsjError, Numero_Prestamo, Anno, "A");

                if (clsBD.TieneCoacreditado(Numero_Prestamo))
                {
                    archivoPDF = wsGenerarPDF.GenerarPDF(Numero_Prestamo, WS_PDF.TipoPDF.Coacreditado, Anno, 100, "1", true);
                    ProcesarArchivo(Ruta, archivoPDF.Datos, archivoPDF.MsjError, Numero_Prestamo, Anno, "C");
                }

                try
                {
                    int percentage = (w + 1) * 100 / ResDT.Resultado.Rows.Count;
                    wkr01.ReportProgress(percentage);

                    TimeSpan t = DateTime.Now - Inicio;
                    TiempoRestante = ((ResDT.Resultado.Rows.Count - w) * t.TotalSeconds) / w;
                }
                catch { }
            }
        }

        private void wkr01_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb01.Value = e.ProgressPercentage;

            try
            {
                TimeSpan t = DateTime.Now - Inicio;
                clsBD.RegistrarAvance(DateTime.Now.AddSeconds(TiempoRestante), e.ProgressPercentage, Convert.ToInt32(t.TotalMinutes));
            }
            catch { }
        }

        private void wkr01_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TimeSpan t = DateTime.Now - Inicio;
            MessageBox.Show("Proceso finalizado\n" + t.Days + "d " + t.Hours + "h " + t.Minutes + "m ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnFolder.Enabled = true;
            numAnno.Enabled = true;
        }
    }
}
