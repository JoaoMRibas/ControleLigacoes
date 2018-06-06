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
                var usuarios = from u in context.Usuarios
                where u.Nome.Equals(LoginUsu) && u.Senha.Equals(SenhaUsu)
                               select u;

                if (usuarios == )
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
