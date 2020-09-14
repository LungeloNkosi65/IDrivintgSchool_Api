using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogic.Interfaces
{
    public interface IAuthenticationLogic
    {
        string GenerateToke(LogInModel validUser);

        bool ValidateUser(LogInModel logInModel);
    } 
}
