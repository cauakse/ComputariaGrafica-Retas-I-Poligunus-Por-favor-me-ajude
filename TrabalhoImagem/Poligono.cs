using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoImagem
{
    internal class Poligono
    {
        private List<Vertice> vertices;
        private List<Vertice> verticesTransformados;
        private Vertice verticeInicial;

        private String nome;

        public List<Vertice> Vertices { get => vertices; set => vertices = value; }
        public Vertice VerticeInicial { get => verticeInicial; set => verticeInicial = value; }
        public List<Vertice> VerticesTransformados { get => verticesTransformados; set => verticesTransformados = value; }
        public string Nome { get => nome; set => nome = value; }

        public Poligono()
        {
            vertices = new List<Vertice>();
            verticesTransformados = new List<Vertice>();
    
        }

        public Poligono(List<Vertice> vertices)
        {
            this.vertices = vertices;
        }

        public void TransformarPoligono(MatrizTransformacao.Matriz m)
        {
            var baseVertices = verticesTransformados.Count > 0
                ? new List<Vertice>(verticesTransformados)
                : vertices;

            verticesTransformados.Clear();

            foreach (var v in baseVertices)
            {
                double x = v.getX();
                double y = v.getY();

                double xt = m.M[0, 0] * x + m.M[0, 1] * y + m.M[0, 2];
                double yt = m.M[1, 0] * x + m.M[1, 1] * y + m.M[1, 2];

                verticesTransformados.Add(new Vertice((int)xt, (int)yt));
            }
        }

        internal int CentroX()
        {
            //calcular o centro do polígono
            int sumX = 0;
            var baseVertices = verticesTransformados.Count > 0
    ? new List<Vertice>(verticesTransformados)
    : vertices;

            foreach (var vertice in baseVertices)
            {
                sumX += vertice.getX();
            }

            return sumX / vertices.Count;

        }

        internal int CentroY()
        {
            int sumY = 0;
            var baseVertices = verticesTransformados.Count > 0
    ? new List<Vertice>(verticesTransformados)
    : vertices;
            foreach (var vertice in baseVertices)
            {
                sumY += vertice.getY();
            }

            return sumY / vertices.Count;
        }
    }
}
