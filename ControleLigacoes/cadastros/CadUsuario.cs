using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using ControleLigacoes.consultas;
using ControleLigacoes.dados;

namespace ControleLigacoes.cadastros
{
    public partial class CadUsuario : Form
    {


        public CadUsuario()
        {
            InitializeComponent();
            Inicializa();

        }


        public void Inicializa()
        {

            foreach (TipoUsuario novotipo in Enum.GetValues(typeof(TipoUsuario)).OfType<TipoUsuario>())
            {
                Tipo.Items.Add(novotipo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {

            //coloca aqui os teus text pra limpar
            Codigo.Clear();
            Nome.Clear();
            Login.Clear();
            Senha.Clear();


        }

        public FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        //Irá armazenar o diretório recebido pelo folderDialog
        public string diretorio;

        //Arquivo de escrita 
        public TextWriter arquivo;
        private ConsultaUsuario _consulta;

        public void EnviarInfo()
        {
            if (!int.TryParse(Codigo.Text, out int cod))
            {
                MessageBox.Show("Não foi possível salvar a informação, pois o campo código não permite letras");
                return;
            }

            if (!Enum.TryParse(Tipo.Text, out TipoUsuario tipo) || !Enum.IsDefined(typeof(TipoUsuario), tipo))
            {
                MessageBox.Show("Não foi possível salvar a informação o campo informado não é válido");
                return;
            }

            if (tipo == TipoUsuario.NaoInformado)
            {
                MessageBox.Show("Não foi possível salvar pois 'não informado' não é uma opção válida ");
            }

            Usuario instancia = new Usuario();
            instancia.Id = Guid.NewGuid();
            instancia.Codigo = cod;
            instancia.Nome = Nome.Text;
            instancia.Login = Login.Text;
            instancia.Senha = Senha.Text;
            instancia.Tipo = tipo;

            List<Usuario> usuarios;
            string filePath = diretorio + "\\usuarios.json";
            if (File.Exists(filePath))
            {
                string txt = File.ReadAllText(diretorio + "\\usuarios.json");
                usuarios = txt.Deserialize<List<Usuario>>();
            }
            else
            {
                usuarios = new List<Usuario>();
            }

            
            usuarios = usuarios.Where(u =>{return instancia.Id != u.Id; }).ToList();
            usuarios.Add(instancia);
            

            string usuariosTxt = usuarios.Serialize();
            File.WriteAllText(filePath, usuariosTxt); 
            

        }

   


        public void criarArquivo()
        {
            try
            {
                //Determino o diretorio onde será salvo o arquivo
                string nome_arquivo = diretorio + "\\textBox.txt";

                //verificamos se o arquivo existe, se não existir então criamos o arquivo
                if (!File.Exists(nome_arquivo))
                    File.Create(nome_arquivo).Close();

                // crio a variavel responsável por gravar os dados no arquivo txt
                arquivo = File.AppendText(nome_arquivo);

                //Escrevo no arquivo txt os dados contidos no textbox
                arquivo.Write(Codigo.Text);
                arquivo.Write(Nome.Text);
                arquivo.Write(Login.Text);
                arquivo.Write(Senha.Text);
                arquivo.Write(Tipo.Text);
                //Posiciono o ponteiro na próxima linha do arquivo.
                arquivo.Write("\r\n");

                MessageBox.Show("Dados salvos com sucesso!!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                //Fecho o arquivo
                arquivo.Close();
            }
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
            //criarArquivo();
            EnviarInfo();
            LimparCampos();
        }

        private ConsultaUsuario Consulta
        {
            get
            {
                if (_consulta == null)
                {
                  _consulta = new ConsultaUsuario();
                  _consulta.ItemSelecionado += Consulta_ItemSelecionado; 
                }
                return _consulta;

                
            }
        }

       


        public void Consulta_ItemSelecionado(Usuario obj)
        {
            CadUsuario link2 = new CadUsuario();
            link2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Consulta.Exibe();
        }
  
    }
}


