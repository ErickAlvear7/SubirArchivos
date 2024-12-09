
namespace SubirArchivos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProcesar = new System.Windows.Forms.Button();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInsert = new System.Windows.Forms.TextBox();
            this.txtActivos = new System.Windows.Forms.TextBox();
            this.txtInactivos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNuevos = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.Location = new System.Drawing.Point(39, 120);
            this.btnProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(110, 66);
            this.btnProcesar.TabIndex = 0;
            this.btnProcesar.Text = "PROCESAR CSV";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRutaArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRutaArchivo.Location = new System.Drawing.Point(197, 46);
            this.txtRutaArchivo.Multiline = true;
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(359, 37);
            this.txtRutaArchivo.TabIndex = 1;
            this.txtRutaArchivo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRutaArchivo_MouseClick);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "OPEN FILE:";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(195, 251);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(360, 23);
            this.ProgressBar1.TabIndex = 3;
            this.ProgressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filas Insertadas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Titulares Activos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Titulares Inactivos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(379, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Base Total";
            // 
            // txtInsert
            // 
            this.txtInsert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInsert.Location = new System.Drawing.Point(288, 118);
            this.txtInsert.Name = "txtInsert";
            this.txtInsert.ReadOnly = true;
            this.txtInsert.Size = new System.Drawing.Size(67, 20);
            this.txtInsert.TabIndex = 14;
            this.txtInsert.Text = "0";
            this.txtInsert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtActivos
            // 
            this.txtActivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtActivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActivos.Location = new System.Drawing.Point(288, 163);
            this.txtActivos.Name = "txtActivos";
            this.txtActivos.ReadOnly = true;
            this.txtActivos.Size = new System.Drawing.Size(67, 20);
            this.txtActivos.TabIndex = 15;
            this.txtActivos.Text = "0";
            this.txtActivos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInactivos
            // 
            this.txtInactivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtInactivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInactivos.Location = new System.Drawing.Point(488, 163);
            this.txtInactivos.Name = "txtInactivos";
            this.txtInactivos.ReadOnly = true;
            this.txtInactivos.Size = new System.Drawing.Size(67, 20);
            this.txtInactivos.TabIndex = 16;
            this.txtInactivos.Text = "0";
            this.txtInactivos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nuevos";
            // 
            // txtNuevos
            // 
            this.txtNuevos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNuevos.Location = new System.Drawing.Point(288, 201);
            this.txtNuevos.Name = "txtNuevos";
            this.txtNuevos.ReadOnly = true;
            this.txtNuevos.Size = new System.Drawing.Size(68, 20);
            this.txtNuevos.TabIndex = 18;
            this.txtNuevos.Text = "0";
            this.txtNuevos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Location = new System.Drawing.Point(488, 207);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(68, 20);
            this.txtTotal.TabIndex = 19;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(593, 308);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtNuevos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInactivos);
            this.Controls.Add(this.txtActivos);
            this.Controls.Add(this.txtInsert);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.btnProcesar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "CARGAR ARCHIVO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInsert;
        private System.Windows.Forms.TextBox txtActivos;
        private System.Windows.Forms.TextBox txtInactivos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNuevos;
        private System.Windows.Forms.TextBox txtTotal;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

