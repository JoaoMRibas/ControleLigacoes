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

        
        public Usuario UsuarioLogado { get; set; }
        public Usuario UsuarioAtual { get; set; }

        private void EnviarInfor()
        {
            if (UsuarioAtual == null)
            {
                Usuario instancia = new Usuario();
                if (ConfSenha.Text == Senha.Text)
                {

                    PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                    HashWithSaltResult hashResultSha512 = pwHasher.HashWithSalt(ConfSenha.Text, 64, SHA512.Create());
                    instancia.HashSenha = hashResultSha512.Digest;
                    instancia.HashSalt = hashResultSha512.Salt;
                }

            }

            if (UsuarioAtual != null)
            {
                Usuario instancia = UsuarioAtual;
                if (ConfSenha.Text == Senha.Text && SenAntiga.Text == UsuarioAtual.HashSenha)
                {
                    PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                    HashWithSaltResult hashResultSha512 = pwHasher.HashWithSalt(ConfSenha.Text, 64, SHA512.Create());
                    instancia.HashSenha = hashResultSha512.Digest;
                    instancia.HashSalt = hashResultSha512.Salt;
                    UsuarioAtual.HashSenha = instancia.HashSenha;
                    UsuarioAtual.HashSalt = instancia.HashSalt;

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
            
        }
        private void LimparCampos()
        {
            Senha.Clear();
            ConfSenha.Clear();
            SenAntiga.Clear();

        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();

        }
    }
}
