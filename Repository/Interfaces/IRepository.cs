using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Models;

namespace TeclaT.Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Save(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> GetById(long id);
        Task<List<T>> GetAllAsync();
        void DeleteById(long id);
        IQueryable<T> SearchByName(string name);
    }
}
