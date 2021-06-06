using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeclaT.Models
{
    public class Product : Entity
    {
        
        [Required(ErrorMessage = "This field is required")]
        public string SKUCode { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero!")]
        public double Price { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Invalid SubCategory")]
        public long SubCategoryId { get; set; }
        
        public SubCategory SubCategory { get; set; }
    }
}
