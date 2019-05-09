namespace MyGymApplication.Migrations.MyGym
{
    using Models.GymModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyGymApplication.Data.MyGymContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\MyGym";
        }

        protected override void Seed(MyGymApplication.Data.MyGymContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.



            context.MembershipPackages.AddOrUpdate(m => m.MemPackageID,
                new MembershipPackage
                {
                    PackageName = "Bronze - Quarterly",
                    MonthlyFee = 250.00
                },
                new MembershipPackage
                {
                    PackageName = "Bronze - Half Yearly",
                    MonthlyFee = 225.00
                },
                new MembershipPackage
                {
                    PackageName = "Bronze - Yearly",
                    MonthlyFee = 200.00
                },
                new MembershipPackage
                {
                    PackageName = "Silver - Quarterly",
                    MonthlyFee = 350.00
                },
                new MembershipPackage
                {
                    PackageName = "Silver - Half Yearly",
                    MonthlyFee = 325.00
                },
                new MembershipPackage
                {
                    PackageName = "Silver - Yearly",
                    MonthlyFee = 300.00
                },
                new MembershipPackage
                {
                    PackageName = "Gold - Quarterly",
                    MonthlyFee = 450.00
                },
                new MembershipPackage
                {
                    PackageName = "Gold - Half Yearly",
                    MonthlyFee = 425.00
                },
                new MembershipPackage
                {
                    PackageName = "Gold - Yearly",
                    MonthlyFee = 400.00
                },
                new MembershipPackage
                {
                    PackageName = "Platinum - Quarterly",
                    MonthlyFee = 550.00
                },
                new MembershipPackage
                {
                    PackageName = "Platinum - Half Yearly",
                    MonthlyFee = 525.00
                },
                new MembershipPackage
                {
                    PackageName = "Platinum - Yearly",
                    MonthlyFee = 500.00
                }
                );
            context.SaveChanges();

            context.Trainers.AddOrUpdate(t => t.TrainerID,
                new Trainer
                {
                    TrainerName = "My Trainer",
                    TrainerEmail = "21629701@dut4life.ac.za"
                });
            context.SaveChanges();

            context.Categories.AddOrUpdate(i => i.CategoryName,
                new Category { CategoryName = "Cardio" },
                new Category { CategoryName = "Strength" });
            context.SaveChanges();

            context.ExerciseClasses.AddOrUpdate(e => e.ExerciseClassID,
                new ExerciseClass
                {

                    ExerciseClassName = "Yoga101",
                    TrainerName = "My Trainer",
                    ExerciseClassDay = "Monday",
                    ExerciseClassTime = "16:00",
                    NumberEnrolled = 0,
                    MaximumNumberAllowed = 50,
                    CategoryName = context.Categories.Find("Cardio").CategoryName
                },
                new ExerciseClass
                {
                    ExerciseClassName = "Power Lifting",
                    TrainerName = "My Trainer",
                    ExerciseClassDay = "Friday",
                    ExerciseClassTime = "15:00",
                    NumberEnrolled = 0,
                    MaximumNumberAllowed = 50,
                    CategoryName = context.Categories.Find("Strength").CategoryName
                }
                );
            context.SaveChanges();

            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryName,
                new ProductCategory { ProductCategoryName = "Supplements" },
                new ProductCategory { ProductCategoryName = "Accessories" });
            context.SaveChanges();

           //context.Products.AddOrUpdate(p => p.ProductID,
           //     new Product
           //     {
           //         ProductName = "ISO-GRO WHEY",
           //         ProductBrand = "USN",
           //         ProductDescription = "ISO-GRO WHEY is the new generation whey protein, leaping foward to set a completely new benchmark. Build muscle or break through your plateau.",
           //         ProductPrice = 750.00M,
           //         ProductSizeQuantity = "3kg",
           //         ProductSupplier = "USN",
           //         ProductImagePath = "~/Content/ClassBookingResources/2017-10-18-17-07-41-1709661055.jpeg",
           //         ProductCategoryName = context.ProductCategories.Find("Supplements").ProductCategoryName
           //     },

           //     new Product
           //     {
           //         ProductName = "BULK Super Mass Generator",
           //         ProductBrand = "Biogen",
           //         ProductDescription = "BIOGEN BULK is high in energy and protein and is in favour of individuals looking to pick up BULK mass.",
           //         ProductPrice = 550.00M,
           //         ProductSizeQuantity = "4kg",
           //         ProductSupplier = "Biogen",
           //         ProductImagePath = "~/Content/ClassBookingResources/images-13 (5).jpeg",
           //         ProductCategoryName = context.ProductCategories.Find("Supplements").ProductCategoryName
           //     },

           //     new Product
           //     {
           //         ProductName = "Serious Size Mass Builder",
           //         ProductBrand = "Muscle Lab",
           //         ProductDescription = "MUSCLE LAB SERIOUS SIZE has been formulated to the ratio of carbs/protein used by professional bodybuilders. The superior amino acid profile increases muscle building while reducing muscle breakdown. This muscle cell volumising formula will ensure that you pack on some SERIOUS SIZE.",
           //         ProductPrice = 180.00M,
           //         ProductSizeQuantity = "2kg",
           //         ProductSupplier = "Muscle Lab",
           //         ProductImagePath = "~/Content/ClassBookingResources/2017-10-18-17-27-22-274028910.jpeg",
           //         ProductCategoryName = context.ProductCategories.Find("Supplements").ProductCategoryName
           //     },

           //    new Product
           //    {
           //        ProductName = "All-In-One Hyperbolic mass",
           //        ProductBrand = "USN",
           //        ProductDescription = "USN HYPERBOLIC MASS has been scientifically formulated for individuals with a fast metabolism who demand a high level of energy to help reduce the breakdown of muscle tissue for energy.",
           //        ProductPrice = 100.00M,
           //        ProductSizeQuantity = "1kg",
           //        ProductSupplier = "USN",
           //        ProductImagePath = "~/Content/ClassBookingResources/images-18 (6).jpeg",
           //        ProductCategoryName = context.ProductCategories.Find("Supplements").ProductCategoryName
           //    },

           //    new Product
           //    {
           //        ProductName = "Weight Lifting Wrist Straps",
           //        ProductBrand = "USN",
           //        ProductDescription = "These Lifting straps give you the ultimate grip, allowing you to confidently hold onto a bar with heavier loads. They offer maximum grip, comfort and durability. Suitable for all sizes.",
           //        ProductPrice = 200.00M,
           //        ProductSizeQuantity = "1 per hand",
           //        ProductSupplier = "USN",
           //        ProductImagePath = "~/Content/ClassBookingResources/images-19 (5).jpeg",
           //        ProductCategoryName = context.ProductCategories.Find("Accesories").ProductCategoryName
           //    },

           //    new Product
           //    {
           //        ProductName = "Lifting Belt",
           //        ProductBrand = "USN",
           //        ProductDescription = "The USN LIFTING BELT has a superior design that provides lower back and abdominal support. This belt is ideal for general lifting, injury prevention and ultimate control.",
           //        ProductPrice = 200.00M,
           //        ProductSizeQuantity = "1",
           //        ProductSupplier = "USN",
           //        ProductImagePath = "~/Content/ClassBookingResources/images-12 (7).jpeg",
           //        ProductCategoryName = context.ProductCategories.Find("Accessories").ProductCategoryName
           //    } );
           // context.SaveChanges();
        }
    }
}

