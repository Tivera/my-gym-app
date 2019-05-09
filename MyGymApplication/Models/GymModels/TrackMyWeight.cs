using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class TrackMyWeight
    {

        [Key][Column(Order = 0)]
        public int ID { get; set; }

        [Key][Column(Order = 1)]
        [Required(ErrorMessage = "Week is required")]
        [Display(Name = "Week")]
        [Range(1, 52, ErrorMessage = "Please enter a week number from 1 - 52")]
        public int week { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = "Weight")]
        public double weight { get; set; }

        [Required]
        [Display(Name = "Membership Number")]
        public string MembershipNumber { get; set; }


        public virtual Member Member { get; set; }
    }
}