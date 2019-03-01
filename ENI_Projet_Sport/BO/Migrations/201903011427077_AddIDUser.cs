namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIDUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "OwnerID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "OwnerID");
        }
    }
}
