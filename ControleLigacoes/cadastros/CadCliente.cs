using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleLigacoes.consultas;
using ControleLigacoes.dados;
using Maoli;

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
            ClienteAtual = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        public FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        //Irá armazenar o diretório recebido pelo folderDialog
        public string diretorio = "C:\\Users\\user\\Desktop\\Teste";

        //Arquivo de escrita 
        public TextWriter arquivo;
        private Consulta<Cliente> _consulta;


        private void EnviarInfoCliente()
        {
            
            if (!int.TryParse(Codigo.Text, out int cod))
            {
                MessageBox.Show("Não foi possível salvar a informação, pois o campo código não permite letras");
                return;
            }

            string cnpj = Cnpj.Text;

            if (cnpj.Length != 14)
            {
                MessageBox.Show("Não foi possível salvar a informação, pois o campo Cnpj deve conter 14 dígitos");
                return;
            }

            if (cnpj.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Não foi possível salvar a informação, pois o campo Cnpj não permite letras");
                return;
            }

            if (!Maoli.Cnpj.Validate(cnpj))
            {
                MessageBox.Show("Não foi possível salvar a informação, pois não é um Cnpj válido");
                return;
            }





            Cliente instancia = new Cliente();
            if (ClienteAtual == null)
            {
                instancia.Id = Guid.NewGuid();
            }

            if (ClienteAtual != null)
            {
                instancia.Id = ClienteAtual.Id;
            }
            
            instancia.Codigo = cod;
            instancia.RazaoSocial = RazaoSocial.Text;
            instancia.NomeFantasia = NomeFantasia.Text;
            instancia.Cnpj = cnpj;
            instancia.Email = Email.Text;
            instancia.Telefone = Telefone.Text;

            using (LigacoesContext context = new LigacoesContext())
            {

                if (ClienteAtual != null)
                {
                    context.Clientes.
                }
                context.Clientes.Add(instancia);
                context.SaveChanges();

            }

            Limpar();

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

        private Consulta<Cliente> Consultaa
        {
            get
            {
                if (_consulta == null)
                {
                    _consulta = new Consulta<Cliente>();
                    _consulta.ItemSelecionado += Consulta_ItemSelecionado;
                }

                return _consulta;


            }
        }

        private Cliente ClienteAtual { get; set; }



        public void Consulta_ItemSelecionado(Cliente obj)
        {
            ClienteAtual = obj;
            Codigo.Text = obj.Codigo.ToString();
            NomeFantasia.Text = obj.NomeFantasia;
            RazaoSocial.Text = obj.RazaoSocial;
            Cnpj.Text = obj.Cnpj;
            Telefone.Text = obj.Telefone;
            Email.Text = obj.Email;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            EnviarInfoCliente();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Consultaa.Exibe();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ClienteAtual != null)
            {
                using (LigacoesContext context = new LigacoesContext())
                {

                    context.Clientes.Attach(ClienteAtual);
                    context.Clientes.Remove(ClienteAtual);
                    context.SaveChanges();

                }
                Limpar();
            }
        }
    }
}
