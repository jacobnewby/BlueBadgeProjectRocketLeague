namespace RocketLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Build", "FileName", c => c.String());
            AddColumn("dbo.Build", "FileContent", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Build", "FileContent");
            DropColumn("dbo.Build", "FileName");
        }
    }
}
