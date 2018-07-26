using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using ControleLigacoes.consultas;
using ControleLigacoes.dados;
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

        public void Inicializa()
        {
            FormClosed += CadUsuario_FormClosed; 

            foreach (TipoUsuario novotipo in Enum.GetValues(typeof(TipoUsuario)).OfType<TipoUsuario>())
            {
                if (TipoUsuario.NaoInformado.Equals(novotipo))
                {
                    continue;
                }

                Tipo.Items.Add(novotipo);
            }
        }

        private void CadUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            LimparCampos();
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

        private Consulta<Usuario> _consulta;
        public HashWithSaltResult HashWithSalt { get; set; }


        public void Salvar()
        {
            

            if (!Enum.TryParse(Tipo.Text, out TipoUsuario tipo) || !Enum.IsDefined(typeof(TipoUsuario), tipo))
            {
                MessageBox.Show("Não foi possível salvar a informação pois o tipo de usuário não foi selecionado");
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
                    instancia = new Usuario {Id = Guid.NewGuid()};
                    if (SenhaUsuario.Senha == null)
                    {
                        MessageBox.Show("Por favor crie uma senha.");
                        return;
                    }
                }
                
                
                instancia.Nome = Nome.Text;
                if (SenhaUsuario.HashWithSalt == null)
                {
                    instancia.HashSalt = SenhaUsuarioExistente.HashWithSalt.Salt;
                    instancia.HashSenha = SenhaUsuarioExistente.HashWithSalt.Digest;                    
                }
                else
                {
                    instancia.HashSalt = SenhaUsuario.HashWithSalt.Salt;
                    instancia.HashSenha = SenhaUsuario.HashWithSalt.Digest;
                }
                instancia.Login = Login.Text;
                instancia.Tipo = tipo;
                List<Usuario> user = (from us in context.Usuarios where us.Login.Equals(instancia.Login) select us).ToList();
                if (user.Any())
                {
                    MessageBox.Show("O login digitado já existe, por favor crie outro");
                    return;
                }

                if (isInsert)
                {
                    context.Usuarios.Add(instancia);

                }


                context.SaveChanges();
            }

            LimparCampos();

        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            Salvar();
          
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
        public Usuario Instancia { get; set; }

        public void Consulta_ItemSelecionado(Usuario obj)
        {
            PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
            HashWithSalt = pwHasher.HashWithSalt(obj.HashSenha, 64, SHA512.Create());
            HashWithSaltResult hashWithSaltResult = new HashWithSaltResult(HashWithSalt.Salt, HashWithSalt.Digest);
            UsuarioAtual = obj;
            Codigo.Text = obj.Codigo.ToString();
            hashWithSaltResult.Digest = obj.HashSenha;
            hashWithSaltResult.Salt = obj.HashSalt;
            HashWithSalt = hashWithSaltResult;
            Nome.Text = obj.Nome;
            Login.Text = obj.Login;
            Tipo.SelectedItem = obj.Tipo;

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            ConsultaUsuario.Exibe();   
        }

        private SenhaUsuario _senhaUsuario;

        private SenhaUsuario SenhaUsuario => _senhaUsuario ?? (_senhaUsuario = new SenhaUsuario());

        private SenhaUsuarioExistente _senhaUsuarioExistente;

        private SenhaUsuarioExistente SenhaUsuarioExistente => _senhaUsuarioExistente ?? (_senhaUsuarioExistente = new SenhaUsuarioExistente());


        private void IniciaCadSenha()
        {
            SenhaUsuario.HashWithSalt = UsuarioAtual == null ? null : new HashWithSaltResult(UsuarioAtual.HashSalt, UsuarioAtual.HashSenha);
            SenhaUsuarioExistente.HashWithSalt = UsuarioAtual == null ? null : new HashWithSaltResult(UsuarioAtual.HashSalt, UsuarioAtual.HashSenha);
            if (UsuarioAtual == null)
            {
                SenhaUsuario.Exibe();
            }
            else
            {
                SenhaUsuarioExistente.Exibe();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {  
            IniciaCadSenha();  
        }
    }
}