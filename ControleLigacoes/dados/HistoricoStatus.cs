using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLigacoes.dados
{
    class HistoricoStatus
    {
        public Guid Id { get; set; }
        public Guid _idLigacao;


        public Guid IdLigacao
        {
            get => _idLigacao;
            set
            {
                _idLigacao = value;
                if (IdLigacao.IsEmpty())
                {
                    Ligacao = null;
                    return;
                }

                List<Ligacao> ligacao = Extensions.CarregarDados<Ligacao>();
                Ligacao = ligacao.FirstOrDefault(l => IdLigacao.Equals(l.Id));
            }
        }

        public Ligacao Ligacao {get; set;}
        public DateTime DataHora { get; set; }
        public string Status { get; set; }
    }
}
