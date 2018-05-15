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
using ControleLigacoes.consultas;
using ControleLigacoes.dados;

namespace ControleLigacoes.cadastros
{
    public partial class BtStatus : Form
    {

        public BtStatus()
        {
            InitializeComponent();
            DtGvStatus.AutoGenerateColumns = true;
            DtGvStatus.MultiSelect = false;
            DtGvStatus.AllowUserToDeleteRows = false;
            DtGvStatus.ReadOnly = true;

        }

        public void LimparCampos()
        {
            Codigo.Clear();
            DataHora.Clear();
            Usuario.Clear();
            Cliente.Clear();
            Observacoes.Clear();
            LigacaoAtual = null;
            Usuario.Tag = null;
            Cliente.Tag = null;
        }

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        //Irá armazenar o diretório recebido pelo folderDialog
        public string diretorio = "C:\\Users\\user\\Desktop\\Teste";

        //Arquivo de escrita 
        public TextWriter arquivo;
        private Consulta<Ligacao> _consultaLigacao;
        private Consulta<Usuario> _consultaUsuario;
        private Consulta<Cliente> _consultaCliente;
        

        public void EnviarInfo()
        {
            if (!int.TryParse(Codigo.Text, out int cod))
            {
                MessageBox.Show("Não foi possível salvar a informação, pois o campo código não permite letras");
                return;
            }

            if (!DateTime.TryParse(DataHora.Text, out DateTime Data))
            {
                MessageBox.Show("Não foi possível salvar a informação pois a data é inválida");
                return;
            }

          
            Ligacao instancia = new Ligacao();

            //se  for o 1 caso então cria um Id novo
            //se for o 2 caso então mantém o mesmo Id
            if (LigacaoAtual == null)
            {
                instancia.Id = Guid.NewGuid();
            }

            if (LigacaoAtual != null)
            {
                instancia.Id = LigacaoAtual.Id;

            }

            
            instancia.Codigo = cod;
            instancia.Usuario = Usuario.Tag as Usuario;
            instancia.Cliente = Cliente.Tag as Cliente;
            instancia.DataHora = Data;
            instancia.Observacoes = Observacoes.Text;


            using (LigacoesContext context = new LigacoesContext())
            {
                if (instancia.Cliente != null)
                {
                    context.Clientes.Attach(instancia.Cliente);
                }

                if (instancia.Usuario != null)
                {
                    context.Usuarios.Attach(instancia.Usuario);
                }
                context.Ligacoes.Add(instancia);
                context.SaveChanges();

            }
            LimparCampos();

        }

        private Consulta<Ligacao> ConsultaLigacao
        {
            get
            {
                if (_consultaLigacao == null)
                {
                    _consultaLigacao = new Consulta<Ligacao>();
                    _consultaLigacao.ItemSelecionado += ConsultaLigacaoItemSelecionado;
                }

                return _consultaLigacao;

            }
        }

        private Consulta<Usuario> ConsultaUsuario
        {
            get
            {
                if (_consultaUsuario == null)
                {
                    _consultaUsuario = new Consulta<Usuario>();
                    _consultaUsuario.ItemSelecionado += ConsultaUsuarioItemSelecionado;
                }

                return _consultaUsuario;
            }

        }

        private Consulta<Cliente> ConsultaCliente
        {
            get
            {
                if (_consultaCliente == null)
                {
                    _consultaCliente = new Consulta<Cliente>();
                    _consultaCliente.ItemSelecionado += ConsultaClienteItemSelecionado;
                }

                return _consultaCliente;
            }

        }

        public void ConsultaUsuarioItemSelecionado(Usuario obj)
        {

            Usuario.Text = obj.Nome;
            Usuario.Tag = obj;
        }

        public void ConsultaClienteItemSelecionado(Cliente obj)
        {

            Cliente.Text = obj.RazaoSocial;
            Cliente.Tag = obj;
        }


        public void ConsultaLigacaoItemSelecionado(Ligacao obj)
        {
            LigacaoAtual = obj;
            Codigo.Text = obj.Codigo.ToString();
            DataHora.Text = obj.DataHora.ToString();
            Cliente.Text = obj.Cliente.RazaoSocial;
            Cliente.Tag = obj.Cliente;
            Usuario.Text = obj.Usuario.Nome;
            Usuario.Tag = obj.Usuario;            
            Observacoes.Text = obj.Observacoes;
 
        }


        private Ligacao LigacaoAtual { get; set; }



        private void BtCliente_Click(object sender, EventArgs e)
        {
            ConsultaCliente.Exibe();
        }

        private void BtUsuario_Click(object sender, EventArgs e)
        {
            ConsultaUsuario.Exibe();
        }

        private void BtPesquisar_Click(object sender, EventArgs e)
        {
            ConsultaLigacao.Exibe();   
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            EnviarInfo();
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (LigacaoAtual != null)
            {
                using (LigacoesContext context = new LigacoesContext())
                {

                    context.Ligacoes.Attach(LigacaoAtual);
                    context.Ligacoes.Remove(LigacaoAtual);
                    context.SaveChanges();

                }
                LimparCampos();
            }
        }

        public HistoricoStatus Historico { get; set; }

        private void BtStatus_Click(object sender, EventArgs e)
        {
            CadStatus status = new CadStatus();
            status.ShowDialog();
        }
    }
}

