using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Models;

namespace TeclaT.Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task Save(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> GetById(long id);
        Task<List<T>> GetAllAsync();
        Task DeleteById(long id);
        IQueryable<T> SearchByName(string name);
    }
}
