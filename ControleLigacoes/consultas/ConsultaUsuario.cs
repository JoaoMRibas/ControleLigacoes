using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleLigacoes.cadastros;
using ControleLigacoes.dados;

namespace ControleLigacoes.consultas
{
    public partial class ConsultaUsuario : Form
    {
        public ConsultaUsuario()
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
        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0)
            {
                return;
            }
            
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            Usuario us = (Usuario) row.Tag;
            
            if (ItemSelecionado != null)
            {
                ItemSelecionado.Invoke(us);
                Close();
            }
            
        }


        public event Action<Usuario> ItemSelecionado;
        


        public void CarregarDados()
        {
            dataGridView1.Rows.Clear();
            string usuarios = File.ReadAllText ("C:\\Users\\user\\Desktop\\Teste\\usuarios.json");
            foreach (Usuario usuario in usuarios.Deserialize<List<Usuario>>())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1, usuario.Codigo, usuario.Nome, usuario.Login, usuario.Tipo);
                row.Tag = usuario;
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
