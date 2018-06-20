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

            else
            {
                CadCliente = CadCliente;
                CadCliente.ShowDialog();
            }


        }

        private void IniciaCadUsuario()
        {
            
            
            if (CadUsuario == null)
            {
                CadUsuario = new CadUsuario();
                CadUsuario.ShowDialog();
            }

            else
            {
                CadUsuario = CadUsuario;
                CadUsuario.ShowDialog();
            }

            

        }

        private void IniciaCadLigacao()
        {
            if (CadLigacao == null)
            {
                
                CadLigacao = new CadLigacao();
                CadLigacao.UsuarioLogado = UsuarioLogado;
                CadLigacao.ShowDialog();

            }

            else
            {
               
                CadLigacao = CadLigacao;
                CadLigacao.UsuarioLogado = UsuarioLogado;
                CadLigacao.ShowDialog();
            }

        }

        private void BtCadCliente_Click(object sender, EventArgs e)
        {
            IniciaCadCliente();
        }
    

        private void BtCadUsuario_Click(object sender, EventArgs e)
        {
            if (!TipoUsuario.Admin.Equals(UsuarioLogado.Tipo))
            {
                MessageBox.Show("Somente administradores tem permissão para adicionar usuários.");
                return;
            }
            IniciaCadUsuario();
        }

        private void BtCadLigacao_Click(object sender, EventArgs e)
        {
            IniciaCadLigacao();
        }
    }
}
