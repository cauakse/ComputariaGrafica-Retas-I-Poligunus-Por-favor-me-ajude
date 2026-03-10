using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace TrabalhoImagem
{
    public partial class FormRetas : Form
    {
        private Bitmap originalBitmap;
        private Bitmap bufferBitmap;

        private bool desenhando = false;
        private Point pontoInicial, pontoAtual;

        public FormRetas()
        {
            InitializeComponent();

            rbRetasEquacaoReal.Checked = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            originalBitmap = new Bitmap(900, 700);
            Funcoes.CriarImagemTodaBranca(originalBitmap);

            rbRetasEquacaoReal.CheckedChanged += RadioButton_CheckedChanged;
            rbRetasDDA.CheckedChanged += RadioButton_CheckedChanged;
            rbRetasEquacaoReal.CheckedChanged += RadioButton_CheckedChanged;
            rbCircunferenciaPontoMedio.CheckedChanged += RadioButton_CheckedChanged;
            rbEquacaoCircunferencia.CheckedChanged += RadioButton_CheckedChanged;
            rbTrigonometria.CheckedChanged += RadioButton_CheckedChanged;
            rbElipsePontoMedio.CheckedChanged += RadioButton_CheckedChanged;


            pictureBox1.Image = originalBitmap;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Funcoes.CriarImagemTodaBranca(originalBitmap);
            pictureBox1.Image = originalBitmap;
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X >= originalBitmap.Width ||
                e.Y < 0 || e.Y >= originalBitmap.Height)
                return;

            desenhando = true;
            pontoInicial = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!desenhando) return;

            pontoAtual = e.Location;

            bufferBitmap = (Bitmap)originalBitmap.Clone();

            AlgoritmoSelecionado algoritmo = ObterAlgoritmoSelecionado();

            Funcoes.Desenhar(bufferBitmap, pontoInicial, pontoAtual, 200, algoritmo);

            pictureBox1.Image = bufferBitmap;
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!desenhando) return;

            desenhando = false;
            pontoAtual = e.Location;

            AlgoritmoSelecionado algoritmo = ObterAlgoritmoSelecionado();

            Funcoes.Desenhar(originalBitmap, pontoInicial, pontoAtual, 0, algoritmo);

            pictureBox1.Image = originalBitmap;
            pictureBox1.Refresh();

            bufferBitmap?.Dispose();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selecionado = sender as RadioButton;

            if (!selecionado.Checked)
                return;


            foreach (Control control in gbControles.Controls)
            {
                if (control is GroupBox gb)
                {
                    foreach (Control c in gb.Controls)
                    {
                        if (c is RadioButton rb && rb != selecionado)
                        {
                            rb.Checked = false;
                        }
                    }
                }
            }
        }


        private void rbRetasEquacaoReal_CheckedChanged(object sender, EventArgs e)
        {
            rbCircunferenciaPontoMedio.Checked = false;
            rbRetasDDA.Checked = false;
            rbRetasRapidas.Checked = false;
            rbEquacaoCircunferencia.Checked = false;
            rbTrigonometria.Checked = false;
            rbElipsePontoMedio.Checked = false;
        }

        private void rbRetasDDA_CheckedChanged(object sender, EventArgs e)
        {
            rbRetasEquacaoReal.Checked = false;
            rbCircunferenciaPontoMedio.Checked = false;
            rbRetasRapidas.Checked = false;
            rbEquacaoCircunferencia.Checked = false;
            rbTrigonometria.Checked = false;
            rbElipsePontoMedio.Checked = false;
        }

        private void rbRetasRapidas_CheckedChanged(object sender, EventArgs e)
        {
            rbRetasEquacaoReal.Checked = false;
            rbRetasDDA.Checked = false;
            rbCircunferenciaPontoMedio.Checked = false;
            rbEquacaoCircunferencia.Checked = false;
            rbTrigonometria.Checked = false;
            rbElipsePontoMedio.Checked = false;
        }

        private void rbEquacaoCircunferencia_CheckedChanged(object sender, EventArgs e)
        {
            rbRetasEquacaoReal.Checked = false;
            rbRetasDDA.Checked = false;
            rbRetasRapidas.Checked = false;
            rbCircunferenciaPontoMedio.Checked = false;
            rbTrigonometria.Checked = false;
            rbElipsePontoMedio.Checked = false;
        }

        private void rbTrigonometria_CheckedChanged(object sender, EventArgs e)
        {
            rbRetasEquacaoReal.Checked = false;
            rbRetasDDA.Checked = false;
            rbRetasRapidas.Checked = false;
            rbEquacaoCircunferencia.Checked = false;
            rbCircunferenciaPontoMedio.Checked = false;
            rbElipsePontoMedio.Checked = false;
        }

        private void rbCircunferenciaPontoMedio_CheckedChanged_1(object sender, EventArgs e)
        {
            rbRetasEquacaoReal.Checked = false;
            rbRetasDDA.Checked = false;
            rbRetasRapidas.Checked = false;
            rbEquacaoCircunferencia.Checked = false;
            rbTrigonometria.Checked = false;
            rbElipsePontoMedio.Checked = false;
        }

        private void rbElipsePontoMedio_CheckedChanged(object sender, EventArgs e)
        {
            rbRetasEquacaoReal.Checked = false;
            rbRetasDDA.Checked = false;
            rbRetasRapidas.Checked = false;
            rbEquacaoCircunferencia.Checked = false;
            rbTrigonometria.Checked = false;
            rbCircunferenciaPontoMedio.Checked = false;
        }

        private AlgoritmoSelecionado ObterAlgoritmoSelecionado()
        {
            if (rbRetasDDA.Checked) return AlgoritmoSelecionado.RETA_DDA;
            if (rbRetasRapidas.Checked) return AlgoritmoSelecionado.RETA_RETASRAPIDAS;
            if(rbRetasEquacaoReal.Checked) return AlgoritmoSelecionado.RETA_EQUACAO_REAL;
            if(rbTrigonometria.Checked) return AlgoritmoSelecionado.CIRCUNFERENCIA_TRIGONOMETRIA;
            if(rbCircunferenciaPontoMedio.Checked) return AlgoritmoSelecionado.CIRCUNFERENCIA_PONTO_MEDIO;
            if(rbEquacaoCircunferencia.Checked) return AlgoritmoSelecionado.CIRCUNFERENCIA_EQUACAO_REAL;
            return AlgoritmoSelecionado.ELIPSE_PONTO_MEDIO;
        }
    }
}
