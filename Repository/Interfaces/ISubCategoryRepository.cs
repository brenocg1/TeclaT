using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Models;
using TeclaT.ViewModels;

namespace TeclaT.Repository.Interfaces
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        Task<List<SubCategoryViewModel>> GetAllAsyncProjected();
    }
}
