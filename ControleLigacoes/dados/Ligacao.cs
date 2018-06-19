using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleLigacoes.dados
{
    public class Ligacao
    {
        public Guid Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        public DateTime DataHora { get; set; }
        public string Observacoes { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
    }
}
