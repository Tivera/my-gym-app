using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class ExerciseClass
    {
        [Key]
        public int ExerciseClassID { get; set; }
        [Required(ErrorMessage = "*Please enter exercise class name.")]
        [Display(Name = "Exercise Class Name")]
        public string ExerciseClassName { get; set; }
        [Required(ErrorMessage = "*Please select a trainer.")]
        [Display(Name = "Trainer")]
        public string TrainerName { get; set; }
        [Required(ErrorMessage = "*Please select a day for the class.")]
        [Display(Name = "Exercise Class Day")]
        public string ExerciseClassDay { get; set; }
        [Required(ErrorMessage = "*Please enter exercise class time.")]
        [MaxLength(5)]
        [Display(Name = "Exercise Class Time (HH:MM)")]
        public string ExerciseClassTime { get; set; }
        [Required(ErrorMessage = "*Please enter the number enrolled.")]
        [Display(Name = "Number enrolled")]
        public int NumberEnrolled { get; set; }
        [Required(ErrorMessage = "*Please enter the maximum number enrolled allowed.")]
        [Display(Name = "Maximum number enrolled allowed")]
        public int MaximumNumberAllowed { get; set; }
        [Required(ErrorMessage = "*Please select a category for the exercise class.")]
        [Display(Name = "Exercise Class Category")]
        public string CategoryName { get; set; }

        public virtual Category Category { get; set; }
        public virtual Trainer Trainer { get; set; }

        public List<Booking> ClassBookings { get; set; }

    }
}