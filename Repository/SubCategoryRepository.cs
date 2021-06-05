using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Data;
using TeclaT.Models;
using TeclaT.Repository.Interfaces;
using TeclaT.ViewModels;

namespace TeclaT.Repository
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(DataContext context) : base(context)
        { }

        public async Task<List<SubCategoryViewModel>> GetAllAsyncProjected()
        {
            var list = await _context.Set<SubCategory>().Include(x => x.Category).ToListAsync();

            var result = new List<SubCategoryViewModel>();

            foreach (var item in list)
            {
                var entity = new SubCategoryViewModel();
                entity.Name = item.Name;
                entity.Id = item.Id;
                entity.CategoryName = item.Category.Name;
                result.Add(entity);
            }

            return result;
        }
    }
}
