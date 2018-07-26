namespace ControleLigacoes.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Hash2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Usuarios", "HashSalt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("public.Usuarios", "HashSalt");
        }
    }
}
