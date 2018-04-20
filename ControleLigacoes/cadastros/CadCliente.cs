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
using ControleLigacoes.dados;

namespace ControleLigacoes.cadastros
{
    public partial class CadCliente : Form
    {
        public CadCliente()
        {
            InitializeComponent();
        }

        private void Limpar()
        {
            Codigo.Clear();
            RazaoSocial.Clear();
            NomeFantasia.Clear();
            Cnpj.Clear();
            Telefone.Clear();
            Email.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        public FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        //Irá armazenar o diretório recebido pelo folderDialog
        public string diretorio;

        //Arquivo de escrita 
        public TextWriter arquivo;


        private void EnviarInfoCliente()
        {

            if (!int.TryParse(Codigo.Text, out int cod))
            {
                MessageBox.Show("Não foi possível salvar a informação, pois o campo código não permite letras");
                return;
            }

            Cliente instancia = new Cliente();
            instancia.Id = Guid.NewGuid();
            instancia.Codigo = cod;
            instancia.RazaoSocial = RazaoSocial.Text;
            instancia.NomeFantasia = NomeFantasia.Text;
            instancia.Cnpj = Cnpj.Text;
            instancia.Email = Email.Text;
            instancia.Telefone = Telefone.Text;

            string json = instancia.Serialize();
            File.AppendAllText(diretorio + "\\clientes.json", json + "\r\n");

        }

        public void interfaceUsuario()
        {

            // titulo a caixa de diágolo do browser que será aberta
            folderDialog.Description = "Selecione o Diretório a ser pesquisado:";

            //Indica o diretório raiz, a partir de onde a caixa de diálogo começará 
            //a exibição dos demais diretórios.
            folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            // elimina a condição de criar uma nova pasta ao abrir a caixa
            // de diálogo do browser
            folderDialog.ShowNewFolderButton = false;

            if (folderDialog.ShowDialog(this) != DialogResult.Cancel)
            {
                //Recupero o diretório da base de dados e o salvo na variavel diretorio
                diretorio = folderDialog.SelectedPath;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            interfaceUsuario();
            EnviarInfoCliente();
        }
    }
}
