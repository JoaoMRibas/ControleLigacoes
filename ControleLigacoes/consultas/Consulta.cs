﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ControleLigacoes.dados;

namespace ControleLigacoes.consultas
{
    public partial class Consulta<T> : Form
    {

        public Consulta()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.CellDoubleClick += DataGridView1_CellContentDoubleClick;

            if (typeof(T) == typeof(Cliente))
            {
                FileName = "clientes.json";
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Código", Name = "CodCli"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn{HeaderText = "Razão Social",Name = "RazaoSocial"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Nome Fantasia",Name = "NomeFantasia"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "CNPJ", Name = "Cnpj"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Telefone", Name = "Telefone"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "E-mail", Name = "Email"});
                CreateCells = obj =>
                {
                    Cliente cliente = obj as Cliente;
                    if (cliente == null)
                    {
                        return null;

                    }

                    return new object[]
                    {
                        cliente.Codigo, cliente.RazaoSocial, cliente.NomeFantasia,
                        cliente.Cnpj, cliente.Telefone, cliente.Email
                    };
                };
            }
            else if (typeof(T) == typeof(Usuario))
            {
                FileName = "usuarios.json";
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Código", Name = "Codigo"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Nome", Name = "Nome"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Login", Name = "Login"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tipo de Usuário",
                    Name = "TipoUsuario"
                });
                CreateCells = obj =>
                {
                    //return usuario == null ? null : new object[] { usuario.Codigo, usuario.Nome, usuario.Login, usuario.Tipo };
                    Usuario usuario = obj as Usuario;
                    if (usuario == null)
                    {
                        return null;
                    }


                    return new object[] {usuario.Codigo, usuario.Nome, usuario.Login, usuario.Tipo};


                };
            }

            if (typeof(T) == typeof(Ligacao))
            {
                FileName = "ligacoes.json";
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Código", Name = "Codigo"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Data e Hora", Name = "DataHora"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Cliente", Name = "Cliente"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Usuário", Name = "Usuario"});
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Observações", Name = "Observacoes", });
                CreateCells = obj =>
                {
                    Ligacao ligacao = obj as Ligacao;
                    if (ligacao == null)
                    {
                        return null;
                    }

                    return new object[]
                        {ligacao.Codigo, ligacao.DataHora, ligacao.Cliente.RazaoSocial, ligacao.Usuario.Nome, ligacao.Observacoes};
                };
            }
        }

        private Func<T,object[]> CreateCells { get; set; }
        private string FileName { get; set; }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            T uscl = (T) row.Tag;

            if (ItemSelecionado != null)
            {
                ItemSelecionado.Invoke(uscl);
                Close();
            }

        }


        public event Action<T> ItemSelecionado;



        public void CarregarDados()
        {
            dataGridView1.Rows.Clear();
            string dados = File.ReadAllText($"C:\\Users\\user\\Desktop\\Teste\\{FileName}");
            foreach (T d in dados.Deserialize<List<T>>())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1, CreateCells(d));
                row.Tag = d;
                dataGridView1.Rows.Add(row);
            }
        }


        public void Exibe()
        {
            CarregarDados();
            ShowDialog();

        }
    }
}
