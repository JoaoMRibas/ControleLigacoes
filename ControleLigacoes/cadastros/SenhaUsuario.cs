using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleLigacoes.dados;
using ControleLigacoes.dados.password;

namespace ControleLigacoes.cadastros
{
    public partial class SenhaUsuario : Form
    {
        public SenhaUsuario()
        {
            InitializeComponent();
        }

        public HashWithSaltResult HashWithSalt { get; set; }
        public Usuario UsuarioAtual { get; set; }

        public void Exibe()
        {
            
            if (UsuarioAtual == null)
            {
                
                SenAtual.ReadOnly = true;
                SenAtual.Text = "Campo não necessário.";

            }
            else
            {
                SenAtual.PasswordChar = '*';
                SenAtual.ReadOnly = false;
            }

            ShowDialog();
            
        }

        private void EnviarInfor()
        {
            PasswordWithSaltHasher pwHasher;
            if (UsuarioAtual == null)
            {
                if (!ConfSenha.Text.Equals(SenhaNova.Text))
                {
                    MessageBox.Show("As senhas digitadas nos campos senha e confirmar senha devem ser iguais.");
                    return;
                }

                pwHasher = new PasswordWithSaltHasher();
                HashWithSalt = pwHasher.HashWithSalt(ConfSenha.Text, 64, SHA512.Create());
                return;
            }


            if (string.IsNullOrWhiteSpace(SenhaNova.Text) || string.IsNullOrWhiteSpace(ConfSenha.Text))
            {
                MessageBox.Show("As senhas digitadas nos campos senha ou confirmar não foram digitadas");
                return;

            }
            if (!ConfSenha.Text.Equals(SenhaNova.Text))
            {
                MessageBox.Show("As senhas digitadas nos campos senha e confirmar senha devem ser iguais.");
                return;
            }

            pwHasher = new PasswordWithSaltHasher();
            HashWithSalt = pwHasher.HashWithSalt(SenAtual.Text, UsuarioAtual.HashSalt, SHA512.Create());

            if (!HashWithSalt.Digest.Equals(UsuarioAtual.HashSenha))

            {

                MessageBox.Show("A senha antiga não está correta");
                return;
            }
            pwHasher= new PasswordWithSaltHasher();
            HashWithSalt = pwHasher.HashWithSalt(ConfSenha.Text, 64, SHA512.Create());



        }


        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            EnviarInfor();
            LimparCampos();
            Close();
        }
        private void LimparCampos()
        {
            SenhaNova.Clear();
            ConfSenha.Clear();
            SenAtual.Clear();

        }

        
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();

        }
    }
}
