using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Data;
using TeclaT.Models;
using TeclaT.Repository.Interfaces;

namespace TeclaT.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DataContext _context;
        protected DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> SearchByName(string name)
            => _dbSet.Where(x => x.Name.Contains(name));

        public async Task<T> GetById(long id)
            => await _context.Set<T>().FindAsync(id);

        public async virtual void Delete(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual void DeleteById(long id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual void Save(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async virtual void Update(T entity)
        {
            _context.Update<T>(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
