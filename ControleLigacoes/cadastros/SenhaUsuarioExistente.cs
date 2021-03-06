﻿using System;
using System.Windows.Forms;
using ControleLigacoes.dados.password;

namespace ControleLigacoes.cadastros
{
    public partial class SenhaUsuarioExistente : Form
    {
        public SenhaUsuarioExistente()
        {
            InitializeComponent();
            Inicializa();
        }
        public void Inicializa()
        {
            FormClosed += SenhaUsuarioExistent_FormClosed;
        }

        private void SenhaUsuarioExistent_FormClosed(object sender, FormClosedEventArgs e)
        {
            LimparCampos();
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

            HashWithSaltResult hashWithSalt = ControleSenha.Instance.GerarNovaSenha(SenNova.Text);
            HashWithSalt = hashWithSalt;
            LimparCampos();
            Close();

        }

        private void BtnLimpar_Click_1(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
