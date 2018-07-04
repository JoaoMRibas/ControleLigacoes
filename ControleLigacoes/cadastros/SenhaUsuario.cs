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
            
            if (HashWithSalt == null)
            {

                SenAntiga.ReadOnly = true;
                SenAntiga.Text = "Campo não necessário.";

            }
            else
            {
                SenAntiga.ReadOnly = false;
            }

            ShowDialog();
        }

        private void EnviarInfor()
        {
            if (HashWithSalt == null)
            {
                if (!ConfSenha.Text.Equals(Senha.Text))
                {
                    MessageBox.Show("As senhas digitadas nos campos senha e confirmar senha devem ser iguais.");
                    return;
                }

                PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                HashWithSalt = pwHasher.HashWithSalt(ConfSenha.Text, 64, SHA512.Create());

            }

            if (HashWithSalt != null)
            {
                if (ConfSenha.Text == Senha.Text && SenAntiga.Text == UsuarioAtual.HashSenha)
                {
                    PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                    HashWithSalt = pwHasher.HashWithSalt(ConfSenha.Text, 64, SHA512.Create());

                }
                if(ConfSenha.Text != Senha.Text)
                {
                    MessageBox.Show("As senhas digitadas nos campos senha e confirmar senha devem ser iguais.");
                    return;
                }

                if (SenAntiga.Text != UsuarioAtual.HashSenha)
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
            Senha.Clear();
            ConfSenha.Clear();
            SenAntiga.Clear();
            HashWithSalt = null;

        }

        
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();

        }
    }
}
