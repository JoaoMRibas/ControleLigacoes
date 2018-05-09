using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ControleLigacoes.dados
{
    public class Ligacao
    {
        [Key]
        private Guid _idCliente;
        private Guid _idUsuario;
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public DateTime DataHora { get; set; }

        public Guid IdCliente
        {
            get => _idCliente;
            set
            {
                _idCliente = value;
                if (IdCliente.IsEmpty())
                {
                    Cliente = null;
                    return;
                }

                List<Cliente> clientes = Extensions.CarregarDados<Cliente>();
                Cliente = clientes.FirstOrDefault(c => IdCliente.Equals(c.Id));
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

        public string Observacoes { get; set; }

        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
    }
}
