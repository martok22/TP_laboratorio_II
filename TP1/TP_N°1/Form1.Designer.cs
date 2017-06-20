namespace TP_N_1
{
    partial class Form1
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
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonOperar = new System.Windows.Forms.Button();
            this.textNumero1 = new System.Windows.Forms.TextBox();
            this.textNumero2 = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbOperacion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(16, 132);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(120, 52);
            this.botonLimpiar.TabIndex = 0;
            this.botonLimpiar.Text = "CC";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonOperar
            // 
            this.botonOperar.Location = new System.Drawing.Point(152, 132);
            this.botonOperar.Name = "botonOperar";
            this.botonOperar.Size = new System.Drawing.Size(120, 52);
            this.botonOperar.TabIndex = 1;
            this.botonOperar.Text = "=";
            this.botonOperar.UseVisualStyleBackColor = true;
            this.botonOperar.Click += new System.EventHandler(this.botonOperar_Click);
            // 
            // textNumero1
            // 
            this.textNumero1.Location = new System.Drawing.Point(16, 82);
            this.textNumero1.Name = "textNumero1";
            this.textNumero1.Size = new System.Drawing.Size(94, 20);
            this.textNumero1.TabIndex = 2;
            // 
            // textNumero2
            // 
            this.textNumero2.Location = new System.Drawing.Point(176, 82);
            this.textNumero2.Name = "textNumero2";
            this.textNumero2.Size = new System.Drawing.Size(96, 20);
            this.textNumero2.TabIndex = 3;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(18, 47);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(55, 13);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Resultado";
            // 
            // cmbOperacion
            // 
            this.cmbOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperacion.FormattingEnabled = true;
            this.cmbOperacion.Items.AddRange(new object[] {
            "/",
            "+",
            "-",
            "*"});
            this.cmbOperacion.Location = new System.Drawing.Point(123, 83);
            this.cmbOperacion.Name = "cmbOperacion";
            this.cmbOperacion.Size = new System.Drawing.Size(44, 21);
            this.cmbOperacion.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cmbOperacion);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.textNumero2);
            this.Controls.Add(this.textNumero1);
            this.Controls.Add(this.botonOperar);
            this.Controls.Add(this.botonLimpiar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonOperar;
        private System.Windows.Forms.TextBox textNumero1;
        private System.Windows.Forms.TextBox textNumero2;
        private System.Windows.Forms.ComboBox cmbOperacion;
        private System.Windows.Forms.Label lblResult;
    }
}

