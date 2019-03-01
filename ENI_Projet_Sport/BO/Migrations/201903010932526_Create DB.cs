namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryPOIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DateMAJ = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DisplayConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitDistance_Speed = c.Double(nullable: false),
                        UnitDistance_TypeUnite = c.Int(nullable: false),
                        DateMAJ = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        PhoneNumber = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        DateMAJ = c.DateTime(nullable: false),
                        DisplayConfiguration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DisplayConfigurations", t => t.DisplayConfiguration_Id)
                .Index(t => t.DisplayConfiguration_Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        PlacesNumber = c.Int(nullable: false),
                        City = c.String(maxLength: 50),
                        ZipCode = c.String(),
                        Price = c.Single(nullable: false),
                        Description = c.String(maxLength: 200),
                        DateMAJ = c.DateTime(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.POIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        DateMAJ = c.DateTime(nullable: false),
                        CategoryPOI_Id = c.Int(),
                        Race_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryPOIs", t => t.CategoryPOI_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .Index(t => t.CategoryPOI_Id)
                .Index(t => t.Race_Id);
            
            CreateTable(
                "dbo.RaceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DateMAJ = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Races", "Person_Id", "dbo.People");
            DropForeignKey("dbo.POIs", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.POIs", "CategoryPOI_Id", "dbo.CategoryPOIs");
            DropForeignKey("dbo.People", "DisplayConfiguration_Id", "dbo.DisplayConfigurations");
            DropIndex("dbo.POIs", new[] { "Race_Id" });
            DropIndex("dbo.POIs", new[] { "CategoryPOI_Id" });
            DropIndex("dbo.Races", new[] { "Person_Id" });
            DropIndex("dbo.People", new[] { "DisplayConfiguration_Id" });
            DropTable("dbo.RaceTypes");
            DropTable("dbo.POIs");
            DropTable("dbo.Races");
            DropTable("dbo.People");
            DropTable("dbo.DisplayConfigurations");
            DropTable("dbo.CategoryPOIs");
        }
    }
}
