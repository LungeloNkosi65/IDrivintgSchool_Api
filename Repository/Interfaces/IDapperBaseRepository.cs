using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
   public interface IDapperBaseRepository
    {
        int Execute(string query,object parameters);
        IQueryable<T> Query<T>(string query);
        IQueryable<T> QuerySingl<T>(string query, object parameters = null);
        IQueryable<T> QueryWithParameter<T>(string query, object parameters = null);

    }
}
