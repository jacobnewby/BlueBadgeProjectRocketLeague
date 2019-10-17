namespace RocketLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Build",
                c => new
                    {
                        BuildID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        BuildName = c.String(nullable: false),
                        CarID = c.Int(nullable: false),
                        DecalID = c.Int(nullable: false),
                        WheelsID = c.Int(nullable: false),
                        GoalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuildID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Decal", t => t.DecalID, cascadeDelete: true)
                .ForeignKey("dbo.Goal", t => t.GoalID, cascadeDelete: true)
                .ForeignKey("dbo.Wheels", t => t.WheelsID, cascadeDelete: true)
                .Index(t => t.CarID)
                .Index(t => t.DecalID)
                .Index(t => t.WheelsID)
                .Index(t => t.GoalID);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        CarName = c.String(nullable: false),
                        CarColor = c.String(nullable: false),
                        CarRarity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarID);
            
            CreateTable(
                "dbo.Decal",
                c => new
                    {
                        DecalID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        DecalName = c.String(nullable: false),
                        DecalColor = c.String(nullable: false),
                        DecalRarity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DecalID);
            
            CreateTable(
                "dbo.Goal",
                c => new
                    {
                        GoalID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        GoalName = c.String(nullable: false),
                        GoalColor = c.String(nullable: false),
                        GoalRarity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GoalID);
            
            CreateTable(
                "dbo.Wheels",
                c => new
                    {
                        WheelsID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        WheelsName = c.String(nullable: false),
                        WheelsColor = c.String(nullable: false),
                        WheelsRarity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WheelsID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Build", "WheelsID", "dbo.Wheels");
            DropForeignKey("dbo.Build", "GoalID", "dbo.Goal");
            DropForeignKey("dbo.Build", "DecalID", "dbo.Decal");
            DropForeignKey("dbo.Build", "CarID", "dbo.Car");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Build", new[] { "GoalID" });
            DropIndex("dbo.Build", new[] { "WheelsID" });
            DropIndex("dbo.Build", new[] { "DecalID" });
            DropIndex("dbo.Build", new[] { "CarID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Wheels");
            DropTable("dbo.Goal");
            DropTable("dbo.Decal");
            DropTable("dbo.Car");
            DropTable("dbo.Build");
        }
    }
}
