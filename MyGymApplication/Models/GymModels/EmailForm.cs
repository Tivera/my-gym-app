using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class EmailForm
    {
        [Key]
        public int EmailID { get; set; }

        [Display(Name = "To")]
        [Required(ErrorMessage = "*Please select a recipient.")]
        [DataType(DataType.EmailAddress)]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "*Please enter a message.")]
        [Display(Name = "Body")]
        [DataType(DataType.MultilineText)]
        public string EmailBody { get; set; }

        [Required(ErrorMessage = "*Please enter a subject line.")]
        [Display(Name = "Subject")]
        public string EmailSubject { get; set; }

        
        [Display(Name = "CC")]
        [DataType(DataType.EmailAddress)]
        public string EmailCC { get; set; }

        
        [Display(Name = "BCC")]
        [DataType(DataType.EmailAddress)]
        public string EmailBCC { get; set; }


        //public int TrainerId { get; set; }

        //public string TrainerName { get; set; }

        public virtual Trainer Trainer { get; set; }

    }
}