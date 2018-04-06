using System;

namespace ControleLigacoes.dados
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public TipoUsuario Tipo { get; set; }

    }
}
