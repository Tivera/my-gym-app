using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGymApplication.Data
{
    public class SampleData /*: System.Data.Entity.DropCreateDatabaseIfModelChanges<ClassBookingContext>*/
    {
        //protected override void Seed(ClassBookingContext context)
        //{
        //    //context.Categories.AddOrUpdate(i => i.categoryName,
        //    //    new Category { categoryName = "Cardio" },
        //    //    new Category { categoryName = "Strength" });


        //    var categories = new List<Category>
        //    {
        //        new Category{categoryName="Cardio"},
        //        new Category{categoryName="Strength"},
        //        new Category{categoryName="Balance"},
        //        new Category{categoryName="Combination"}

        //    };
        //    categories.ForEach(c => context.Categories.Add(c));
        //    context.SaveChanges();

        //    var members = new List<Member>
        //    {
        //        new Member{memName= "Admin", memSurname= "Admin", contactNumber = "0723334552", idNumber = "1234567891123",
        //            email = "admin@gmail.com" , password = "admin", confirmPassword = "admin", securityQuestion = "What was your first pets name?",
        //        securityQuestionAnswer = "admin", membershipPackage = "admin", membershipFee = 0, points = 0 },
        //        new Member{memName= "Tivera", memSurname= "Krishnasamy", contactNumber = "0823169857", idNumber = "9803071234082",
        //            email = "sample@gmail.com" , password = "sample", confirmPassword = "sample", securityQuestion = "What was your first pets name?",
        //        securityQuestionAnswer = "sample", membershipPackage = "Bronze (200)", membershipFee = 200, points = 0 }
        //    };
        //    members.ForEach(m => context.Members.Add(m));
        //    context.SaveChanges();

        //    var trainers = new List<Trainer>
        //    {
        //        new Trainer{trainerName="Mo Saib", trainerEmail = "m.jauhaar.saib@gmail.com"},
        //        new Trainer{trainerName="Iiv K", trainerEmail = "21629701@dut4life.ac.za"},
        //        new Trainer{trainerName="Tivera Krishnasamy", trainerEmail = "21629701@dut4life.ac.za"},
        //        new Trainer{trainerName="Sarita Mudaly", trainerEmail = "saritam@gmail.ac.za"},
        //        new Trainer{trainerName="Ashton Beepat", trainerEmail = "ashtonb@gmail.ac.za"},
        //        new Trainer{trainerName="Kival Singh", trainerEmail = "kivals@gmail.ac.za"},
        //        new Trainer{trainerName="Rikarl Rajpaul", trainerEmail = "rikarlr@gmail.ac.za"}

        //    };
        //    trainers.ForEach(t => context.Trainers.Add(t));
        //    context.SaveChanges();



        //    var productCategories = new List<ProductCategory>
        //    {
        //        new ProductCategory{productCategoryName="Supplements"},
        //        new ProductCategory{productCategoryName="Accessories"}


        //    };
        //    productCategories.ForEach(pc => context.ProductCategories.Add(pc));
        //    context.SaveChanges();

        //    var products = new List<Product>
        //    {
        //        new Product{productName="ISO-GRO WHEY", productBrand="USN", productDescription="ISO-GRO WHEY is the new generation whey protein, leaping foward to set a completely new benchmark. Build muscle or break through your plateau.", productPrice=750.00M, productQuantity="3kg", productSupplier="USN", productImagePath="~/Content/ClassBookingResources/2017-10-18-17-07-41-1709661055.jpeg" ,ProductCategory = productCategories.Single(pc => pc.productCategoryName == "Supplements")},
        //        new Product{productName="BULK Super Mass Generator", productBrand="Biogen", productDescription="BIOGEN BULK is high in energy and protein and is in favour of individuals looking to pick up BULK mass.", productPrice=550.00M, productQuantity="4kg", productSupplier="Biogen", productImagePath="~/Content/ClassBookingResources/images-13 (5).jpeg" ,ProductCategory = productCategories.Single(pc => pc.productCategoryName == "Supplements")},
        //        new Product{productName="Serious Size Mass Builder", productBrand="Muscle Lab", productDescription="MUSCLE LAB SERIOUS SIZE has been formulated to the ratio of carbs/protein used by professional bodybuilders. The superior amino acid profile increases muscle building while reducing muscle breakdown. This muscle cell volumising formula will ensure that you pack on some SERIOUS SIZE.", productPrice=180.00M, productQuantity="2kg", productSupplier="Muscle Lab",productImagePath="~/Content/ClassBookingResources/2017-10-18-17-27-22-274028910.jpeg" , ProductCategory = productCategories.Single(pc => pc.productCategoryName == "Supplements")},
        //        new Product{productName="TestoMAX17", productBrand="USN", productDescription="USN's Testo Max 17 has been developed to support the optimization of controlled and heightened testosterone levels.", productPrice=200.00M, productQuantity="60 capsules", productSupplier="USN", productImagePath="~/Content/ClassBookingResources/images-21 (3).jpeg" ,ProductCategory = productCategories.Single(pc => pc.productCategoryName == "Supplements")},
        //        new Product{productName="All-In-One Hyperbolic mass", productBrand="USN", productDescription="USN HYPERBOLIC MASS has been scientifically formulated for individuals with a fast metabolism who demand a high level of energy to help reduce the breakdown of muscle tissue for energy.", productPrice=100.00M, productQuantity="1kg", productSupplier="USN", productImagePath="~/Content/ClassBookingResources/images-18 (6).jpeg" ,ProductCategory = productCategories.Single(pc => pc.productCategoryName == "Supplements")},

        //        new Product{productName="Weight Lifting Wrist Straps", productBrand="USN", productDescription="These Lifting straps give you the ultimate grip, allowing you to confidently hold onto a bar with heavier loads. They offer maximum grip, comfort and durability. Suitable for all sizes.", productPrice=200.00M, productQuantity="1 per hand", productSupplier="USN", productImagePath="~/Content/ClassBookingResources/images-19 (5).jpeg" ,ProductCategory = productCategories.Single(pc => pc.productCategoryName == "Accessories")},
        //        new Product{productName="Lifting Belt", productBrand="USN", productDescription="The USN LIFTING BELT has a superior design that provides lower back and abdominal support. This belt is ideal for general lifting, injury prevention and ultimate control.", productPrice=200.00M, productQuantity="1", productSupplier="USN", productImagePath="~/Content/ClassBookingResources/images-12 (7).jpeg" ,ProductCategory = productCategories.Single(pc => pc.productCategoryName == "Accessories")},

        //    };
        //    products.ForEach(p => context.Products.Add(p));
        //    context.SaveChanges();

        //    var exerciseClasses = new List<ExerciseClass>
        //    {
        //        new ExerciseClass{exerciseClassName="Yoga101", exerciseClassDay= "Monday", exerciseClassTime = "16:00", numEnrolled= 15, TrainerName = "Sarita Mudaly" ,Category = categories.Single(c => c.categoryName == "Balance")},
        //        new ExerciseClass{exerciseClassName="Weight Loss", exerciseClassDay= "Thursday", exerciseClassTime = "08:00", numEnrolled= 15, TrainerName = "Sarita Mudaly" ,Category = categories.Single(c => c.categoryName == "Balance")},
        //        new ExerciseClass{exerciseClassName="Zumba2.0", exerciseClassDay= "Thursday", exerciseClassTime = "13:00", numEnrolled= 50, TrainerName = "Mo Saib", Category = categories.Single(c => c.categoryName == "Cardio")},
        //        new ExerciseClass{exerciseClassName="Taibo", exerciseClassDay= "Monday", exerciseClassTime = "18:00", numEnrolled= 30, TrainerName = "Ashton Beepat" ,Category = categories.Single(c => c.categoryName == "Cardio")},
        //        new ExerciseClass{exerciseClassName="Calisthenics", exerciseClassDay= "Saturday", exerciseClassTime = "08:00", numEnrolled= 40, TrainerName = "Kival Singh" ,Category = categories.Single(c => c.categoryName == "Cardio")},
        //        new ExerciseClass{exerciseClassName="Power Lifting", exerciseClassDay= "Friday", exerciseClassTime = "15:00", numEnrolled= 30, TrainerName = "Kival Singh", Category = categories.Single(c => c.categoryName == "Strength")},
        //        new ExerciseClass{exerciseClassName="Shred", exerciseClassDay= "Sunday", exerciseClassTime = "11:00", numEnrolled= 20, TrainerName = "Rikarl Rajpaul", Category = categories.Single(c => c.categoryName == "Strength")},
        //        new ExerciseClass{exerciseClassName="Crossfit", exerciseClassDay= "Wednesday", exerciseClassTime = "17:00", numEnrolled= 35, TrainerName = "Rikarl Rajpaul", Category = categories.Single(c => c.categoryName == "Combination")},
        //        new ExerciseClass{exerciseClassName="ComboV3", exerciseClassDay= "Monday", exerciseClassTime = "12:00", numEnrolled= 25, TrainerName = "Tivera Krishnasamy", Category = categories.Single(c => c.categoryName == "Combination")}

        //    };
        //    exerciseClasses.ForEach(e => context.ExerciseClasses.Add(e));
        //    context.SaveChanges();



        //}
    }

}