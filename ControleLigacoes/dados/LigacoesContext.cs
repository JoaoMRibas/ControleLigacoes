using System.Data.Entity;

namespace ControleLigacoes.dados
{
    public class LigacoesContext : DbContext
    {
        public LigacoesContext() : base(nameOrConnectionString: "Postgres") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ligacao> Ligacoes { get; set; }
    }
}
