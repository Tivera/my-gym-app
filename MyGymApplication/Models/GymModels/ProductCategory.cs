using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class ProductCategory
    {
        [Key]
        [MaxLength(30)]
        [Display(Name = "Product Category Name")]
        public string ProductCategoryName { get; set; }

        public List<Product> Products { get; set; }

    }
}