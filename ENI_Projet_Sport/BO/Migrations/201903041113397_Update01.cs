namespace BO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "DisplayConfiguration_Id", "dbo.DisplayConfigurations");
            DropForeignKey("dbo.Races", "Person_Id", "dbo.People");
            DropIndex("dbo.People", new[] { "DisplayConfiguration_Id" });
            DropIndex("dbo.Races", new[] { "Person_Id" });
            AddColumn("dbo.DisplayConfigurations", "TypeUnite", c => c.Int(nullable: false));
            AddColumn("dbo.DisplayConfigurations", "Person_Id", c => c.Int());
            AddColumn("dbo.People", "Race_Id", c => c.Int());
            CreateIndex("dbo.DisplayConfigurations", "Person_Id");
            CreateIndex("dbo.People", "Race_Id");
            AddForeignKey("dbo.DisplayConfigurations", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.People", "Race_Id", "dbo.Races", "Id");
            DropColumn("dbo.DisplayConfigurations", "UnitDistance_Speed");
            DropColumn("dbo.DisplayConfigurations", "UnitDistance_TypeUnite");
            DropColumn("dbo.People", "DisplayConfiguration_Id");
            DropColumn("dbo.Races", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Races", "Person_Id", c => c.Int());
            AddColumn("dbo.People", "DisplayConfiguration_Id", c => c.Int());
            AddColumn("dbo.DisplayConfigurations", "UnitDistance_TypeUnite", c => c.Int(nullable: false));
            AddColumn("dbo.DisplayConfigurations", "UnitDistance_Speed", c => c.Double(nullable: false));
            DropForeignKey("dbo.People", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.DisplayConfigurations", "Person_Id", "dbo.People");
            DropIndex("dbo.People", new[] { "Race_Id" });
            DropIndex("dbo.DisplayConfigurations", new[] { "Person_Id" });
            DropColumn("dbo.People", "Race_Id");
            DropColumn("dbo.DisplayConfigurations", "Person_Id");
            DropColumn("dbo.DisplayConfigurations", "TypeUnite");
            CreateIndex("dbo.Races", "Person_Id");
            CreateIndex("dbo.People", "DisplayConfiguration_Id");
            AddForeignKey("dbo.Races", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.People", "DisplayConfiguration_Id", "dbo.DisplayConfigurations", "Id");
        }
    }
}
