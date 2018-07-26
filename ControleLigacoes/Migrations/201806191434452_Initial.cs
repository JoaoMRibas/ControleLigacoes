namespace ControleLigacoes.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Clientes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codigo = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(),
                        NomeFantasia = c.String(),
                        Cnpj = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.HistoricoStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DataHora = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Ligacao_Id = c.Guid(),
                        Usuario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Ligacaos", t => t.Ligacao_Id)
                .ForeignKey("public.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Ligacao_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "public.Ligacaos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codigo = c.Int(nullable: false, identity: true),
                        DataHora = c.DateTime(nullable: false),
                        Observacoes = c.String(),
                        Cliente_Id = c.Guid(),
                        Usuario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Clientes", t => t.Cliente_Id)
                .ForeignKey("public.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "public.Usuarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.HistoricoStatus", "Usuario_Id", "public.Usuarios");
            DropForeignKey("public.HistoricoStatus", "Ligacao_Id", "public.Ligacaos");
            DropForeignKey("public.Ligacaos", "Usuario_Id", "public.Usuarios");
            DropForeignKey("public.Ligacaos", "Cliente_Id", "public.Clientes");
            DropIndex("public.Ligacaos", new[] { "Usuario_Id" });
            DropIndex("public.Ligacaos", new[] { "Cliente_Id" });
            DropIndex("public.HistoricoStatus", new[] { "Usuario_Id" });
            DropIndex("public.HistoricoStatus", new[] { "Ligacao_Id" });
            DropTable("public.Usuarios");
            DropTable("public.Ligacaos");
            DropTable("public.HistoricoStatus");
            DropTable("public.Clientes");
        }
    }
}
