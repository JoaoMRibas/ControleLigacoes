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
    public partial class CadLigacao : Form
    {
        public CadLigacao()
        {
            InitializeComponent();
        }

        public void LimparCampos()
        {
            Codigo.Clear();
            DataHora.Clear();
            Usuario.Clear();
            Cliente.Clear();
            Observacoes.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        //Irá armazenar o diretório recebido pelo folderDialog
        public string diretorio = "C:\\Users\\user\\Desktop\\Teste";

        //Arquivo de escrita 
        public TextWriter arquivo;
        private Consulta<Ligacao> _consulta;
        public void EnviarInfo()
        {
            if (!int.TryParse(Codigo.Text, out int cod))
            {
                MessageBox.Show("Não foi possível salvar a informação, pois o campo código não permite letras");
                return;
            }

            Usuario instancia = new Usuario();

            //se  for o 1 caso então cria um Id novo
            //se for o 2 caso então mantém o mesmo Id
            if (UsuarioAtual == null)
            {
                instancia.Id = Guid.NewGuid();
            }

            if (UsuarioAtual != null)
            {
                instancia.Id = UsuarioAtual.Id;

            }


            instancia.Codigo = cod;
            instancia.Usuario = Nome.Text;
            instancia.Login = Login.Text;
            instancia.Senha = Senha.Text;
            instancia.Tipo = tipo;





            List<Usuario> usuarios;
            string filePath = diretorio + "\\ligacoes.json";
            if (File.Exists(filePath))
            {
                string txt = File.ReadAllText(diretorio + "\\ligacoes.json");
                usuarios = txt.Deserialize<List<Usuario>>();
            }
            else
            {
                usuarios = new List<Usuario>();
            }



            usuarios = usuarios.Where(u => { return instancia.Id != u.Id; }).ToList();
            usuarios.Add(instancia);
            string usuariosTxt = usuarios.Serialize();
            File.WriteAllText(filePath, usuariosTxt);
            LimparCampos();

        }
    }
}
