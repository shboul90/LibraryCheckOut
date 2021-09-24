namespace LibraryCheckOut.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checkout",
                c => new
                    {
                        Checkout_Id = c.Int(nullable: false, identity: true),
                        ID = c.Guid(nullable: false),
                        CheckoutDate = c.DateTime(nullable: false),
                        Member_id = c.Int(nullable: false),
                        TotalNumberOfItems = c.Int(nullable: false),
                        Media_Media_Id = c.Int(),
                        Media_Media_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Checkout_Id)
                .ForeignKey("dbo.Media", t => t.Media_Media_Id)
                .ForeignKey("dbo.Media", t => t.Media_Media_Id1)
                .ForeignKey("dbo.Member", t => t.Member_id, cascadeDelete: true)
                .Index(t => t.Member_id)
                .Index(t => t.Media_Media_Id)
                .Index(t => t.Media_Media_Id1);
            
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
                        Checkout_Checkout_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Media_Id)
                .ForeignKey("dbo.Checkout", t => t.Checkout_Checkout_Id)
                .Index(t => t.Checkout_Checkout_Id);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Member_id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        DateOfMembership = c.DateTime(nullable: false),
                        MembershipRating = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Member_id);
            
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
            DropForeignKey("dbo.Checkout", "Member_id", "dbo.Member");
            DropForeignKey("dbo.Media", "Checkout_Checkout_Id", "dbo.Checkout");
            DropForeignKey("dbo.Checkout", "Media_Media_Id1", "dbo.Media");
            DropForeignKey("dbo.Checkout", "Media_Media_Id", "dbo.Media");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Media", new[] { "Checkout_Checkout_Id" });
            DropIndex("dbo.Checkout", new[] { "Media_Media_Id1" });
            DropIndex("dbo.Checkout", new[] { "Media_Media_Id" });
            DropIndex("dbo.Checkout", new[] { "Member_id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Member");
            DropTable("dbo.Media");
            DropTable("dbo.Checkout");
        }
    }
}
