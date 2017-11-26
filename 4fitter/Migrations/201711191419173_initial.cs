namespace _4fitter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "RawTags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "RawTags", c => c.String(nullable: false));
        }
    }
}
