using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogic.Interfaces
{
    public interface ICryptoHelper
    {
        string HashPassword(string password);
        bool VerifyPassword(string hash, string password);
    }
}
