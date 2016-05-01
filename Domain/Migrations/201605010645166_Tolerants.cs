namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tolerants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "LifeStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Characters", "IsAlive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "IsAlive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Characters", "LifeStatus");
        }
    }
}
