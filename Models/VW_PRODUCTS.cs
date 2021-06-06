using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeclaT.Models
{
    public class VW_PRODUCTS
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKUCode { get; set; }
        public double Price { get; set; }
        public string SubCategory { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
    }
}
