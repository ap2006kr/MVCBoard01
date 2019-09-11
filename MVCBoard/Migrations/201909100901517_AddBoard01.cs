namespace MVCBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBoard01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boards", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boards", "Created", c => c.DateTime(nullable: false));
        }
    }
}
