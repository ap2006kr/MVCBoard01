namespace MVCBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CHGDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boards", "Created", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boards", "Created", c => c.DateTime(nullable: false));
        }
    }
}
