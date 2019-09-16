namespace MVCBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreplymodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Created = c.DateTime(),
                        Creater_Id = c.String(maxLength: 128),
                        Board_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Creater_Id)
                .ForeignKey("dbo.Boards", t => t.Board_ID)
                .Index(t => t.Creater_Id)
                .Index(t => t.Board_ID);
            
            AddColumn("dbo.Boards", "ReplysId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "Board_ID", "dbo.Boards");
            DropForeignKey("dbo.Replies", "Creater_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Replies", new[] { "Board_ID" });
            DropIndex("dbo.Replies", new[] { "Creater_Id" });
            DropColumn("dbo.Boards", "ReplysId");
            DropTable("dbo.Replies");
        }
    }
}
