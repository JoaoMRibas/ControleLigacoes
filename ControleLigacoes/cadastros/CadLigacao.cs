using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

    public partial class CadLigacao : Form
    {


        public CadLigacao()
        {
            InitializeComponent();
            DtGvStatus.AutoGenerateColumns = true;
            DtGvStatus.MultiSelect = false;
            DtGvStatus.AllowUserToDeleteRows = false;
            DtGvStatus.ReadOnly = true;
            DtGvStatus.RowHeadersVisible = false;
            DtGvStatus.AllowUserToAddRows = false;
            DtGvStatus.AllowUserToResizeRows = false;
            DtGvStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtGvStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            if (typeof(HistoricoStatus) == typeof(HistoricoStatus))
            {

                CreateCells = obj =>
                {

                    HistoricoStatus historicoStatus = obj as HistoricoStatus;

                    if (historicoStatus == null)
                    {
                        return null;

                    }

                    return new object[]
                    {
                        
                        historicoStatus.Ligacao.Codigo, historicoStatus.Usuario.Nome, historicoStatus.DataHora,
                        historicoStatus.Status
                    };
                };
                Carregar = () =>
                {
                    using (LigacoesContext context = new LigacoesContext())
                    {
                        List<HistoricoStatus> list = context.HistoricosStatus.Include(nameof(HistoricoStatus.Usuario))
                            .Include(nameof(HistoricoStatus.Ligacao)).OfType<HistoricoStatus>().ToList();
                        return list;
                    }
                };

            }

            Cliente.KeyPress += Cliente_KeyPress;

        }

        

        public Menu Menu { get; set; }
        private HistoricoStatus HistoricoAtual { get; set; }
        

        public void LimparCampos()
        {
            Codigo.Clear();
            DataHora.Clear();
            Cliente.Clear();
            Observacoes.Clear();
            LigacaoAtual = null;
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
            

            using (LigacoesContext context = new LigacoesContext())
            {
                Ligacao instancia = LigacaoAtual == null
                    ? null
                    : context.Ligacoes.FirstOrDefault(c => c.Id.Equals(LigacaoAtual.Id));



                bool isInsert = false;
                if (instancia == null)
                {
                    isInsert = true;
                    instancia = new Ligacao();
                    instancia.Id = Guid.NewGuid();

                }

                instancia.Codigo = 1;
                if (UsuarioLogado is Usuario usuario)
                {
                    instancia.Usuario = new Usuario { Id = usuario.Id };
                    context.Usuarios.Attach(instancia.Usuario);
                }
                instancia.Cliente = Cliente.Tag as Cliente;
                instancia.DataHora = DateTime.Now;
                instancia.Observacoes = Observacoes.Text;




                if (instancia.Cliente != null)
                {
                    context.Clientes.Attach(instancia.Cliente);
                }

                if (instancia.Usuario != null)
                {
                    context.Usuarios.Attach(instancia.Usuario);
                }

                context.Ligacoes.Attach(instancia);
                

                if (isInsert)
                {
                    context.Ligacoes.Add(instancia);
                }

                context.SaveChanges();
            }


            LimparCampos();

        }

        private void Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ConsultaCliente.Exibe();
            }
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

        public void ConsultaClienteItemSelecionado(Cliente obj)
        {

            Cliente.Text = obj.RazaoSocial;
            Cliente.Tag = obj;
        }


        public void ConsultaLigacaoItemSelecionado(Ligacao obj)
        {
            
            LigacaoAtual = obj;
            Codigo.Text = obj.Codigo.ToString();
            DataHora.Text = DateTime.Now.ToString();
            Cliente.Text = obj.Cliente.RazaoSocial;
            Cliente.Tag = obj.Cliente;         
            Observacoes.Text = obj.Observacoes;
            CarregarDados();
 
        }


        public Ligacao LigacaoAtual { get; set; }
        public Usuario UsuarioLogado { get; set; }


        private void BtCliente_Click(object sender, EventArgs e)
        {
            ConsultaCliente.Exibe();
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

        private Func<HistoricoStatus, object[]> CreateCells { get; set; }
        private Func<List<HistoricoStatus>> Carregar { get; set; }


        public void CarregarDados()
        {

            DtGvStatus.Rows.Clear();
            foreach (HistoricoStatus d in Carregar())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DtGvStatus, CreateCells(d));
                row.Tag = d;
                DtGvStatus.Rows.Add(row);
            }

        }


        private void BtStatus_Click(object sender, EventArgs e)
        {

            CadStatus status = new CadStatus();
            status.UsuarioLogado = UsuarioLogado;
            status.LigacaoHist = LigacaoAtual;
            status.ShowDialog();
            if (status.LigacaoHist == null)
            {
                return;
            }
            CarregarDados();

        }
    }
}