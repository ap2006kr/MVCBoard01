namespace MVCBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replies", "Board_ID", "dbo.Boards");
            DropIndex("dbo.Replies", new[] { "Board_ID" });
            AddColumn("dbo.Boards", "CreatedTime", c => c.DateTime(nullable:true, defaultValueSql: "GETDATE()"));
            AddColumn("dbo.Replies", "CreatedTime", c => c.DateTime(nullable: true, defaultValueSql: "GETDATE()"));
            DropColumn("dbo.Boards", "Created");
            DropColumn("dbo.Boards", "ReplysId");
            DropColumn("dbo.Replies", "Created");
            DropColumn("dbo.Replies", "Board_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Replies", "Board_ID", c => c.Int());
            AddColumn("dbo.Replies", "Created", c => c.DateTime());
            AddColumn("dbo.Boards", "ReplysId", c => c.Int(nullable: false));
            AddColumn("dbo.Boards", "Created", c => c.DateTime());
            DropColumn("dbo.Replies", "CreatedTime");
            DropColumn("dbo.Boards", "CreatedTime");
            CreateIndex("dbo.Replies", "Board_ID");
            AddForeignKey("dbo.Replies", "Board_ID", "dbo.Boards", "ID");
        }
    }
}
