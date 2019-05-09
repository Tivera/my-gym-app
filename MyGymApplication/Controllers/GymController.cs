using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using MyGymApplication.Models.GymModels;
using System.Web.Helpers;
using System.Web.UI.WebControls;


namespace MyGymApplication.Controllers
{
    public class GymController : Controller
    {
        string tempMembershipNumber = "";
        Data.MyGymContext myGymDB = new Data.MyGymContext();
        // GET: MyGym
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult MainPage()
        {
            return View();//Returns Main or Home page
        }

        public ActionResult MenuPage()
        {
            if (Session["memberNumber"] != null)
            {
                return View();//return menu page
            }
            else
            {
                return RedirectToAction("Login");//else redirect to login if no member is logged in
            }
        }

        // GET: Members/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Members/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "IdentityNumber,MemberName,MemberSurname,ContactNumber,Email,Password,ConfirmPassword,SecurityQuestion,SecurityQuestionAnswer,PackageName")] Member member)
        {
            if (ModelState.IsValid)
            {
                member.MembershipNumber = "GYM" + ((member.MemberName).ToUpper()).Substring(0, 3) + member.MemberID;

                member.DateJoined = DateTime.Now;

                if ((member.PackageName).Equals("Bronze Quarterly - R250p/m"))
                { member.MembershipFee = 250.00; }
                else if ((member.PackageName).Equals("Bronze Half Yearly - R225p/m"))
                { member.MembershipFee = 225.00; }
                else if ((member.PackageName).Equals("Bronze Yearly - R200p/m"))
                { member.MembershipFee = 200.00; }

                else if ((member.PackageName).Equals("Silver Quarterly - R350p/m"))
                { member.MembershipFee = 350.00; }
                else if ((member.PackageName).Equals("Silver Half Yearly - R325p/m"))
                { member.MembershipFee = 325.00; }
                else if ((member.PackageName).Equals("Silver Yearly - R300p/m"))
                { member.MembershipFee = 300.00; }

                else if ((member.PackageName).Equals("Gold Quarterly - R450p/m"))
                { member.MembershipFee = 450.00; }
                else if ((member.PackageName).Equals("Gold Half Yearly - R425p/m"))
                { member.MembershipFee = 425.00; }
                else if ((member.PackageName).Equals("Gold Yearly - R400p/m"))
                { member.MembershipFee = 400.00; }

                else if ((member.PackageName).Equals("Platinum Quarterly - R550p/m"))
                { member.MembershipFee = 550.00; }
                else if ((member.PackageName).Equals("Platinum Half Yearly - R525p/m"))
                { member.MembershipFee = 525.00; }
                else if ((member.PackageName).Equals("Platinum Yearly - R500p/m"))
                { member.MembershipFee = 500.00; }

                member.Points = 0;


                myGymDB.Members.Add(member);
                myGymDB.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = $"{member.MemberName} {member.MemberSurname}, you are now successfully registered!" + "<br/>" +
                $"Your Membership Number is: " + ("GYM" + ((member.MemberName).ToUpper()).Substring(0, 3) + member.MemberID) + " <br/>";

                return RedirectToAction("RegistrationComplete");
            }

            return View(member);
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Member member)
        {

            //first check that user exists
            var memberExists = myGymDB.Members.Where(x => x.Email == member.Email).SingleOrDefault();

            if (memberExists != null)
            {
                //check username and password is correct or valid
                var validMember = myGymDB.Members.Where(x => x.Email == member.Email && x.Password == member.Password).SingleOrDefault();
                if (validMember != null)
                {

                    Session["memberNumber"] = validMember.MembershipNumber.ToString();
                    Session["email"] = validMember.Email.ToString();
                    Session["memberName"] = validMember.MemberName.ToString();

                    validMember.Points += 10;
                    tempMembershipNumber = (Session["memberNumber"]).ToString();
                    myGymDB.SaveChanges();

                    return RedirectToAction("MenuPage");
                }
                else {

                    Response.Write("<script>alert('Please ensure that you have entered the correct username and password.');</script>");
                }
            }
            else {
                Response.Write("<script>alert('Please ensure that you are registered and have entered the correct username and password.');</script>");
            }
            return null;
        }


        //public ActionResult LoggedIn()
        //{
        //    if (Session["memNumber"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}


        //Lists Class Categories
        public ActionResult CategoryIndex()
        {

            if (Session["memberNumber"] != null) //Gets the member number of the logged in member
            {
                var categories = myGymDB.Categories.ToList();

                return View(categories);

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        //Browse Classes Specific to a Category
        public ActionResult BrowseClasses(string category)
        {
            if (Session["memberNumber"] != null) //Gets the member number of the logged in member
            {
                var categoryModel = myGymDB.Categories.Include("ExerciseClasses").Single(e => e.CategoryName == category);
                return View(categoryModel);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        //Get the class details for a selected class
        public ActionResult ClassDetails(int id)
        {
            if (Session["memberNumber"] != null) //Gets the member number of the logged in member
            {
                ExerciseClass exerciseClassDetails = myGymDB.ExerciseClasses.Find(id);
                return View(exerciseClassDetails);
            }

            else
            {
                return RedirectToAction("Login");
            }

        }

        // GET: ExerciseClasses
        public ActionResult ClassIndex()
        {
            if (Session["memberNumber"] != null) //Gets the member number of the logged in member
            {
                var exerciseClasses = myGymDB.ExerciseClasses.Include(e => e.Category);
                return View(exerciseClasses.ToList());
            }

            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult ViewMyBookings()
        {
            if (Session["memberNumber"] != null) //Gets the member number of the logged in member
            {
                string thisMember = (Session["memberNumber"]).ToString();
                var myBookings = from btable in myGymDB.Bookings select btable;

                myBookings = myBookings.Where(x => x.MembershipNumber.Equals(thisMember));

                return View(myBookings);
            }

            else
            {
                return RedirectToAction("Login");
            }
        }

        //Make A Booking 
        public ActionResult makeBooking(int id)
        {
            if (Session["memberNumber"] != null) //Gets the member number of the logged in member
            {
                //Getting the class  from the db with the passed id
                var getClass = myGymDB.ExerciseClasses.Single(exerciseClasses => exerciseClasses.ExerciseClassID == id);


                //Getting the number enrolled for this class
                int number = myGymDB.ExerciseClasses.Single(ExerciseClass => ExerciseClass.ExerciseClassID == id).NumberEnrolled;


                //Getting the max number allowed to be enrolled for this class
                int maxNumber = myGymDB.ExerciseClasses.Single(ExerciseClass => ExerciseClass.ExerciseClassID == id).MaximumNumberAllowed;

                //Getting class name
                string name = myGymDB.ExerciseClasses.Single(ExerciseClass => ExerciseClass.ExerciseClassID == id).ExerciseClassName;

                //Membership number of the person currently logged in
                string loggedInMemberNumber = (Session["memberNumber"]).ToString();

                //checking if membership number for this exercise class has already been booked - a record is in the bookings table with class name and membership number
                var memberAlreadyEnrolled = myGymDB.Bookings.Where(x => x.MembershipNumber == loggedInMemberNumber && x.ExerciseClassName == name).FirstOrDefault();

                // conditional statement to complete booking process (or not)
                if (memberAlreadyEnrolled != null)  //if a record is present with this member and exercise class provide feedback that user already booked
                {
                    return RedirectToAction("AlreadyBooked");
                }
                else { //else check if the class has available space for another booking
                    if (number < maxNumber) //if there is space, create a booking
                    {
                        Booking newBooking = new Booking
                        {
                            MembershipNumber = (Session["memberNumber"]).ToString(), //member number
                            ExerciseClassName = name, //exercise class name
                            BookingTime = System.DateTime.Now //system time of booking
                        };



                        number++; //increase the number enrolled
                        var numEnrolledinc = myGymDB.ExerciseClasses.Single(
                        exerciseClasses => exerciseClasses.ExerciseClassID == id).NumberEnrolled = number;


                        myGymDB.Bookings.Add(newBooking);//add booking
                        myGymDB.SaveChanges();

                        Response.Write("<script>alert('Booking Successful!');</script>");
                        return RedirectToAction("MenuPage"); //redirect to menu and show booking successful if complete for user feedback
                    }
                    else {
                        Response.Write("<script>alert('Booking Unsuccessful!');</script>");
                        return RedirectToAction("MenuPage");//else redirect to booking unsuccessful for user feedback
                    }
                }
            }

            else
            {
                return RedirectToAction("Login");
            }


        }

        //Delete Booking GET
        // GET: /Booking/Delete/5
        public ActionResult DeleteBooking(int id)
        {
            if (Session["memberNumber"] != null) //Gets the member number of the logged in member
            {
                Booking booking = myGymDB.Bookings.Find(id);
                return View(booking);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //Delete Booking POST
        // POST: /Booking/Delete/5
        [HttpPost, ActionName("DeleteBooking")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["memberNumber"] != null)
            {
                Booking booking = myGymDB.Bookings.Find(id); //Find this booking


                string bookingClassName = myGymDB.Bookings.Single(Booking => Booking.BookingID == id).ExerciseClassName;
                int classID = myGymDB.ExerciseClasses.Single(exerciseClasses => exerciseClasses.ExerciseClassName == bookingClassName).ExerciseClassID;
                int thisNumberEnrolled = myGymDB.ExerciseClasses.Single(exerciseClass => exerciseClass.ExerciseClassID == classID).NumberEnrolled;
                //Decrease number enrolled for this class
                thisNumberEnrolled--;

                var numEnrolledDec = myGymDB.ExerciseClasses.Single(exerciseClasses => exerciseClasses.ExerciseClassID == classID).NumberEnrolled = thisNumberEnrolled;

                myGymDB.Bookings.Remove(booking);//Remove booking
                myGymDB.SaveChanges();
                return RedirectToAction("MenuPage");
            }
            else
            {
                return RedirectToAction("Login"); //else redirect to login if no member is logged in
            }

        }


        public ActionResult AlreadyBooked()
        {
            if (Session["memberNumber"] != null)
            {
                return View(); //return already booked page
            }
            else
            {
                return RedirectToAction("Login"); //else redirect to login if no member is logged in
            }
        }


        //public ActionResult BookingSuccessful()
        //{
        //    if (Session["memNumber"] != null)
        //    {
        //        return View(); //return booking successful page
        //    }
        //    else
        //    {
        //        return RedirectToAction("login");//else redirect to login if no member is logged in
        //    }
        //}


        //public ActionResult BookingUnsuccessful()
        //{
        //    if (Session["memNumber"] != null)
        //    {
        //        return View();//return booking successful unsuccessful
        //    }
        //    else
        //    {
        //        return RedirectToAction("login");//else redirect to login if no member is logged in
        //    }
        //}

        //Returns all this member's details for viewing purposes
        public ActionResult Details()
        {
            if (Session["memberNumber"] != null) //Gets the member number of the logged in member
            {
                string tempNumber = Session["memberNumber"].ToString();
                var getMemberDetails = myGymDB.Members.Single(x => x.MembershipNumber == tempNumber);
                return View(getMemberDetails);

            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //Get the class details for a selected class


        [ChildActionOnly]
        public ActionResult LoginOrRegisterPV()
        {
            return View();//Returns Login or Register Partial View that is called in the start page
        }

        public ActionResult Contact()
        {
            return View(); //returns Contact Page
        }

        public ActionResult RegistrationComplete()
        {
            if (Session["memberNumber"] != null)
            {
                return View(); //returns RegistrationComplete Page
            }
            else
            {
                return RedirectToAction("Login"); //else redirect to login if no member is logged in
            }
        }

        public ActionResult UnexpectedError()
        {
            if (Session["memberNumber"] != null)
            {
                return View(); //returns  Page
            }
            else
            {
                return RedirectToAction("Login"); //else redirect to login if no member is logged in
            }
        }

        public ActionResult EntryAdded()
        {
            if (Session["memberNumber"] != null)
            {
                return View(); //returns  Page
            }
            else
            {
                return RedirectToAction("Login"); //else redirect to login if no member is logged in
            }
        }

        public ActionResult Logout()
        {

            Session.Clear();
            return RedirectToAction("MainPage");
        }

        public ActionResult TrackMyWeight()
        {

            if (Session["memberNumber"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login"); //else redirect to login if no member is logged in
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMyWeight(int Week, double Weight)
        {
            string thisMemberNumber = (Session["memberNumber"]).ToString();
            int thisWeek = Convert.ToInt32(Week);
            double thisWeight = Convert.ToDouble(Weight);

            var weekAlreadyExists = myGymDB.TrackMyWeights.Where(x => x.week == Week).SingleOrDefault();

            if (weekAlreadyExists != null)
            {
                Response.Write("<script>alert('Please ensure that you have not entered a duplicate week.');</script>");
                ModelState.Clear();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    TrackMyWeight newDataEntry = new TrackMyWeight
                    {
                        week = Week,
                        weight = Weight,
                        MembershipNumber = thisMemberNumber
                    };
                    myGymDB.TrackMyWeights.Add(newDataEntry);
                    myGymDB.SaveChanges();
                    ModelState.Clear();

                    return RedirectToAction("EntryAdded");
                }
                else
                { Response.Write("<script>alert('Please ensure that you have data that is valid.');</script>"); }
            }

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddMyWeight([Bind(Include = "week,weight")] TrackMyWeight trackMyWeight)
        //{
        //    string memNumber = (Session["memberNumber"]).ToString();
        //    if (ModelState.IsValid)
        //    {
        //        trackMyWeight.MembershipNumber = memNumber;
        //        //var weekAlreadyExists = myGymDB.TrackMyWeights.Find(trackMyWeight.week);
        //        //if (weekAlreadyExists != null)
        //        //{ Response.Write("<script>alert('Please ensure that you have not entered a duplicate week.');</script>");
        //        //    ModelState.Clear();
        //        //}
        //        //else {
        //            myGymDB.TrackMyWeights.Add(trackMyWeight);
        //            myGymDB.SaveChanges();
        //            ModelState.Clear();
        //        return RedirectToAction("EntryAdded");
        //        //}
        //    }

        //    return View(trackMyWeight);
        //}


    


        public ActionResult BMI()
        {

            return View();

        }

        public ActionResult BMIResultPV(string txtWeight, string txtHeight)
        {
            double myBMI = 0.0;
            string BMIClassification = "";
            string myBMIAsAString = "";
            double myWeight = Convert.ToDouble(txtWeight);
            double myHeight = Convert.ToDouble(txtHeight);

            myBMI = myWeight / (myHeight * myHeight);

            myBMIAsAString = (myBMI).ToString("0.00");

            if (myBMI < 18.5)
            { BMIClassification = "Underweight"; }
            else if (myBMI >= 18 && myBMI <= 24.9)
            { BMIClassification = "Normal"; }
            else if (myBMI >= 25 && myBMI <= 29.9)
            { BMIClassification = "Overweight"; }
            else if (myBMI >= 30)
            { BMIClassification = "Obese"; }


            ViewBag.BMIResult = $"Result: {myBMIAsAString}  Classification: {BMIClassification}" + "<br/>";



            return View("BMI");
        }


        public ActionResult MyWeightChart()
        {

            //var weeks = from trackweighttable in myGymDB.TrackMyWeights select trackweighttable.week;
            //var weights = from trackweighttable in myGymDB.TrackMyWeights select trackweighttable.weight;

            //var myChart = new Chart(width: 600, height: 400)
            //    .AddTitle("My Weight Chart")
            //    .AddSeries("Default", xValue: weeks, xField: "Week", yValues: weights, yFields: "Weight")
            //    .Write();

            //ViewBag.MyWeightChart(myChart);
            return View();
        }

        public ActionResult MyClasses()
        {
            string thisMember = (Session["memberNumber"]).ToString();
            var myClassesList = (from ExerciseClass in myGymDB.ExerciseClasses
                                 join Booking in myGymDB.Bookings on ExerciseClass.ExerciseClassName equals Booking.ExerciseClassName
                                 where Booking.MembershipNumber == thisMember
                                 select new
                                 {
                                     Booking.ExerciseClassName,
                                     ExerciseClass.ExerciseClassDay,
                                     ExerciseClass.ExerciseClassTime,
                                     ExerciseClass.TrainerName,
                                     Booking.BookingTime
                                 }).ToList();
            ViewBag.MyClassesList = myClassesList;
            return View();
        }

        public ActionResult CreateRandomView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateTrainingProgram()
        {
            return View();
        }

        public ActionResult GenerateInputTablePV(string txtColumns, string txtRows)
        {
            int numColumns = Convert.ToInt32(txtColumns);
            int numRows = Convert.ToInt32(txtRows);


             //Creat the Table and Add it to the Page
            Table table = new Table();
            table.ID = "Table1";

            // Now iterate through the table and add your controls 
            for (int i = 0; i < numRows; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < numColumns; j++)
                {
                    TableCell cell = new TableCell();
                    TextBox tb = new TextBox();

                    // Set a unique ID for each TextBox added
                    tb.ID = "TextBoxRow_" + i + "Col_" + j;
                    // Add the control to the TableCell
                    cell.Controls.Add(tb);
                    // Add the TableCell to the TableRow
                    row.Cells.Add(cell);
                }

                // Add the TableRow to the Table
                table.Rows.Add(row);
            }

            return View(table);
        }

        //public JsonResult GetClasses()
        //{
        //    var classes = myGymDB.Bookings.ToList();
        //    return new JsonResult { Data = classes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

    }
}


