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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        { }

        public async Task<List<VW_PRODUCTS>> GetAllAsyncProjected()
        {
            return await _context.VW_PRODUCTS.ToListAsync();
        }
    }
}
