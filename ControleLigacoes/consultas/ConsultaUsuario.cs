using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void CarregarDados()
        {
            dataGridView1.Rows.Clear();
            string[] usuarios = File.ReadAllLines("C:\\Users\\user\\Desktop\\Teste\\usuarios.json");
            foreach (Usuario usuario in usuarios.Select(us => us.Deserialize<Usuario>()))
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1, usuario.Codigo, usuario.Nome , usuario.Login, usuario.Tipo);
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
