using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class Trainer
    {
        [Key]
        public int TrainerID { get; set; }
        [Required]
        [Display(Name = "Trainer Name")]
        public string TrainerName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Trainer Email")]
        public string TrainerEmail { get; set; }

    }
}