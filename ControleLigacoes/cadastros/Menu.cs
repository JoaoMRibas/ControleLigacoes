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

        public Usuario UsuarioLogado  { get; }
        private CadCliente CadCliente { get; set; }
        private CadUsuario CadUsuario { get; set; }
        private CadLigacao CadLigacao { get; set; }


        private void IniciaCadCliente()
        {
            if (CadCliente == null)
            {
                CadCliente = new CadCliente();
                CadCliente.ShowDialog();

            }

            return;

        }

        private void IniciaCadUsuario()
        {
            
            
            if (CadUsuario == null)
            {
                CadUsuario = new CadUsuario();
                CadUsuario.ShowDialog();
            }

            return;

        }

        private void IniciaCadLigacao()
        {
            if (CadLigacao == null)
            {

                CadLigacao = new CadLigacao();
                CadLigacao.UsuarioLogado = UsuarioLogado;
                CadLigacao.ShowDialog();

            }
            return;
        }

        private void BtCadCliente_Click(object sender, EventArgs e)
        {
            IniciaCadCliente();
        }
    

        private void BtCadUsuario_Click(object sender, EventArgs e)
        {
            IniciaCadUsuario();
        }

        private void BtCadLigacao_Click(object sender, EventArgs e)
        {
            IniciaCadLigacao();
        }
    }
}
