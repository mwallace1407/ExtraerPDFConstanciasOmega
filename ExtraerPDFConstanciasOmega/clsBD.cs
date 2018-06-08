using System;
using System.Data;
using System.Data.SqlClient;

namespace ExtraerPDFConstanciasOmega
{
    public class clsBD
    {
        private const string Cnx = "Data Source=hdatacenter1;Initial Catalog=BD_DWH_ODS;User Id=usr_omega;Password=Casita12;";
        private const string QueryListado = "SELECT TPCP_NumeroPrestamo FROM TemporalProcesoConstancias_ListaPrestamos WHERE TPCP_Anno = @TPCP_Anno";
        private const string QueryLog = "INSERT INTO TemporalProcesoConstancias_Log VALUES (GETDATE(), @TPCL_NumeroPrestamo, @TPCL_Anno, @TPCL_TipoCliente, @TPCL_Estado, @TPCL_Mensaje)";
        private const string QueryArchivo = "INSERT INTO ProcesoConstancias_Datos VALUES (@PCD_Anno, @PCD_NumeroPrestamo, @PCD_TipoCliente, @PCD_NombreArchivo)";
        private const string QueryTieneCoa = "SELECT Nombre_Completo FROM AbT_Mg_Clientes WHERE Codigo_Cliente = (SELECT Codigo_Cliente FROM AbT_Pr_Contratos_X_Cliente Cxc WHERE Cxc.Numero_Contrato = @Numero_Prestamo AND Cxc.Clase_De_Cliente = 'C')";
        private const string QueryAvance = "UPDATE TemporalProcesoConstancias_AvanceActual SET TPCProc_FechaEstimada = @FechaEstimada, TPCProc_PorcentajeAvance = @PorcentajeAvance, TPCProc_FechaActual = GETDATE(), TPCProc_TiempoTranscurridoMin = @TiempoTranscurrido";

        public static ResultadoStored_DT ObtenerListadoPrestamos(int TPCP_Anno, bool DevolverError = true, int TimeOut = 0)
        {
            ResultadoStored_DT Resultado = new ResultadoStored_DT(new DataTable("Resultado"), string.Empty, false);
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param = null;

            try
            {
                cn = new SqlConnection(Cnx);
                cmd = new SqlCommand(QueryListado, cn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@TPCP_Anno", SqlDbType.Int);
                param.Value = TPCP_Anno;
                cmd.Parameters.Add(param);

                cn.Open();

                if (TimeOut > 0)
                    cmd.CommandTimeout = TimeOut;

                Resultado.Resultado.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
            }
            catch (Exception ex)
            {
                Resultado.HayError = true;
                Resultado.Resultado = new DataTable("Error");

                if (DevolverError)
                    Resultado.Error = "Error: " + ex.Message;
                else
                    Resultado.Error = string.Empty;
            }

            return Resultado;
        }

        public static ResultadoStored_Str RegistrarLog(int TPCL_NumeroPrestamo, int TPCL_Anno, string TPCL_TipoCliente, string TPCL_Estado, string TPCL_Mensaje, bool DevolverError = true, int TimeOut = 0)
        {
            ResultadoStored_Str Resultado = new ResultadoStored_Str(string.Empty, string.Empty, false);
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param = null;

            try
            {
                cn = new SqlConnection(Cnx);
                cmd = new SqlCommand(QueryLog, cn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@TPCL_NumeroPrestamo", SqlDbType.Int);
                param.Value = TPCL_NumeroPrestamo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TPCL_Anno", SqlDbType.Int);
                param.Value = TPCL_Anno;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TPCL_TipoCliente", SqlDbType.VarChar);
                param.Value = TPCL_TipoCliente;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TPCL_Estado", SqlDbType.VarChar);
                param.Value = TPCL_Estado;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TPCL_Mensaje", SqlDbType.VarChar);
                param.Value = TPCL_Mensaje;
                cmd.Parameters.Add(param);

                cn.Open();

                if (TimeOut > 0)
                    cmd.CommandTimeout = TimeOut;

                cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Resultado.Resultado = "OK";
            }
            catch (Exception ex)
            {
                Resultado.HayError = true;
                Resultado.Resultado = string.Empty;

                if (DevolverError)
                    Resultado.Error = "Error: " + ex.Message;
                else
                    Resultado.Error = string.Empty;
            }

            return Resultado;
        }

        public static ResultadoStored_Str RegistrarArchivo(int PCD_Anno, int PCD_NumeroPrestamo, string PCD_TipoCliente, string PCD_NombreArchivo, bool DevolverError = true, int TimeOut = 0)
        {
            ResultadoStored_Str Resultado = new ResultadoStored_Str(string.Empty, string.Empty, false);
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param = null;

            try
            {
                cn = new SqlConnection(Cnx);
                cmd = new SqlCommand(QueryArchivo, cn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@PCD_Anno", SqlDbType.Int);
                param.Value = PCD_Anno;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PCD_NumeroPrestamo", SqlDbType.Int);
                param.Value = PCD_NumeroPrestamo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PCD_TipoCliente", SqlDbType.VarChar);
                param.Value = PCD_TipoCliente;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PCD_NombreArchivo", SqlDbType.VarChar);
                param.Value = PCD_NombreArchivo;
                cmd.Parameters.Add(param);

                cn.Open();

                if (TimeOut > 0)
                    cmd.CommandTimeout = TimeOut;

                cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Resultado.Resultado = "OK";
            }
            catch (Exception ex)
            {
                Resultado.HayError = true;
                Resultado.Resultado = string.Empty;

                if (DevolverError)
                    Resultado.Error = "Error: " + ex.Message;
                else
                    Resultado.Error = string.Empty;
            }

            return Resultado;
        }

        public static bool TieneCoacreditado(int Numero_Prestamo, bool DevolverError = true, int TimeOut = 0)
        {
            bool Resultado = false;
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param = null;
            DataTable Res = new DataTable();

            try
            {
                cn = new SqlConnection(Cnx);
                cmd = new SqlCommand(QueryTieneCoa, cn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@Numero_Prestamo", SqlDbType.Int);
                param.Value = Numero_Prestamo;
                cmd.Parameters.Add(param);

                cn.Open();

                if (TimeOut > 0)
                    cmd.CommandTimeout = TimeOut;

                Res.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));

                if (Res.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Res.Rows[0][0].ToString()))
                        Resultado = true;
                }
            }
            catch
            {
                Resultado = false;
            }

            return Resultado;
        }

        public static ResultadoStored_Str RegistrarAvance(DateTime FechaEstimada, int PorcentajeAvance, int TiempoTranscurrido, bool DevolverError = true, int TimeOut = 0)
        {
            ResultadoStored_Str Resultado = new ResultadoStored_Str(string.Empty, string.Empty, false);
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param = null;

            try
            {
                cn = new SqlConnection(Cnx);
                cmd = new SqlCommand(QueryAvance, cn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@FechaEstimada", SqlDbType.DateTime);
                param.Value = FechaEstimada;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PorcentajeAvance", SqlDbType.Int);
                param.Value = PorcentajeAvance;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TiempoTranscurrido", SqlDbType.Int);
                param.Value = TiempoTranscurrido;
                cmd.Parameters.Add(param);

                cn.Open();

                if (TimeOut > 0)
                    cmd.CommandTimeout = TimeOut;

                cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Resultado.Resultado = "OK";
            }
            catch (Exception ex)
            {
                Resultado.HayError = true;
                Resultado.Resultado = string.Empty;

                if (DevolverError)
                    Resultado.Error = "Error: " + ex.Message;
                else
                    Resultado.Error = string.Empty;
            }

            return Resultado;
        }
    }

    public struct ResultadoStored_Str
    {
        public string Resultado;
        public string Error;
        public bool HayError;

        public ResultadoStored_Str(string vResultado, string vError, bool vHayError)
        {
            Resultado = vResultado;
            Error = vError;
            HayError = vHayError;
        }
    }

    public struct ResultadoStored_DT
    {
        public DataTable Resultado;
        public string Error;
        public bool HayError;

        public ResultadoStored_DT(DataTable vResultado, string vError, bool vHayError)
        {
            Resultado = vResultado;
            Error = vError;
            HayError = vHayError;
        }
    }
}