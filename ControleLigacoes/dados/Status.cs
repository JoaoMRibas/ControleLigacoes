using System;

namespace ControleLigacoes.dados
{
    public class Status
    {
        public Guid Id { get; set; }
        public OpcoesStatus OpcoesStatus { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataHora { get; set; }
    }
}
