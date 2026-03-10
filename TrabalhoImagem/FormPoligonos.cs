using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoImagem
{
    public partial class FormPoligonos : Form
    {

        List<Poligono> poligonos = new List<Poligono>();
        Poligono poligonoSelecionado;
        bool modoDesenho = false;
        private Bitmap originalBitmap;
        private Bitmap bufferBitmap;
        int contadorPoligonos = 0;
        public FormPoligonos()
        {
            InitializeComponent();
            listView2.View = View.Details;
            listView2.Columns.Add("X", 50);
            listView2.Columns.Add("Y", 50);
            button2.Visible = false;
            listView1.View = View.Details;
            listView1.Columns.Add("Polígono", 100);


            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            originalBitmap = new Bitmap(900, 700);
            Funcoes.CriarImagemTodaBranca(originalBitmap);
            pictureBox1.Image = originalBitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            modoDesenho = true;
            bufferBitmap = (Bitmap)originalBitmap.Clone();

            poligonoSelecionado = new Poligono();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            modoDesenho = false;

            Funcoes.DesenharPoligono(originalBitmap, poligonoSelecionado.Vertices, 0);
            pictureBox1.Image = originalBitmap;
            pictureBox1.Refresh();
            bufferBitmap?.Dispose();

            poligonoSelecionado.Nome = "Polígono " + contadorPoligonos++;
            listView1.Items.Add(poligonoSelecionado.Nome);
            poligonos.Add(poligonoSelecionado);
            
            listView2.Items.Clear();
            for (int i =0; i < poligonos.Count; i++)
            {
                listView1.Items[i].Selected = false;
            }
            listView1.Items[listView1.Items.Count - 1].Selected = true;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!modoDesenho) return;

            poligonoSelecionado.Vertices.Add(new Vertice(e.X, e.Y));
            bufferBitmap = (Bitmap)originalBitmap.Clone();
            Funcoes.DesenharPoligono(bufferBitmap, poligonoSelecionado.Vertices, 0);
            pictureBox1.Image = bufferBitmap;
            pictureBox1.Refresh();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Funcoes.CriarImagemTodaBranca(originalBitmap);
            pictureBox1.Image = originalBitmap;
            modoDesenho = false;
            poligonoSelecionado = null;
            listView1.Items.Clear();
            listView2.Items.Clear();
            button1.Visible = true;
            button2.Visible = false;
            poligonos.Clear();
            pictureBox1.Refresh();
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            listView2.Items.Clear();
            for(int i = 0; i < poligonos.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    foreach (var vertice in poligonos[i].Vertices)
                    {
                        ListViewItem item = new ListViewItem(vertice.getX().ToString());
                        item.SubItems.Add(vertice.getY().ToString());
                        listView2.Items.Add(item);
                    }
                }
            }
        }
    }
}
