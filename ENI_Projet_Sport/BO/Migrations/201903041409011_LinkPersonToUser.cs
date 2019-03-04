namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkPersonToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.People", "User_Id");
            AddForeignKey("dbo.People", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.People", new[] { "User_Id" });
            DropColumn("dbo.People", "User_Id");
        }
    }
}
