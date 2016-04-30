namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Votes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAlive = c.Boolean(nullable: false),
                        Sex = c.Int(nullable: false),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VoteItems",
                c => new
                    {
                        VoteItemId = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Character_Id = c.Int(),
                        Vote_VoteID = c.Int(),
                    })
                .PrimaryKey(t => t.VoteItemId)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .ForeignKey("dbo.Votes", t => t.Vote_VoteID)
                .Index(t => t.Character_Id)
                .Index(t => t.Vote_VoteID);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        WeekId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoteItems", "Vote_VoteID", "dbo.Votes");
            DropForeignKey("dbo.VoteItems", "Character_Id", "dbo.Characters");
            DropIndex("dbo.VoteItems", new[] { "Vote_VoteID" });
            DropIndex("dbo.VoteItems", new[] { "Character_Id" });
            DropTable("dbo.Votes");
            DropTable("dbo.VoteItems");
            DropTable("dbo.Characters");
        }
    }
}
