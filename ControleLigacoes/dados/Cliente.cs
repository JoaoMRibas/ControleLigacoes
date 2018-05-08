using System;

namespace ControleLigacoes.dados
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }


}
