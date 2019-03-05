namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDisplayConfigurationPersonAspNetUser : DbMigration
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
                        TypeUnite = c.Int(nullable: false),
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
                        BirthDate = c.DateTime(),
                        DateMAJ = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Name = c.String(nullable: false, maxLength: 50),
                        DateMAJ = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        displayConfiguration_Id = c.Int(),
                        person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DisplayConfigurations", t => t.displayConfiguration_Id)
                .ForeignKey("dbo.People", t => t.person_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.displayConfiguration_Id)
                .Index(t => t.person_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RacePersons",
                c => new
                    {
                        Race_Id = c.Int(nullable: false),
                        Person_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Race_Id, t.Person_Id })
                .ForeignKey("dbo.Races", t => t.Race_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Race_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "person_Id", "dbo.People");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "displayConfiguration_Id", "dbo.DisplayConfigurations");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.POIs", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.POIs", "CategoryPOI_Id", "dbo.CategoryPOIs");
            DropForeignKey("dbo.RacePersons", "Person_Id", "dbo.People");
            DropForeignKey("dbo.RacePersons", "Race_Id", "dbo.Races");
            DropIndex("dbo.RacePersons", new[] { "Person_Id" });
            DropIndex("dbo.RacePersons", new[] { "Race_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "person_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "displayConfiguration_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.POIs", new[] { "Race_Id" });
            DropIndex("dbo.POIs", new[] { "CategoryPOI_Id" });
            DropTable("dbo.RacePersons");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RaceTypes");
            DropTable("dbo.POIs");
            DropTable("dbo.Races");
            DropTable("dbo.People");
            DropTable("dbo.DisplayConfigurations");
            DropTable("dbo.CategoryPOIs");
        }
    }
}
