using Dapper;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repository.Implementations
{
    public class DapperBaseRepository : IDapperBaseRepository
    {
        public IQueryable<T> Query<T>(string query)
        {
            using (var connection = DbRepository.SqlConnection())
            {
                return connection.Query<T>(query).AsQueryable();
            }
        }

        public IQueryable<T> QuerySingl<T>(string query, object parameters = null)
        {
            using(var connection = DbRepository.SqlConnection())
            {
                return connection.Query<T>(query, parameters, commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IQueryable<T> QueryWithParameter<T>(string query, object parameters = null)
        {
            using(var connection = DbRepository.SqlConnection())
            {
                return connection.Query<T>(query, parameters, commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }
    }
}
