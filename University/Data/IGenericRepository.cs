using System.Collections.Generic;

namespace University.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(object id);
        void Insert(T entity);
        void Delete(object id);
        void Update(T entity);
        void Save();
    }
}