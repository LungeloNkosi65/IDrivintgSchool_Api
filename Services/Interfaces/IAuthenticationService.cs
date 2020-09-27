using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAuthenticationService
    {
        string ValidateUser(LogInModel logInModel);
        int Validate_User(LogInModel logInModel);
        int AddRefereshToken(LogInModel logInModel);
        int RefreshToke(string userName, string refreshToken);
        int Register(LogInModel logInModel);
    }
}
