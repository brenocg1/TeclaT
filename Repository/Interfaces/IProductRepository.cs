using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Models;
using TeclaT.Requests;
using TeclaT.ViewModels;

namespace TeclaT.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<VW_PRODUCTS>> GetAllAsyncProjected();
        List<ProductViewModel> SearchProduct(SearchProductRequest request);
    }
}
