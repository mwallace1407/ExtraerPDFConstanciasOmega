namespace ExtraerPDFConstanciasOmega
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numAnno = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.pb01 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.wkr01 = new System.ComponentModel.BackgroundWorker();
            this.fbd01 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numAnno)).BeginInit();
            this.SuspendLayout();
            // 
            // numAnno
            // 
            this.numAnno.Location = new System.Drawing.Point(35, 28);
            this.numAnno.Maximum = new decimal(new int[] {
            2012,
            0,
            0,
            0});
            this.numAnno.Minimum = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            this.numAnno.Name = "numAnno";
            this.numAnno.Size = new System.Drawing.Size(191, 20);
            this.numAnno.TabIndex = 0;
            this.numAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numAnno.Value = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año:";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(35, 54);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(191, 23);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "Procesar";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // pb01
            // 
            this.pb01.Location = new System.Drawing.Point(35, 96);
            this.pb01.Name = "pb01";
            this.pb01.Size = new System.Drawing.Size(191, 23);
            this.pb01.Step = 1;
            this.pb01.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb01.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Progreso:";
            // 
            // wkr01
            // 
            this.wkr01.WorkerReportsProgress = true;
            this.wkr01.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkr01_DoWork);
            this.wkr01.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkr01_ProgressChanged);
            this.wkr01.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkr01_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 131);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pb01);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numAnno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extractor de constancias";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAnno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numAnno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.ProgressBar pb01;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker wkr01;
        private System.Windows.Forms.FolderBrowserDialog fbd01;
    }
}

