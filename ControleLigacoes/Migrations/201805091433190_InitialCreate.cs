namespace ControleLigacoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Clientes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codigo = c.Int(nullable: false),
                        RazaoSocial = c.String(),
                        NomeFantasia = c.String(),
                        Cnpj = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Clientes");
        }
    }
}
