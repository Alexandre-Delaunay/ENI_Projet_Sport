namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIDUser02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "OwnerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "OwnerID", c => c.String());
        }
    }
}
