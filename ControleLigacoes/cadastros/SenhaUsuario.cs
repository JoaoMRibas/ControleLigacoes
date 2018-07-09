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
            if (UsuarioAtual == null)
            {
                if (!ConfSenha.Text.Equals(SenhaNova.Text))
                {
                    MessageBox.Show("As senhas digitadas nos campos senha e confirmar senha devem ser iguais.");
                    return;
                }

                PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                HashWithSalt = pwHasher.HashWithSalt(ConfSenha.Text, 64, SHA512.Create());

            }

            if (UsuarioAtual != null)
            {
                if (ConfSenha.Text == SenhaNova.Text && SenAtual.Text == UsuarioAtual.HashSenha)
                {
                    PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                    HashWithSalt = pwHasher.HashWithSalt(ConfSenha.Text, 64, SHA512.Create());

                }
                if(ConfSenha.Text != SenhaNova.Text)
                {
                    MessageBox.Show("As senhas digitadas nos campos senha e confirmar senha devem ser iguais.");
                    return;
                }

                if (SenAtual.Text != UsuarioAtual.HashSenha)
                {
                    MessageBox.Show("A senha antiga não está correta");
                    return;
                }
                
            }

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
