using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        [Display(Name = "Membership Number")]
        public string MembershipNumber { get; set; }
        [Display(Name = "Exercise Class Name")]
        public string ExerciseClassName { get; set; }
        [Display(Name = "Booking Date And Time")]
        public System.DateTime BookingTime { get; set; }

        public virtual Member Member { get; set; }
        public virtual ExerciseClass ExerciseClass { get; set; }

    }
}