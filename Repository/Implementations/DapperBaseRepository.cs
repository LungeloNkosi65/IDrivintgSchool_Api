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
        private static readonly string _storedProcReturnValueName = "@return";
        private static readonly string _storedProcReturnValueNameStr = "@hashPassword";

        public int Execute(string query,object parameters)
        {
            using (var connection = DbRepository.SqlConnection())
            {
               return connection.Execute(query,parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ExecuteWithDynamicParameter(string query, object parameters)
        {
            using (var connection = DbRepository.SqlConnection())
            {
                var dynamicParameters = GetParameters(parameters);
                connection.Execute(query, dynamicParameters, commandType: CommandType.StoredProcedure);
                return dynamicParameters.Get<int>(_storedProcReturnValueName);
            }
        }

        public string ExecuteWithDynamicParameterStr(string query, object parameters)
        {
            using (var connection = DbRepository.SqlConnection())
            {
                var dynamicParameters = GetParametersStr(parameters);
                connection.Execute(query, dynamicParameters, commandType: CommandType.StoredProcedure);
                return dynamicParameters.Get<string>(_storedProcReturnValueNameStr);
            }
        }

        public IQueryable<T> Query<T>(string query)
        {
            using (var connection = DbRepository.SqlConnection())
            {
                return connection.Query<T>(query).AsQueryable();
            }
        }

        public T QuerySingl<T>(string query, object parameters = null)
        {
            using(var connection = DbRepository.SqlConnection())
            {
                return connection.QueryFirstOrDefault<T>(query, parameters,commandType:CommandType.StoredProcedure);
            }
        }

        public IQueryable<T> QueryWithParameter<T>(string query, object parameters = null)
        {
            using(var connection = DbRepository.SqlConnection())
            {
                return connection.Query<T>(query, parameters, commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        private DynamicParameters GetParameters(object parameters)
        {
            var dynamicParameters = new DynamicParameters(parameters);
            dynamicParameters.Add(_storedProcReturnValueName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return dynamicParameters;
        }
        private DynamicParameters GetParametersStr(object parameters)
        {
            var dynamicParameters = new DynamicParameters(parameters);
            dynamicParameters.Add(_storedProcReturnValueNameStr, dbType: DbType.String, direction: ParameterDirection.ReturnValue);
            return dynamicParameters;
        }
    }
}
