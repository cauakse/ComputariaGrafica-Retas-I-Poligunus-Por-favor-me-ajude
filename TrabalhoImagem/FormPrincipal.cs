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
    public partial class FormPrincipal : Form
    {

        Form formPoligonos;
        Form formRetas;
        public FormPrincipal()
        {
            InitializeComponent();
            formPoligonos = new FormPoligonos();
            formRetas = new FormRetas();
        }

        private void rbRetas_CheckedChanged_1(object sender, EventArgs e)
        {
            formRetas.Show();
            formPoligonos.Hide();
        }

        private void rbPoligonos_CheckedChanged_1(object sender, EventArgs e)
        {
            formPoligonos.Show();
            formRetas.Hide();
        }
    }
}
