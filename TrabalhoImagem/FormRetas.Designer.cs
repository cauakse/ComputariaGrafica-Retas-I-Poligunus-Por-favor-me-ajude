namespace TrabalhoImagem
{
    partial class FormRetas
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbControles = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbElipsePontoMedio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCircunferenciaPontoMedio = new System.Windows.Forms.RadioButton();
            this.rbTrigonometria = new System.Windows.Forms.RadioButton();
            this.rbEquacaoCircunferencia = new System.Windows.Forms.RadioButton();
            this.gbRetas = new System.Windows.Forms.GroupBox();
            this.rbRetasRapidas = new System.Windows.Forms.RadioButton();
            this.rbRetasDDA = new System.Windows.Forms.RadioButton();
            this.rbRetasEquacaoReal = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbControles.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbRetas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1132, 794);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(63, 752);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(133, 36);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gbControles
            // 
            this.gbControles.Controls.Add(this.groupBox2);
            this.gbControles.Controls.Add(this.groupBox1);
            this.gbControles.Controls.Add(this.gbRetas);
            this.gbControles.Controls.Add(this.btnLimpar);
            this.gbControles.Location = new System.Drawing.Point(1139, 0);
            this.gbControles.Margin = new System.Windows.Forms.Padding(4);
            this.gbControles.Name = "gbControles";
            this.gbControles.Padding = new System.Windows.Forms.Padding(4);
            this.gbControles.Size = new System.Drawing.Size(267, 794);
            this.gbControles.TabIndex = 4;
            this.gbControles.TabStop = false;
            this.gbControles.Text = "Controles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbElipsePontoMedio);
            this.groupBox2.Location = new System.Drawing.Point(11, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 62);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Elipse";
            // 
            // rbElipsePontoMedio
            // 
            this.rbElipsePontoMedio.AutoSize = true;
            this.rbElipsePontoMedio.Location = new System.Drawing.Point(6, 21);
            this.rbElipsePontoMedio.Name = "rbElipsePontoMedio";
            this.rbElipsePontoMedio.Size = new System.Drawing.Size(104, 20);
            this.rbElipsePontoMedio.TabIndex = 0;
            this.rbElipsePontoMedio.TabStop = true;
            this.rbElipsePontoMedio.Text = "Ponto Médio";
            this.rbElipsePontoMedio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCircunferenciaPontoMedio);
            this.groupBox1.Controls.Add(this.rbTrigonometria);
            this.groupBox1.Controls.Add(this.rbEquacaoCircunferencia);
            this.groupBox1.Location = new System.Drawing.Point(11, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 123);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Circunferência";
            // 
            // rbCircunferenciaPontoMedio
            // 
            this.rbCircunferenciaPontoMedio.AutoSize = true;
            this.rbCircunferenciaPontoMedio.Location = new System.Drawing.Point(6, 73);
            this.rbCircunferenciaPontoMedio.Name = "rbCircunferenciaPontoMedio";
            this.rbCircunferenciaPontoMedio.Size = new System.Drawing.Size(104, 20);
            this.rbCircunferenciaPontoMedio.TabIndex = 2;
            this.rbCircunferenciaPontoMedio.TabStop = true;
            this.rbCircunferenciaPontoMedio.Text = "Ponto Médio";
            this.rbCircunferenciaPontoMedio.UseVisualStyleBackColor = true;
            // 
            // rbTrigonometria
            // 
            this.rbTrigonometria.AutoSize = true;
            this.rbTrigonometria.Location = new System.Drawing.Point(6, 47);
            this.rbTrigonometria.Name = "rbTrigonometria";
            this.rbTrigonometria.Size = new System.Drawing.Size(112, 20);
            this.rbTrigonometria.TabIndex = 1;
            this.rbTrigonometria.TabStop = true;
            this.rbTrigonometria.Text = "Trigonometria";
            this.rbTrigonometria.UseVisualStyleBackColor = true;
            // 
            // rbEquacaoCircunferencia
            // 
            this.rbEquacaoCircunferencia.AutoSize = true;
            this.rbEquacaoCircunferencia.Location = new System.Drawing.Point(6, 21);
            this.rbEquacaoCircunferencia.Name = "rbEquacaoCircunferencia";
            this.rbEquacaoCircunferencia.Size = new System.Drawing.Size(171, 20);
            this.rbEquacaoCircunferencia.TabIndex = 0;
            this.rbEquacaoCircunferencia.TabStop = true;
            this.rbEquacaoCircunferencia.Text = "Equação Circunferência";
            this.rbEquacaoCircunferencia.UseVisualStyleBackColor = true;
            // 
            // gbRetas
            // 
            this.gbRetas.Controls.Add(this.rbRetasRapidas);
            this.gbRetas.Controls.Add(this.rbRetasDDA);
            this.gbRetas.Controls.Add(this.rbRetasEquacaoReal);
            this.gbRetas.Location = new System.Drawing.Point(9, 25);
            this.gbRetas.Margin = new System.Windows.Forms.Padding(4);
            this.gbRetas.Name = "gbRetas";
            this.gbRetas.Padding = new System.Windows.Forms.Padding(4);
            this.gbRetas.Size = new System.Drawing.Size(249, 122);
            this.gbRetas.TabIndex = 4;
            this.gbRetas.TabStop = false;
            this.gbRetas.Text = "Retas";
            // 
            // rbRetasRapidas
            // 
            this.rbRetasRapidas.AutoSize = true;
            this.rbRetasRapidas.Location = new System.Drawing.Point(8, 80);
            this.rbRetasRapidas.Margin = new System.Windows.Forms.Padding(4);
            this.rbRetasRapidas.Name = "rbRetasRapidas";
            this.rbRetasRapidas.Size = new System.Drawing.Size(119, 20);
            this.rbRetasRapidas.TabIndex = 2;
            this.rbRetasRapidas.TabStop = true;
            this.rbRetasRapidas.Text = "Retas Rápidas";
            this.rbRetasRapidas.UseVisualStyleBackColor = true;
            // 
            // rbRetasDDA
            // 
            this.rbRetasDDA.AutoSize = true;
            this.rbRetasDDA.Location = new System.Drawing.Point(8, 52);
            this.rbRetasDDA.Margin = new System.Windows.Forms.Padding(4);
            this.rbRetasDDA.Name = "rbRetasDDA";
            this.rbRetasDDA.Size = new System.Drawing.Size(188, 20);
            this.rbRetasDDA.TabIndex = 1;
            this.rbRetasDDA.TabStop = true;
            this.rbRetasDDA.Text = "Digital Differential Analyser";
            this.rbRetasDDA.UseVisualStyleBackColor = true;
            // 
            // rbRetasEquacaoReal
            // 
            this.rbRetasEquacaoReal.AutoSize = true;
            this.rbRetasEquacaoReal.Location = new System.Drawing.Point(8, 23);
            this.rbRetasEquacaoReal.Margin = new System.Windows.Forms.Padding(4);
            this.rbRetasEquacaoReal.Name = "rbRetasEquacaoReal";
            this.rbRetasEquacaoReal.Size = new System.Drawing.Size(166, 20);
            this.rbRetasEquacaoReal.TabIndex = 0;
            this.rbRetasEquacaoReal.TabStop = true;
            this.rbRetasEquacaoReal.Text = "Equação Real da Reta";
            this.rbRetasEquacaoReal.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 921);
            this.Controls.Add(this.gbControles);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbControles.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbRetas.ResumeLayout(false);
            this.gbRetas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox gbControles;
        private System.Windows.Forms.GroupBox gbRetas;
        private System.Windows.Forms.RadioButton rbRetasRapidas;
        private System.Windows.Forms.RadioButton rbRetasDDA;
        private System.Windows.Forms.RadioButton rbRetasEquacaoReal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCircunferenciaPontoMedio;
        private System.Windows.Forms.RadioButton rbTrigonometria;
        private System.Windows.Forms.RadioButton rbEquacaoCircunferencia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbElipsePontoMedio;
    }
}

