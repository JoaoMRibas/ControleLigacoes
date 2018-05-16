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
    public partial class CadStatus : Form
    {
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
                //instancia.Usuario = 
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
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            EnviarInfo();
            Limpar();
        }
    }


}
