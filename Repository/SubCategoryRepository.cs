using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Data;
using TeclaT.Models;
using TeclaT.Repository.Interfaces;

namespace TeclaT.Repository
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(DataContext context) : base(context)
        { }
    }
}
