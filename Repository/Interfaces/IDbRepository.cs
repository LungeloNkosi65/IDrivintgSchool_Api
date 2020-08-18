using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IDbRepository
    {
        SqlConnection SqlConnection();
    }
}
