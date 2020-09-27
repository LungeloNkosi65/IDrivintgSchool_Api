using BuisinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CryptoHelper;

namespace BuisinessLogic.Implementations
{
    public class CryptoHelperBsLogic : ICryptoHelper
    {
        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }  
    }
}
