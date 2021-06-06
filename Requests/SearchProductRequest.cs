using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeclaT.Requests
{
    public class SearchProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKUCode { get; set; }
        public double? Price { get; set; }
        public long? CategoryId { get; set; }
        public long? SubCategoryId { get; set; }
    }
}
