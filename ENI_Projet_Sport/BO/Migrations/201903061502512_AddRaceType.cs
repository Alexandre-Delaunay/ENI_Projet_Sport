namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRaceType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Races", new[] { "raceType_Id" });
            CreateIndex("dbo.Races", "RaceType_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Races", new[] { "RaceType_Id" });
            CreateIndex("dbo.Races", "raceType_Id");
        }
    }
}
