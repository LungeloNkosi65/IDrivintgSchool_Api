using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Delete(object id);
        void Update(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetSingleRecord(object id);
        T Find(object id);

        IQueryable<T> BookingDetails(object id);
    }
}
