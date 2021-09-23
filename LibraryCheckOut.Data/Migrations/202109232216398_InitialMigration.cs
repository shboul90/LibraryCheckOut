namespace LibraryCheckOut.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MediaCheckouts", "Media_Media_Id", "dbo.Media");
            DropForeignKey("dbo.MediaCheckouts", "Checkout_Checkout_Id", "dbo.Checkouts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            RenameTable(name: "dbo.Checkouts", newName: "Checkout");
            RenameTable(name: "dbo.Members", newName: "Member");
            RenameTable(name: "dbo.AspNetRoles", newName: "IdentityRole");
            RenameTable(name: "dbo.AspNetUsers", newName: "ApplicationUser");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "IdentityUserClaim");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "IdentityUserLogin");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "IdentityUserRole");
            DropIndex("dbo.IdentityRole", "RoleNameIndex");
            DropIndex("dbo.IdentityUserRole", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "RoleId" });
            DropIndex("dbo.ApplicationUser", "UserNameIndex");
            DropIndex("dbo.IdentityUserClaim", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "UserId" });
            DropIndex("dbo.MediaCheckouts", new[] { "Media_Media_Id" });
            DropIndex("dbo.MediaCheckouts", new[] { "Checkout_Checkout_Id" });
            DropPrimaryKey("dbo.IdentityUserRole");
            DropPrimaryKey("dbo.IdentityUserLogin");
            AddColumn("dbo.Checkout", "Media_Media_Id", c => c.Int());
            AddColumn("dbo.Checkout", "Media_Media_Id1", c => c.Int());
            AddColumn("dbo.Media", "Checkout_Checkout_Id", c => c.Int());
            AddColumn("dbo.Member", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Member", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Member", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Member", "StreetAddress", c => c.String(nullable: false));
            AddColumn("dbo.Member", "City", c => c.String(nullable: false));
            AddColumn("dbo.Member", "State", c => c.String(nullable: false));
            AddColumn("dbo.Member", "Zip", c => c.String(nullable: false));
            AddColumn("dbo.Member", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Member", "DateOfMembership", c => c.DateTime(nullable: false));
            AddColumn("dbo.Member", "MembershipRating", c => c.String(nullable: false));
            AddColumn("dbo.Member", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Member", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.IdentityUserRole", "IdentityRole_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserRole", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserClaim", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserLogin", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityRole", "Name", c => c.String());
            AlterColumn("dbo.IdentityUserRole", "RoleId", c => c.String());
            AlterColumn("dbo.ApplicationUser", "Email", c => c.String());
            AlterColumn("dbo.ApplicationUser", "UserName", c => c.String());
            AlterColumn("dbo.IdentityUserClaim", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserLogin", "LoginProvider", c => c.String());
            AlterColumn("dbo.IdentityUserLogin", "ProviderKey", c => c.String());
            AddPrimaryKey("dbo.IdentityUserRole", "UserId");
            AddPrimaryKey("dbo.IdentityUserLogin", "UserId");
            CreateIndex("dbo.Checkout", "Media_Media_Id");
            CreateIndex("dbo.Checkout", "Media_Media_Id1");
            CreateIndex("dbo.Media", "Checkout_Checkout_Id");
            CreateIndex("dbo.IdentityUserRole", "IdentityRole_Id");
            CreateIndex("dbo.IdentityUserRole", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserClaim", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserLogin", "ApplicationUser_Id");
            AddForeignKey("dbo.Checkout", "Media_Media_Id", "dbo.Media", "Media_Id");
            AddForeignKey("dbo.Checkout", "Media_Media_Id1", "dbo.Media", "Media_Id");
            AddForeignKey("dbo.Media", "Checkout_Checkout_Id", "dbo.Checkout", "Checkout_Id");
            AddForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole", "Id");
            AddForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            DropTable("dbo.MediaCheckouts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MediaCheckouts",
                c => new
                    {
                        Media_Media_Id = c.Int(nullable: false),
                        Checkout_Checkout_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Media_Media_Id, t.Checkout_Checkout_Id });
            
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
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
            DropPrimaryKey("dbo.IdentityUserLogin");
            DropPrimaryKey("dbo.IdentityUserRole");
            AlterColumn("dbo.IdentityUserLogin", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserLogin", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserClaim", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ApplicationUser", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.ApplicationUser", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.IdentityUserRole", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityRole", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.IdentityUserLogin", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserClaim", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserRole", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserRole", "IdentityRole_Id");
            DropColumn("dbo.Member", "ModifiedUtc");
            DropColumn("dbo.Member", "CreatedUtc");
            DropColumn("dbo.Member", "MembershipRating");
            DropColumn("dbo.Member", "DateOfMembership");
            DropColumn("dbo.Member", "PhoneNumber");
            DropColumn("dbo.Member", "Zip");
            DropColumn("dbo.Member", "State");
            DropColumn("dbo.Member", "City");
            DropColumn("dbo.Member", "StreetAddress");
            DropColumn("dbo.Member", "LastName");
            DropColumn("dbo.Member", "FirstName");
            DropColumn("dbo.Member", "OwnerId");
            DropColumn("dbo.Media", "Checkout_Checkout_Id");
            DropColumn("dbo.Checkout", "Media_Media_Id1");
            DropColumn("dbo.Checkout", "Media_Media_Id");
            AddPrimaryKey("dbo.IdentityUserLogin", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.IdentityUserRole", new[] { "UserId", "RoleId" });
            CreateIndex("dbo.MediaCheckouts", "Checkout_Checkout_Id");
            CreateIndex("dbo.MediaCheckouts", "Media_Media_Id");
            CreateIndex("dbo.IdentityUserLogin", "UserId");
            CreateIndex("dbo.IdentityUserClaim", "UserId");
            CreateIndex("dbo.ApplicationUser", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.IdentityUserRole", "RoleId");
            CreateIndex("dbo.IdentityUserRole", "UserId");
            CreateIndex("dbo.IdentityRole", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MediaCheckouts", "Checkout_Checkout_Id", "dbo.Checkouts", "Checkout_Id", cascadeDelete: true);
            AddForeignKey("dbo.MediaCheckouts", "Media_Media_Id", "dbo.Media", "Media_Id", cascadeDelete: true);
            RenameTable(name: "dbo.IdentityUserLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.IdentityUserClaim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.ApplicationUser", newName: "AspNetUsers");
            RenameTable(name: "dbo.IdentityUserRole", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.IdentityRole", newName: "AspNetRoles");
            RenameTable(name: "dbo.Member", newName: "Members");
            RenameTable(name: "dbo.Checkout", newName: "Checkouts");
        }
    }
}
