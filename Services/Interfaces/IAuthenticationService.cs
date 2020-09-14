using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
   public interface IAuthenticationService
    {
        string ValidateUser(LogInModel logInModel);
    }
}
