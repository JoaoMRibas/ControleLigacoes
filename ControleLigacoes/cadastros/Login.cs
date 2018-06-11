using ControleLigacoes.dados;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {


            using (LigacoesContext context = new LigacoesContext())
            {


                List<Usuario> usuarios = (from Usuario in context.Usuarios
                where Usuario.Login.Equals(LoginUsu.Text) && Usuario.Senha.Equals(SenhaUsu.Text)
                               select Usuario).ToList();

                if (!usuarios.Any())
                {
                    MessageBox.Show("Senha ou nome de usuário estão errados, por favor tente novamente");
                    return;
                }

                Menu menu = new Menu();
                menu.ShowDialog();

            }
            
            


        }
    }
}
