namespace MVCBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublicHoliday : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublicHolidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desc = c.String(),
                        Start_Date = c.String(),
                        End_Date = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PublicHolidays");
        }
    }
}
