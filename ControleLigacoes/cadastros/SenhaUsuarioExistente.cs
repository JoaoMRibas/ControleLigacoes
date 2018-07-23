using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using ControleLigacoes.dados.password;
using ControleLigacoes.dados;

namespace ControleLigacoes.cadastros
{
    public partial class SenhaUsuarioExistente : Form
    {
        public SenhaUsuarioExistente()
        {
            InitializeComponent();
        }

        public HashWithSaltResult HashWithSalt { get; set; }

        public void Exibe()
        {
            ShowDialog();
        }


        private void LimparCampos()
        {
            SenAtual.Clear();
            ConfSenha.Clear();
            SenNova.Clear();

        }
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SenNova.Text) || string.IsNullOrWhiteSpace(ConfSenha.Text) ||
                string.IsNullOrWhiteSpace(SenAtual.Text))
            {
                MessageBox.Show("Os campos senha, confirmar ou senha atual estão vazios");
                return;

            }
            if (!ControleSenha.Instance.ValidarSenhas(SenNova.Text, ConfSenha.Text))
            {
                MessageBox.Show("As senhas digitadas nos campos senha e confirmar senha devem ser iguais.");
                return;
            }
            if(!ControleSenha.Instance.ValidarSenhaAtual(HashWithSalt, SenAtual.Text))
            {
                MessageBox.Show("A senha atual não está correta");
                return;
            }

            ControleSenha.Instance.GerarNovaSenha(SenNova.Text);
            LimparCampos();
            Close();

        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
