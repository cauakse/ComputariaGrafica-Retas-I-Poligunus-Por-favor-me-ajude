namespace TrabalhoImagem
{
    partial class FormPrincipal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPoligonos = new System.Windows.Forms.RadioButton();
            this.rbRetas = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPoligonos);
            this.groupBox1.Controls.Add(this.rbRetas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecione qual solucao deseja abrir";
            // 
            // rbPoligonos
            // 
            this.rbPoligonos.AutoSize = true;
            this.rbPoligonos.Location = new System.Drawing.Point(6, 80);
            this.rbPoligonos.Name = "rbPoligonos";
            this.rbPoligonos.Size = new System.Drawing.Size(89, 20);
            this.rbPoligonos.TabIndex = 1;
            this.rbPoligonos.TabStop = true;
            this.rbPoligonos.Text = "Poligonos";
            this.rbPoligonos.UseVisualStyleBackColor = true;
            this.rbPoligonos.CheckedChanged += new System.EventHandler(this.rbPoligonos_CheckedChanged_1);
            // 
            // rbRetas
            // 
            this.rbRetas.AutoSize = true;
            this.rbRetas.Location = new System.Drawing.Point(6, 37);
            this.rbRetas.Name = "rbRetas";
            this.rbRetas.Size = new System.Drawing.Size(64, 20);
            this.rbRetas.TabIndex = 0;
            this.rbRetas.TabStop = true;
            this.rbRetas.Text = "Retas";
            this.rbRetas.UseVisualStyleBackColor = true;
            this.rbRetas.CheckedChanged += new System.EventHandler(this.rbRetas_CheckedChanged_1);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPrincipal";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPoligonos;
        private System.Windows.Forms.RadioButton rbRetas;
    }
}