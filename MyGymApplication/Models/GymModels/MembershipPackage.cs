using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class MembershipPackage
    {
        [Key]
        [Display(Name = "Membership Package ID")]
        public int MemPackageID { get; set; }

        [Display(Name = "Package Name")]
        [Required(ErrorMessage = "*Please enter package name.")]
        public string PackageName { get; set; }

        [Display(Name = "Monthly Fee")]
        [Required(ErrorMessage = "*Please enter package fee.")]
        public double MonthlyFee { get; set; }
    }
}