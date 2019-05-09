using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class Category
    {
        [Key]
        [Required]
        [MaxLength(30)]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public List<ExerciseClass> ExerciseClasses { get; set; }

    }
}