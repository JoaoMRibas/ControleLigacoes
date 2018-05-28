using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    public partial class CadStatus : Form
    {
        private Consulta<Usuario> _consultaUsuario;
        private Consulta<Ligacao> _consultaLigacao;
        
        private CadUsuario _consulta;
        public CadStatus()
        {
            InitializeComponent();
            Inicializa();
        }

        public void Inicializa()
        {
            foreach (OpcoesStatus novaOpcao in Enum.GetValues(typeof(OpcoesStatus)).OfType<OpcoesStatus>())
            {
                if (OpcoesStatus.NaoInformado.Equals(novaOpcao))
                {
                    continue;
                }

                OpcaoStatus.Items.Add(novaOpcao);
            }
        }

        public void Limpar()
        {
            OpcaoStatus.SelectedItem = null;
            Usuario.Clear();
            Ligacao.Clear();
        }

        public void EnviarInfo()
        {

            
            if (!Enum.TryParse(OpcaoStatus.Text, out OpcoesStatus opcao) ||
                !Enum.IsDefined(typeof(OpcoesStatus), opcao))
            {
                MessageBox.Show("Não foi possível salvar a informação o campo informado não é válido");
                return;
            }

            HistoricoStatus instancia = new HistoricoStatus();
            

            instancia.Status = opcao;

            using (LigacoesContext context = new LigacoesContext())
            {

                Ligacao ligacao = Ligacao.Tag as Ligacao;
                //if (ligacao != null)
                //{
                //    context.Ligacoes.Attach(ligacao);
                //}

                Usuario usuario = Usuario.Tag as Usuario;
                //if (usuario != null)
                //{
                //    context.Usuarios.Attach(usuario);
                //}

                instancia.Id = Guid.NewGuid();
                instancia.DataHora = DateTime.Now;
                instancia.Usuario = usuario;
                instancia.Ligacao = ligacao;

                //context.HistoricosStatus.Add(instancia);

                context.HistoricosStatus.Attach(instancia);

                context.SaveChanges();
                Limpar();
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


        public void ConsultaUsuarioItemSelecionado(Usuario obj)
        {

            Usuario.Text = obj.Nome;
            Usuario.Tag = obj;
        }

        public void ConsultaLigacaoItemSelecionado(Ligacao obj)
        {
            Ligacao.Text = obj.Codigo.ToString();
            Ligacao.Tag = obj;

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            EnviarInfo();
            Limpar();
        }

        private void BtUsuario_Click(object sender, EventArgs e)
        {
            ConsultaUsuario.Exibe();
        }

        private void BtnLigacao_Click(object sender, EventArgs e)
        {
            ConsultaLigacao.Exibe();
        }
    }


}
