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
        private Vertice verticeInicial;

        private String nome;

        public List<Vertice> Vertices { get => vertices; set => vertices = value; }
        public Vertice VerticeInicial { get => verticeInicial; set => verticeInicial = value; }
        public string Nome { get => nome; set => nome = value; }

        public Poligono()
        {
            vertices = new List<Vertice>();
        }

        public Poligono(List<Vertice> vertices)
        {
            this.vertices = vertices;
        }
    }
}
