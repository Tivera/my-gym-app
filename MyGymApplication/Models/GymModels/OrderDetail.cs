using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

    }
}