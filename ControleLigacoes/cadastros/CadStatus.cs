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
        public Ligacao LigacaoHist { get; set; }
        public Usuario UsuarioLogado { get; set; }

        
        private CadUsuario _consulta;
        public CadStatus()
        {
            InitializeComponent();
            Inicializa();    
        }

        public Menu Menu { get; set; }

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
                instancia.DataHora = DateTime.Now;

                if (UsuarioLogado is Usuario usuario)
                {
                    instancia.Usuario = new Usuario {Id = usuario.Id};
                    context.Usuarios.Attach(instancia.Usuario);
                }

                
                if (LigacaoHist != null)
                {
                    
                    instancia.Ligacao = new Ligacao { Id = LigacaoHist.Id };
                    context.Ligacoes.Attach(instancia.Ligacao);
                }

                if (LigacaoHist == null)
                {
                    MessageBox.Show("Selecione uma ligação antes de salvar o status.");
                    Limpar();
                    Close();
                    return;
                }

                context.HistoricosStatus.Add(instancia);
                context.SaveChanges();
                Limpar();
                Close();
                
            }
        }
 
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            EnviarInfo();
        }
        
    }

}
