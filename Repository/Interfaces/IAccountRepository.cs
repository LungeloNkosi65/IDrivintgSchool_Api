using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public interface IAccountRepository
    {
        int Register(LogInModel logInModel);
        int ValidateUser(LogInModel logInModel);
        int AddRefereshToken(LogInModel logInModel);
        int RefreshToken(string userName, string refreshToken);
        string Validate_User(string UserName, string Password);

    }
}
