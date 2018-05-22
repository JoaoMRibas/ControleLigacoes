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
    public partial class CadStatus : Form
    {
        private Consulta<Usuario> _consultaUsuario;
        
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
        }

        
        private Ligacao LigacaoAtual { get; set; }

        public void ConsultaLigacaoItemSelecionado(Ligacao obj)
        {
            LigacaoAtual = obj;
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


                instancia.Id = Guid.NewGuid();
                instancia.Usuario = Usuario.Tag as Usuario;
                instancia.DataHora = DateTime.Now;

                if (instancia.Ligacao != null)
                {
                    context.Ligacoes.Attach(instancia.Ligacao);
                }
                
                if (instancia.Usuario != null)
                {
                    context.Usuarios.Attach(instancia.Usuario);
                }
                
                
               

                context.HistoricosStatus.Add(instancia);
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

        public void ConsultaUsuarioItemSelecionado(Usuario obj)
        {

            Usuario.Text = obj.Nome;
            Usuario.Tag = obj;
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
    }


}
