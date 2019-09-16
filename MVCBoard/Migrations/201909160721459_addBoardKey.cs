namespace MVCBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBoardKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boards", "BoardKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boards", "BoardKey");
        }
    }
}
