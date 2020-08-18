using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class DbRepository
    {
        private static readonly string _connectionString = "Server=(LocalDb)\\LocalDb.;Database=DrivingSchoolDb;Trusted_Connection=True;";
        public static SqlConnection SqlConnection()
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }
    }
}
