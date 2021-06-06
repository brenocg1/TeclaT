using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Data;
using TeclaT.Models;
using TeclaT.Repository.Interfaces;
using TeclaT.Requests;
using TeclaT.ViewModels;

namespace TeclaT.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        { }

        public async Task<List<VW_PRODUCTS>> GetAllAsyncProjected()
        {
            return await _context.VW_PRODUCTS.ToListAsync();
        }

        public List<ProductViewModel> SearchProduct(SearchProductRequest request)
        {
            var query = _context.Set<Product>().Where(x => x.Id == x.Id);

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(x => x.Name.Contains(request.Name));
            }

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                query = query.Where(x => x.Description.Contains(request.Description));
            }

            if (request.Price.HasValue)
            {
                query = query.Where(x => x.Price.Equals(request.Price));
            }

            if (!string.IsNullOrWhiteSpace(request.SKUCode))
            {
                query = query.Where(x => x.SKUCode.Equals(request.SKUCode));
            }

            if (request.SubCategoryId != null)
            {
                query = query.Where(x => x.SubCategoryId == request.SubCategoryId);
            }

            if (request.CategoryId != null)
            {
                query = query.Where(x => x.SubCategory.CategoryId == request.CategoryId);
            }

            query = query.Include(x => x.SubCategory).ThenInclude(x => x.Category);

            var result = new List<ProductViewModel>();

            foreach (var item in query)
            {
                var entity = new ProductViewModel();
                entity.Id = item.Id;
                entity.Description = item.Description;
                entity.SKU = item.SKUCode;
                entity.SubCategoryName = item.SubCategory.Name;
                entity.CategoryName = item.SubCategory.Category.Name;
                entity.CategoryId = item.SubCategory.CategoryId;
                entity.SubCategoryId = item.SubCategoryId;

                result.Add(entity);
            }

            return result;
        }
    }
}
