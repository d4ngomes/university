using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.ToList();
        }

        public T GetByID(object id)
        {
            return _db.Find(id);
        }

        public void Insert(T entity)
        {
            _db.Add(entity);
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }

        public void Delete(object id)
        {
            T entity = _db.Find(id);
            _db.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
