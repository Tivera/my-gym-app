using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class Member
    {
        [Key]
        [Column(Order = 0)]
        public int MemberID { get; set; }

        [Key][Column(Order = 1)]
        [Display(Name = "Membership Number")]
        public string MembershipNumber { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "*Please enter your first name.")]
        public string MemberName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "*Please enter your surname.")]
        public string MemberSurname { get; set; }

        [Key][Column(Order = 4)]
        [Required(ErrorMessage = "*Please enter your I.D number.")]
        [MaxLength(13, ErrorMessage = "*Identity Number Invalid."), MinLength(13, ErrorMessage = "*Identity Number Invalid.")]
        [Display(Name = "ID Number")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "*Please enter your contact number.")]
        [MaxLength(10, ErrorMessage = "*Valid length is 10 digits."), MinLength(10, ErrorMessage = "*Valid length is 10 digits.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "*Please enter your email.")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "*Please enter a valid email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Please enter your password.")]
        [StringLength(50) , MinLength(6, ErrorMessage = "*Password must at least be a minimum of 6 characters.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*Please confirm your password.")]
        [StringLength(50), MinLength(6, ErrorMessage = "*Confirmation password must at least be a minimum of 6 characters.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select a security question.")]
        [Display(Name = "Security Question")] 
        public string SecurityQuestion { get; set; }

        [Required(ErrorMessage = "Please enter the answer to the security question.")]
        [Display(Name = "Answer")]
        public string SecurityQuestionAnswer { get; set; }

        [Required(ErrorMessage = "Please select a membership package.")]
        [Display(Name = "Membership Package")]
        public string PackageName { get; set; }

        [Display(Name = "Date Joined")]
        public System.DateTime DateJoined { get; set; }


        public double MembershipFee { get; set; }

        public int Points { get; set; } = 0;

        public virtual MembershipPackage MembershipPackage { get; set; }

        public List<Booking> ClassBookings { get; set; }
        public List<Order> Orders { get; set; }

    }
}