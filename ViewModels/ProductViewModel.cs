﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeclaT.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
    }
}
