using ControleLigacoes.dados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
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

        private void Logar()
        {
            Usuario usuario = null;

            using (LigacoesContext context = new LigacoesContext())
            {


                List<Usuario> usuarios = (from us in context.Usuarios
                    where us.Login.Equals(LoginUsu.Text) && us.Senha.Equals(SenhaUsu.Text)
                    select us).ToList();

                if (!usuarios.Any())
                {
                    MessageBox.Show("Senha ou nome de usuário estão errados, por favor tente novamente");
                    return;
                }

                if (usuarios.Count > 1)
                {
                    MessageBox.Show("Erro, mais de 1 usuário selecionado, reinicie o programa");
                    return;
                }

                usuario = usuarios.FirstOrDefault();

            }

            LoginUsu.Clear();
            SenhaUsu.Clear();
            Menu menu = new Menu(usuario);
            menu.ShowDialog();
            
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Logar();
        }
    }
}

