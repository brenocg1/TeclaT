using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeclaT.Models
{
    public class SubCategory : Entity
    {
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
