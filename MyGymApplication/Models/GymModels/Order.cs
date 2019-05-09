using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Display(Name = "Membership Number")]
        public string MembershipNumber { get; set; }
        [Display(Name = "Member Name")]
        public string MemberName { get; set; }
        [Display(Name = "Member Surname")]
        public string MemberSurname { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }
        [Display(Name = "Order Quantity")]
        public int OrderTotalQuantity { get; set; }
        [Required(ErrorMessage = "*Plase enter street Address.")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required(ErrorMessage = "*Please enter city.")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage = "*Please enter province.")]
        [Display(Name = "Province")]
        public string Province { get; set; }
        [Required(ErrorMessage = "*Please enter postal code.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "*Please enter country.")]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Time order placed")]
        public System.DateTime OrderTime { get; set; }
        [Required(ErrorMessage = "*Please select order status.")]
        [Display(Name = "Order Status")]
        public string OrderStatus { get; set; }
        [Display(Name = "Payment Outsanding")]
        public bool PaymentOutstanding { get; set; }

        public virtual Member Member { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}