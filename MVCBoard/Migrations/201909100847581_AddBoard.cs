namespace MVCBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBoard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Created = c.DateTime(nullable: false),
                        Creater_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Creater_Id)
                .Index(t => t.Creater_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boards", "Creater_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Boards", new[] { "Creater_Id" });
            DropTable("dbo.Boards");
        }
    }
}
