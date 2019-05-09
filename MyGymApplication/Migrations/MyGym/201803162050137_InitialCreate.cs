namespace MyGymApplication.Migrations.MyGym
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        MembershipNumber = c.String(),
                        ExerciseClassName = c.String(),
                        BookingTime = c.DateTime(nullable: false),
                        ExerciseClass_ExerciseClassID = c.Int(),
                        Member_MemberID = c.Int(),
                        Member_MembershipNumber = c.String(maxLength: 128),
                        Member_IdentityNumber = c.String(maxLength: 13),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.ExerciseClass", t => t.ExerciseClass_ExerciseClassID)
                .ForeignKey("dbo.Member", t => new { t.Member_MemberID, t.Member_MembershipNumber, t.Member_IdentityNumber })
                .Index(t => t.ExerciseClass_ExerciseClassID)
                .Index(t => new { t.Member_MemberID, t.Member_MembershipNumber, t.Member_IdentityNumber });
            
            CreateTable(
                "dbo.ExerciseClass",
                c => new
                    {
                        ExerciseClassID = c.Int(nullable: false, identity: true),
                        ExerciseClassName = c.String(nullable: false),
                        TrainerName = c.String(nullable: false),
                        ExerciseClassDay = c.String(nullable: false),
                        ExerciseClassTime = c.String(nullable: false, maxLength: 5),
                        NumberEnrolled = c.Int(nullable: false),
                        MaximumNumberAllowed = c.Int(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 30),
                        Trainer_TrainerID = c.Int(),
                    })
                .PrimaryKey(t => t.ExerciseClassID)
                .ForeignKey("dbo.Category", t => t.CategoryName, cascadeDelete: true)
                .ForeignKey("dbo.Trainer", t => t.Trainer_TrainerID)
                .Index(t => t.CategoryName)
                .Index(t => t.Trainer_TrainerID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CategoryName);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        TrainerID = c.Int(nullable: false, identity: true),
                        TrainerName = c.String(nullable: false),
                        TrainerEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false),
                        MembershipNumber = c.String(nullable: false, maxLength: 128),
                        IdentityNumber = c.String(nullable: false, maxLength: 13),
                        MemberName = c.String(nullable: false),
                        MemberSurname = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        ConfirmPassword = c.String(nullable: false, maxLength: 50),
                        SecurityQuestion = c.String(nullable: false),
                        SecurityQuestionAnswer = c.String(nullable: false),
                        MembershipPackage = c.String(nullable: false),
                        DateJoined = c.DateTime(nullable: false),
                        MembershipFee = c.Double(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberID, t.MembershipNumber, t.IdentityNumber });
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        MembershipNumber = c.String(),
                        MemberName = c.String(),
                        MemberSurname = c.String(),
                        ContactNumber = c.String(),
                        Email = c.String(),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderTotalQuantity = c.Int(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Province = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        OrderStatus = c.String(nullable: false),
                        PaymentOutstanding = c.Boolean(nullable: false),
                        Member_MemberID = c.Int(),
                        Member_MembershipNumber = c.String(maxLength: 128),
                        Member_IdentityNumber = c.String(maxLength: 13),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Member", t => new { t.Member_MemberID, t.Member_MembershipNumber, t.Member_IdentityNumber })
                .Index(t => new { t.Member_MemberID, t.Member_MembershipNumber, t.Member_IdentityNumber });
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductBrand = c.String(nullable: false),
                        ProductDescription = c.String(nullable: false),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductSizeQuantity = c.String(nullable: false),
                        ProductSupplier = c.String(nullable: false),
                        ProductImagePath = c.String(nullable: false),
                        ProductCategoryName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryName, cascadeDelete: true)
                .Index(t => t.ProductCategoryName);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        CartID = c.String(),
                        ProductID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ProductCategoryName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ProductCategoryName);
            
            CreateTable(
                "dbo.EmailForm",
                c => new
                    {
                        EmailID = c.Int(nullable: false, identity: true),
                        ToEmail = c.String(nullable: false),
                        EmailBody = c.String(nullable: false),
                        EmailSubject = c.String(nullable: false),
                        EmailCC = c.String(),
                        EmailBCC = c.String(),
                        Trainer_TrainerID = c.Int(),
                    })
                .PrimaryKey(t => t.EmailID)
                .ForeignKey("dbo.Trainer", t => t.Trainer_TrainerID)
                .Index(t => t.Trainer_TrainerID);
            
            CreateTable(
                "dbo.MembershipPackage",
                c => new
                    {
                        MemPackageID = c.Int(nullable: false, identity: true),
                        PackageName = c.String(nullable: false),
                        MonthlyFee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MemPackageID);
            
            CreateTable(
                "dbo.TrackMyWeight",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        week = c.Int(nullable: false),
                        weight = c.Double(nullable: false),
                        MembershipNumber = c.String(nullable: false),
                        Member_MemberID = c.Int(),
                        Member_MembershipNumber = c.String(maxLength: 128),
                        Member_IdentityNumber = c.String(maxLength: 13),
                    })
                .PrimaryKey(t => new { t.ID, t.week })
                .ForeignKey("dbo.Member", t => new { t.Member_MemberID, t.Member_MembershipNumber, t.Member_IdentityNumber })
                .Index(t => new { t.Member_MemberID, t.Member_MembershipNumber, t.Member_IdentityNumber });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackMyWeight", new[] { "Member_MemberID", "Member_MembershipNumber", "Member_IdentityNumber" }, "dbo.Member");
            DropForeignKey("dbo.EmailForm", "Trainer_TrainerID", "dbo.Trainer");
            DropForeignKey("dbo.Product", "ProductCategoryName", "dbo.ProductCategory");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Cart", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", new[] { "Member_MemberID", "Member_MembershipNumber", "Member_IdentityNumber" }, "dbo.Member");
            DropForeignKey("dbo.Booking", new[] { "Member_MemberID", "Member_MembershipNumber", "Member_IdentityNumber" }, "dbo.Member");
            DropForeignKey("dbo.ExerciseClass", "Trainer_TrainerID", "dbo.Trainer");
            DropForeignKey("dbo.Booking", "ExerciseClass_ExerciseClassID", "dbo.ExerciseClass");
            DropForeignKey("dbo.ExerciseClass", "CategoryName", "dbo.Category");
            DropIndex("dbo.TrackMyWeight", new[] { "Member_MemberID", "Member_MembershipNumber", "Member_IdentityNumber" });
            DropIndex("dbo.EmailForm", new[] { "Trainer_TrainerID" });
            DropIndex("dbo.Cart", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "ProductCategoryName" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.Order", new[] { "Member_MemberID", "Member_MembershipNumber", "Member_IdentityNumber" });
            DropIndex("dbo.ExerciseClass", new[] { "Trainer_TrainerID" });
            DropIndex("dbo.ExerciseClass", new[] { "CategoryName" });
            DropIndex("dbo.Booking", new[] { "Member_MemberID", "Member_MembershipNumber", "Member_IdentityNumber" });
            DropIndex("dbo.Booking", new[] { "ExerciseClass_ExerciseClassID" });
            DropTable("dbo.TrackMyWeight");
            DropTable("dbo.MembershipPackage");
            DropTable("dbo.EmailForm");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Cart");
            DropTable("dbo.Product");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Order");
            DropTable("dbo.Member");
            DropTable("dbo.Trainer");
            DropTable("dbo.Category");
            DropTable("dbo.ExerciseClass");
            DropTable("dbo.Booking");
        }
    }
}
