namespace ControleLigacoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.Ligacaos", "IdCliente");
            DropColumn("public.Ligacaos", "IdUsuario");
        }
        
        public override void Down()
        {
            AddColumn("public.Ligacaos", "IdUsuario", c => c.Guid(nullable: false));
            AddColumn("public.Ligacaos", "IdCliente", c => c.Guid(nullable: false));
        }
    }
}
