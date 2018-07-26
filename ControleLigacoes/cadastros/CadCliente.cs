using System;
using System.Linq;
using System.Windows.Forms;
using ControleLigacoes.consultas;
using ControleLigacoes.dados;

namespace ControleLigacoes.cadastros
{
    public partial class CadCliente : Form
    {
        public CadCliente()
        {
            InitializeComponent();
            Inicializa();
        }

        public void Inicializa()
        {
            FormClosed += CadCliente_FormClosed;

        }

        private void CadCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Limpar();
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

        private Consulta<Cliente> _consulta;

        private void Salvar()
        {


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


            using (LigacoesContext context = new LigacoesContext())
            {

                Cliente instancia = ClienteAtual == null
                    ? null
                    : context.Clientes.FirstOrDefault(c => c.Id.Equals(ClienteAtual.Id));

                bool isInsert = false;
                if (instancia == null)
                {
                    isInsert = true;
                    instancia = new Cliente {Id = Guid.NewGuid()};
                }

                instancia.RazaoSocial = RazaoSocial.Text;
                instancia.NomeFantasia = NomeFantasia.Text;
                instancia.Cnpj = cnpj;
                instancia.Email = Email.Text;
                instancia.Telefone = Telefone.Text;

                {
                    if (isInsert)
                    {
                        context.Clientes.Add(instancia);
                    }

                    context.SaveChanges();

                }

                Limpar();

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
           
            Salvar();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Consultaa.Exibe();
        }

    }
}
