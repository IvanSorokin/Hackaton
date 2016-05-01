namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attributes : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Characters", name: "Name", newName: "FirstName");
            AlterColumn("dbo.Characters", "FirstName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Characters", "FirstName", c => c.String());
            RenameColumn(table: "dbo.Characters", name: "FirstName", newName: "Name");
        }
    }
}
