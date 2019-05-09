using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApplication.Models.GymModels
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "*Please enter product name.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "*Please enter product brand.")]
        [Display(Name = "Product Brand")]
        public string ProductBrand { get; set; }

        [Required(ErrorMessage = "*Please enter product description.")]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "*Please enter product price.")]
        [Display(Name = "Product Price (0.00)")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "*Please enter product size or quantity.")]
        [Display(Name = "Product Size/Quantity")]
        public string ProductSizeQuantity { get; set; }

        [Required(ErrorMessage = "*Please enter product supplier.")]
        [Display(Name = "Product Supplier")]
        public string ProductSupplier { get; set; }

        [Required(ErrorMessage = "Product Image is required.")]
        [Display(Name = "Image URL")]
        public string ProductImagePath { get; set; }

        [Required(ErrorMessage = "*Please select a product category.")]
        [Display(Name = "Product Category Name")]
        public string ProductCategoryName { get; set; }


        public virtual ProductCategory ProductCategory { get; set; }

        public List<Cart> Carts { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}