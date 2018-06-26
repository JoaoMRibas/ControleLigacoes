namespace ControleLigacoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hash : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Usuarios", "HashSenha", c => c.String());
            DropColumn("public.Usuarios", "Senha");
        }
        
        public override void Down()
        {
            AddColumn("public.Usuarios", "Senha", c => c.String());
            DropColumn("public.Usuarios", "HashSenha");
        }
    }
}
