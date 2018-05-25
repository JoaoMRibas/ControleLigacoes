using System;

namespace ControleLigacoes.dados
{
    public class HistoricoStatus
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public Ligacao Ligacao {get; set;}
        public DateTime DataHora { get; set; }
        public OpcoesStatus Status { get; set; }
    }

    
}
