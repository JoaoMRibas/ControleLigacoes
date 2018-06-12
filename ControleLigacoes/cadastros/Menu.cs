using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleLigacoes.cadastros;
using ControleLigacoes.consultas;
using ControleLigacoes.dados;

namespace ControleLigacoes.cadastros
{
    public partial class Menu : Form
    {
        public Menu(Usuario usuario)
        {
            InitializeComponent();
            UsuarioLogado = usuario;
        }

        public Usuario UsuarioLogado { get; }
        private CadCliente CadCliente { get; set; }
        private CadUsuario CadUsuario { get; set; }
        private CadLigacao CadLigacao { get; set; }

        private void BtCadCliente_Click(object sender, EventArgs e)
        {

            
            if (CadCliente == null)
            {
                CadCliente = new CadCliente();

            }

            
        }
    

        private void BtCadUsuario_Click(object sender, EventArgs e)
        {
            CadUsuario link2 = new CadUsuario();
            link2.ShowDialog();
        }

        private void BtCadLigacao_Click(object sender, EventArgs e)
        {
            CadLigacao link3 = new CadLigacao();
            link3.ShowDialog();
        }
    }
}
