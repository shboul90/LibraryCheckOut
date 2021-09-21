namespace LibraryCheckOut.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ICollectionsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checkouts",
                c => new
                    {
                        Checkout_Id = c.Int(nullable: false, identity: true),
                        ID = c.Guid(nullable: false),
                        CheckoutDate = c.DateTime(nullable: false),
                        Member_id = c.Int(nullable: false),
                        TotalNumberOfItems = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Checkout_Id)
                .ForeignKey("dbo.Members", t => t.Member_id, cascadeDelete: true)
                .Index(t => t.Member_id);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Media_Id = c.Int(nullable: false, identity: true),
                        MediaType = c.Int(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                        YearReleased = c.DateTime(nullable: false),
                        Genre = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        InstockQuantity = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        AddedBy = c.String(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Media_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Member_id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Member_id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
                "dbo.MediaCheckouts",
                c => new
                    {
                        Media_Media_Id = c.Int(nullable: false),
                        Checkout_Checkout_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Media_Media_Id, t.Checkout_Checkout_Id })
                .ForeignKey("dbo.Media", t => t.Media_Media_Id, cascadeDelete: true)
                .ForeignKey("dbo.Checkouts", t => t.Checkout_Checkout_Id, cascadeDelete: true)
                .Index(t => t.Media_Media_Id)
                .Index(t => t.Checkout_Checkout_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Checkouts", "Member_id", "dbo.Members");
            DropForeignKey("dbo.MediaCheckouts", "Checkout_Checkout_Id", "dbo.Checkouts");
            DropForeignKey("dbo.MediaCheckouts", "Media_Media_Id", "dbo.Media");
            DropIndex("dbo.MediaCheckouts", new[] { "Checkout_Checkout_Id" });
            DropIndex("dbo.MediaCheckouts", new[] { "Media_Media_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Checkouts", new[] { "Member_id" });
            DropTable("dbo.MediaCheckouts");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Members");
            DropTable("dbo.Media");
            DropTable("dbo.Checkouts");
        }
    }
}
