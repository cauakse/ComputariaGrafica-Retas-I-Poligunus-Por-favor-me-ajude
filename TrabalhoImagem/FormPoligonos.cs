using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            if (poligonoSelecionado.Vertices.Count <= 2)
            {
                poligonoSelecionado = null;
                pictureBox1.Image = originalBitmap;
                pictureBox1.Refresh();
                bufferBitmap?.Dispose();
                return;
            }
            

            Funcoes.DesenharPoligono(originalBitmap, poligonoSelecionado.Vertices, 0);
            Vertice ultimoVertice = poligonoSelecionado.Vertices[poligonoSelecionado.Vertices.Count - 1];
            Vertice primeiro = poligonoSelecionado.Vertices[0];
            Funcoes.Desenhar(originalBitmap, new Point(ultimoVertice.getX(), ultimoVertice.getY()), new Point(primeiro.getX(), primeiro.getY()), 0, AlgoritmoSelecionado.RETA_RETASRAPIDAS);
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

        private void btnAplicarTranslacao_Click(object sender, EventArgs e)
        {
            Transformar(AlgoritmoSelecionado.TRANSLACAO);
        }

        private void btnAplicarEscala_Click(object sender, EventArgs e)
        {
            bool colocarEm00 = cbEIXOCENTRALESCALA.Checked;
            Transformar(colocarEm00? AlgoritmoSelecionado.ESCALA_EIXO_0 : AlgoritmoSelecionado.ESCALA);
        }

        private void btnAplicarRotacao_Click(object sender, EventArgs e)
        {
            bool colocarEm00 = cbEIXOROTACAO.Checked;
            Transformar(colocarEm00 ? AlgoritmoSelecionado.ROTACAO_EIXO_0 : AlgoritmoSelecionado.ROTACAO);
        }

        private void Transformar(AlgoritmoSelecionado tipoTransformacao)
        {
            if (!Enum.TryParse<AlgoritmoSelecionado>(tipoTransformacao.ToString(), out var resultado)) return;

            int indice = -1;

            for (int i = 0; i < poligonos.Count && indice!=i; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    indice = i;
                }
            }

            if (indice == -1) return;

            var poligono = poligonos[indice];

            MatrizTransformacao.Matriz matriz = getMatriz(tipoTransformacao, poligono);

            // apagar polígono atual
            if (poligono.VerticesTransformados.Count > 0)
            {
                Funcoes.DesenharPoligono(originalBitmap, poligono.VerticesTransformados, 255);
                Funcoes.Desenhar(originalBitmap, new Point(poligono.VerticesTransformados[poligono.VerticesTransformados.Count - 1].getX(), poligono.VerticesTransformados[poligono.VerticesTransformados.Count - 1].getY()), new Point(poligono.VerticesTransformados[0].getX(), poligono.VerticesTransformados[0].getY()), 255, AlgoritmoSelecionado.RETA_RETASRAPIDAS);
            }
            else
            {
                Funcoes.DesenharPoligono(originalBitmap, poligono.Vertices, 255);
                Funcoes.Desenhar(originalBitmap, new Point(poligono.Vertices[poligono.Vertices.Count - 1].getX(), poligono.Vertices[poligono.Vertices.Count - 1].getY()), new Point(poligono.Vertices[0].getX(), poligono.Vertices[0].getY()), 255, AlgoritmoSelecionado.RETA_RETASRAPIDAS);
            }


            poligono.TransformarPoligono(matriz);

            // desenhar transformado
            Funcoes.DesenharPoligono(originalBitmap, poligono.VerticesTransformados, 0);
            Funcoes.Desenhar(originalBitmap, new Point(poligono.VerticesTransformados[poligono.VerticesTransformados.Count - 1].getX(), poligono.VerticesTransformados[poligono.VerticesTransformados.Count - 1].getY()), new Point(poligono.VerticesTransformados[0].getX(), poligono.VerticesTransformados[0].getY()), 0, AlgoritmoSelecionado.RETA_RETASRAPIDAS);
            pictureBox1.Image = originalBitmap;
            pictureBox1.Refresh();

        }

        private MatrizTransformacao.Matriz getMatriz(AlgoritmoSelecionado tipoTransformacao, Poligono poligonoSelecionado)
        {
            MatrizTransformacao.Matriz matriz = null;

            switch (tipoTransformacao)
            {
                case AlgoritmoSelecionado.TRANSLACAO:
                {
                    int dx = (int)nudDXTRANSLACAO.Value;
                    int dy = (int)nudDYTRANSLACAO.Value;
                    matriz = MatrizTransformacao.Translation(dx, dy);
                    break;
                }

                case AlgoritmoSelecionado.ESCALA:
                {
                    double sx = (double)nudSXESCALA.Value;
                    double sy = (double)nudSYESCALA.Value;
                    matriz = MatrizTransformacao.Scale(sx, sy);
                    break;
                }

                case AlgoritmoSelecionado.ESCALA_EIXO_0:
                {
                    double sx1 = (double)nudSXESCALA.Value;
                    double sy1 = (double)nudSYESCALA.Value;

                    double cx = poligonoSelecionado.CentroX();
                    double cy = poligonoSelecionado.CentroY();

                    var t1 = MatrizTransformacao.Translation(-cx, -cy);
                    var s = MatrizTransformacao.Scale(sx1, sy1);
                    var t2 = MatrizTransformacao.Translation(cx, cy);

                    matriz = MatrizTransformacao.Matriz.Multiply(
                                t2,
                                MatrizTransformacao.Matriz.Multiply(s, t1)
                                );
                    break;
                }

                case AlgoritmoSelecionado.ROTACAO_EIXO_0:
                {   
                    int angulo = (int)nudANGULOROTOCAO.Value;
                    MatrizTransformacao.Matriz matrizTranslacaoPara00 = MatrizTransformacao.Translation(-poligonoSelecionado.CentroX(), -poligonoSelecionado.CentroY());
                    MatrizTransformacao.Matriz matrizRotacao = MatrizTransformacao.Rotation(angulo);
                    MatrizTransformacao.Matriz matrizTranslacaoDeVolta = MatrizTransformacao.Translation(poligonoSelecionado.CentroX(), poligonoSelecionado.CentroY());
                    matriz = MatrizTransformacao.Matriz.Multiply(matrizTranslacaoDeVolta, MatrizTransformacao.Matriz.Multiply(matrizRotacao, matrizTranslacaoPara00));
                    break;
                }

                case AlgoritmoSelecionado.ROTACAO:
                {
                    matriz = MatrizTransformacao.Rotation((int)nudANGULOROTOCAO.Value);
                    break;
                }

                case AlgoritmoSelecionado.CISALHAMENTO: 
                {
                    double shx = (double)nudXCISALHAMENTO.Value;
                    double shy = (double)nudYCISALHAMENTO.Value;

                    var shear = MatrizTransformacao.Matriz.Multiply(
                        MatrizTransformacao.CisalhamentoY(shy),
                        MatrizTransformacao.CisalhamentoX(shx)
                    );

                    double cx = poligonoSelecionado.CentroX();
                    double cy = poligonoSelecionado.CentroY();

                    var t1 = MatrizTransformacao.Translation(-cx, -cy);
                    var t2 = MatrizTransformacao.Translation(cx, cy);

                    matriz = MatrizTransformacao.Matriz.Multiply(
                        t2,
                        MatrizTransformacao.Matriz.Multiply(shear, t1)
                    );

                    break;
                    }

                case AlgoritmoSelecionado.ESPELHO_X:
                {
                    double cx = poligonoSelecionado.CentroX();
                    double cy = poligonoSelecionado.CentroY();

                    var t1 = MatrizTransformacao.Translation(-cx, -cy);
                    var r = MatrizTransformacao.ReflectionX();
                    var t2 = MatrizTransformacao.Translation(cx, cy);

                    matriz = MatrizTransformacao.Matriz.Multiply(
                                t2,
                                MatrizTransformacao.Matriz.Multiply(r, t1)
                            );
                    break;
                }

                case AlgoritmoSelecionado.ESPELHO_Y:
                    {
                        double cx = poligonoSelecionado.CentroX();
                        double cy = poligonoSelecionado.CentroY();

                        var t1 = MatrizTransformacao.Translation(-cx, -cy);
                        var r = MatrizTransformacao.ReflectionY();
                        var t2 = MatrizTransformacao.Translation(cx, cy);

                        matriz = MatrizTransformacao.Matriz.Multiply(
                                    t2,
                                    MatrizTransformacao.Matriz.Multiply(r, t1)
                                );
                        break;
                    }
            }

            return matriz;
        }

        private void btnAplicarCisalhamento_Click(object sender, EventArgs e)
        {
            Transformar(AlgoritmoSelecionado.CISALHAMENTO);
        }

        private void btnEspelharX_Click(object sender, EventArgs e)
        {
            Transformar(AlgoritmoSelecionado.ESPELHO_X);
        }

        private void btnEspelharY_Click(object sender, EventArgs e)
        {
            Transformar(AlgoritmoSelecionado.ESPELHO_Y);
        }
    }
}
