﻿using System;
using System.Windows.Forms;
using ControleLigacoes.dados.password;

namespace ControleLigacoes.cadastros
{
    public partial class SenhaUsuario : Form
    {
        public SenhaUsuario()
        {
            InitializeComponent();
            Inicializa();
        }

        public HashWithSaltResult HashWithSalt { get; set; }
        public void Inicializa()
        {
            FormClosed += SenhaUsuario_FormClosed;

        }

        private void SenhaUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            LimparCampos();
        }

        public void Exibe()

        {
            
            ShowDialog();

        }

        private void LimparCampos()
        {
            Senha.Clear();
            ConfSenha.Clear();

        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(Senha.Text) || string.IsNullOrWhiteSpace(ConfSenha.Text))               
            {
                MessageBox.Show("Os campos senha, confirmar ou senha atual estão vazios");
                return;

            }

            if (!ControleSenha.Instance.ValidarSenhas(Senha.Text, ConfSenha.Text))
            {
                MessageBox.Show("As senhas digitadas nos campos senha e confirmar senha devem ser iguais.");
                return;
            }

            HashWithSaltResult hashWithSalt = ControleSenha.Instance.GerarNovaSenha(Senha.Text);
            HashWithSalt = hashWithSalt;
            LimparCampos();
            Close();
             
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();

        }
    }
}
