namespace MVCBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreplymodel01 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Replies", name: "Creater_Id", newName: "Replier_Id");
            RenameIndex(table: "dbo.Replies", name: "IX_Creater_Id", newName: "IX_Replier_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Replies", name: "IX_Replier_Id", newName: "IX_Creater_Id");
            RenameColumn(table: "dbo.Replies", name: "Replier_Id", newName: "Creater_Id");
        }
    }
}
