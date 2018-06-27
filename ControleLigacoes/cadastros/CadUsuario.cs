using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ControleLigacoes.consultas;
using ControleLigacoes.dados;
using System.Text;
using ControleLigacoes.dados.password;


namespace ControleLigacoes.cadastros
{

    public partial class CadUsuario : Form
    {
        
        public CadUsuario()
        {
            InitializeComponent();
            Inicializa();

        }

        public Menu Menu { get; set; }

        public void Inicializa()
        {

            foreach (TipoUsuario novotipo in Enum.GetValues(typeof(TipoUsuario)).OfType<TipoUsuario>())
            {
                if (TipoUsuario.NaoInformado.Equals(novotipo))
                {
                    continue;
                }

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
            Tipo.SelectedItem = null;
            UsuarioAtual = null;

        }

        public FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        //Irá armazenar o diretório recebido pelo folderDialog
        public string diretorio = "C:\\Users\\user\\Desktop\\Teste";

        //Arquivo de escrita 
        public TextWriter arquivo;
        private Consulta<Usuario> _consulta;

        


        public void EnviarInfo()
        {
            

            if (!Enum.TryParse(Tipo.Text, out TipoUsuario tipo) || !Enum.IsDefined(typeof(TipoUsuario), tipo))
            {
                MessageBox.Show("Não foi possível salvar a informação o campo informado não é válido");
                return;
            }

            if (TipoUsuario.NaoInformado.Equals(tipo))
            {
                MessageBox.Show("Não foi possível salvar pois 'não informado' não é uma opção válida ");
                return;
            }


            using (LigacoesContext context = new LigacoesContext())
            {

                Usuario instancia = UsuarioAtual == null
                    ? null
                    : context.Usuarios.FirstOrDefault(c => c.Id.Equals(UsuarioAtual.Id));

                bool isInsert = false;
                
                if (instancia == null)
                {
                    isInsert = true;
                    instancia = new Usuario();
                    instancia.Id = Guid.NewGuid();
                }

                instancia.Nome = Nome.Text;
                instancia.Login = Login.Text;
                instancia.Tipo = tipo;

                if (isInsert)
                {
                    context.Usuarios.Add(instancia);

                }

                context.SaveChanges();
            }

            LimparCampos();

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
            //interfaceUsuario();
            //criarArquivo();
            EnviarInfo();
            
        }

        private Consulta<Usuario> ConsultaUsuario
        {
            get
            {
                if (_consulta == null)
                {
                    _consulta = new Consulta<Usuario>();
                    _consulta.ItemSelecionado += Consulta_ItemSelecionado;
                }

                return _consulta;


            }
        }

        private Usuario UsuarioAtual { get; set; }
        public Usuario UsuarioLogado { get; set; }


        public void Consulta_ItemSelecionado(Usuario obj)
        {
            UsuarioAtual = obj;
            Codigo.Text = obj.Codigo.ToString();
            Nome.Text = obj.Nome;
            Login.Text = obj.Login;
            Tipo.SelectedItem = obj.Tipo;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultaUsuario.Exibe();   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (UsuarioAtual != null)
            {
                using (LigacoesContext context = new LigacoesContext())
                {

                    context.Usuarios.Attach(UsuarioAtual);
                    context.Usuarios.Remove(UsuarioAtual);
                    context.SaveChanges();

                }
                LimparCampos();
            }
        }
        public SenhaUsuario SenhaUsuario { get; set; }

        private void IniciaCadSenha()
        {
            if (SenhaUsuario == null)
            {

                SenhaUsuario = new SenhaUsuario();
                SenhaUsuario.UsuarioLogado = UsuarioLogado;
                SenhaUsuario.UsuarioAtual = UsuarioAtual;
                SenhaUsuario.ShowDialog();

            }

            else
            {

                SenhaUsuario = SenhaUsuario;
                SenhaUsuario.UsuarioLogado = UsuarioLogado;
                SenhaUsuario.UsuarioAtual = UsuarioAtual;
                SenhaUsuario.ShowDialog();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            IniciaCadSenha();
            
        }
    }
}