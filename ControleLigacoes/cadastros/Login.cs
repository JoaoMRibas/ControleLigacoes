using ControleLigacoes.dados;
using ControleLigacoes.dados.password;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ControleLigacoes.cadastros
{

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            LoginUsu.KeyPress += LoginUsu_KeyPress;
            SenhaUsu.KeyPress += SenhaUsu_KeyPress;
        }

        public List<Usuario>Usuario { get; set; }

        private void SenhaUsu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                Logar();
            }
        }


        private void LoginUsu_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(13))

            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

        }
        void menu_Disposed(object sender, EventArgs e)
        {
            Close();
        }

        private void Logar()
        {
            Usuario usuario = null;
           

            using (LigacoesContext context = new LigacoesContext())
            {

                List<Usuario> usuarios = (from us in context.Usuarios
                    where us.Login.Equals(LoginUsu.Text)
                    select us).ToList();

                usuario = usuarios.FirstOrDefault();
                if(usuario == null || !ControleSenha.Instance.ValidarSenhaAtual(usuario.HashSalt, usuario.HashSenha, SenhaUsu.Text))
                {
                    MessageBox.Show("Senha ou nome de usuário estão errados, por favor tente novamente");
                    return;
                }


            }

            LoginUsu.Clear();
            SenhaUsu.Clear();
            Hide();
            Menu menu = new Menu(usuario);
            menu.Disposed += menu_Disposed;
            menu.Show();
            

        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Logar();
        }
    }
}

