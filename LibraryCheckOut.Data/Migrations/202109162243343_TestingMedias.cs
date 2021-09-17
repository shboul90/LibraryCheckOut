namespace LibraryCheckOut.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingMedias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkouts", "CheckoutDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Checkouts", "Member_id", c => c.Int(nullable: false));
            AddColumn("dbo.Checkouts", "TotalNumberOfItems", c => c.Int(nullable: false));
            AddColumn("dbo.Checkouts", "Media_Media_Id", c => c.Int());
            AddColumn("dbo.Media", "MediaType", c => c.Int(nullable: false));
            AddColumn("dbo.Media", "Title", c => c.String());
            AddColumn("dbo.Media", "Author", c => c.String());
            AddColumn("dbo.Media", "YearReleased", c => c.DateTime(nullable: false));
            AddColumn("dbo.Media", "Genre", c => c.Int(nullable: false));
            AddColumn("dbo.Media", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Media", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Media", "InstockQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Media", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Media", "LastUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Media", "AddedBy", c => c.String());
            AddColumn("dbo.Media", "LastUpdatedBy", c => c.String());
            CreateIndex("dbo.Checkouts", "Member_id");
            CreateIndex("dbo.Checkouts", "Media_Media_Id");
            AddForeignKey("dbo.Checkouts", "Media_Media_Id", "dbo.Media", "Media_Id");
            AddForeignKey("dbo.Checkouts", "Member_id", "dbo.Members", "Member_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkouts", "Member_id", "dbo.Members");
            DropForeignKey("dbo.Checkouts", "Media_Media_Id", "dbo.Media");
            DropIndex("dbo.Checkouts", new[] { "Media_Media_Id" });
            DropIndex("dbo.Checkouts", new[] { "Member_id" });
            DropColumn("dbo.Media", "LastUpdatedBy");
            DropColumn("dbo.Media", "AddedBy");
            DropColumn("dbo.Media", "LastUpdated");
            DropColumn("dbo.Media", "DateAdded");
            DropColumn("dbo.Media", "InstockQuantity");
            DropColumn("dbo.Media", "Quantity");
            DropColumn("dbo.Media", "Rating");
            DropColumn("dbo.Media", "Genre");
            DropColumn("dbo.Media", "YearReleased");
            DropColumn("dbo.Media", "Author");
            DropColumn("dbo.Media", "Title");
            DropColumn("dbo.Media", "MediaType");
            DropColumn("dbo.Checkouts", "Media_Media_Id");
            DropColumn("dbo.Checkouts", "TotalNumberOfItems");
            DropColumn("dbo.Checkouts", "Member_id");
            DropColumn("dbo.Checkouts", "CheckoutDate");
        }
    }
}
