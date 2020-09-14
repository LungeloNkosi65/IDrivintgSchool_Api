using BuisinessLogic.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IBusinessLogicUnitOfWork _businessLogicUnitOfWork;
        public AuthenticationService(IBusinessLogicUnitOfWork businessLogicUnitOfWork)
        {
            _businessLogicUnitOfWork = businessLogicUnitOfWork;
        }

        public string ValidateUser(LogInModel logInModel)
        {
            if (_businessLogicUnitOfWork.AuthenticationLogic.ValidateUser(logInModel))
            {
                return _businessLogicUnitOfWork.AuthenticationLogic.GenerateToke(logInModel);
            }
            return "Invalid";
        }
    }
}
