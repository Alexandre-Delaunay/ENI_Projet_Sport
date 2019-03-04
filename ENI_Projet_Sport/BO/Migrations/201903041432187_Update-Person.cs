namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePerson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
