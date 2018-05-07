using System;

namespace ControleLigacoes.dados
{
    public class Ligacao
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public DateTime DataHora { get; set; }
        public Cliente  Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public string Observacoes { get; set; }


    }
}
