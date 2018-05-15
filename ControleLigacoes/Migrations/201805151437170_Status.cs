namespace ControleLigacoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.HistoricoStatus", "Usuario_Id", "public.Usuarios");
            DropForeignKey("public.HistoricoStatus", "Ligacao_Id", "public.Ligacaos");
            DropIndex("public.HistoricoStatus", new[] { "Usuario_Id" });
            DropIndex("public.HistoricoStatus", new[] { "Ligacao_Id" });
            DropTable("public.HistoricoStatus");
        }
    }
}
