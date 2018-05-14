namespace ControleLigacoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ligacoesUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Ligacaos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codigo = c.Int(nullable: false),
                        DataHora = c.DateTime(nullable: false),
                        IdCliente = c.Guid(nullable: false),
                        IdUsuario = c.Guid(nullable: false),
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
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Ligacaos", "Usuario_Id", "public.Usuarios");
            DropForeignKey("public.Ligacaos", "Cliente_Id", "public.Clientes");
            DropIndex("public.Ligacaos", new[] { "Usuario_Id" });
            DropIndex("public.Ligacaos", new[] { "Cliente_Id" });
            DropTable("public.Usuarios");
            DropTable("public.Ligacaos");
        }
    }
}
