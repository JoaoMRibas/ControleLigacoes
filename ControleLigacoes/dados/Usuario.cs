using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace ControleLigacoes.dados
{
    public class Usuario
    {
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string HashSenha { get; set; }
        public string HashSalt { get; set; }
        public TipoUsuario Tipo { get; set; }

        
    }
}
