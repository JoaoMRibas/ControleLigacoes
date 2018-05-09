using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLigacoes.dados
{
    public class HistoricoStatus
    {
        public Guid Id { get; set; }
        public Guid _idLigacao;
        public Guid _idUsuario;

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

        public Guid IdUsuario
        {
            get => _idUsuario;
            set
            {
                _idUsuario = value;
                if (IdUsuario.IsEmpty())
                {
                    Usuario = null;
                    return;
                }

                List<Usuario> usuarios = Extensions.CarregarDados<Usuario>();
                Usuario = usuarios.FirstOrDefault(u => IdUsuario.Equals(u.Id));
            }
        }

        public Usuario Usuario { get; set; }
        public Ligacao Ligacao {get; set;}
        public DateTime DataHora { get; set; }
        public OpcoesStatus Status { get; set; }
    }
}
