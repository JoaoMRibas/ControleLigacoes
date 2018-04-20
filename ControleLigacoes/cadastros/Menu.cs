using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleLigacoes.cadastros
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CadCliente link1 = new CadCliente();
            link1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadUsuario link2 = new CadUsuario();
            link2.ShowDialog();
        }
    }
}
