using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        bool Add(T entity);
        bool Delete(object id);
        bool Update(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetSingleRecord(object id);
    }
}
