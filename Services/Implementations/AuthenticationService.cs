using BuisinessLogic.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repository.Interfaces;
using Services.Enums;
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
        private readonly IAccountRepository _accountRepository;
        public AuthenticationService(IBusinessLogicUnitOfWork businessLogicUnitOfWork,IAccountRepository accountRepository)
        {
            _businessLogicUnitOfWork = businessLogicUnitOfWork;
            _accountRepository = accountRepository;
        }

        public int AddRefereshToken(LogInModel logInModel)
        {
            try
            {
                return _accountRepository.AddRefereshToken(logInModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }   
        }
        public int RefreshToke(string userName, string refreshToken)
        {
            return _accountRepository.RefreshToken(userName, refreshToken);
        }
        public int Register(LogInModel logInModel)
        {
            logInModel.UserId = _businessLogicUnitOfWork.AuthenticationLogic.GenerateGuiId();
            logInModel.Password = _businessLogicUnitOfWork.CryptoHelper.HashPassword(logInModel.Password);
            return _accountRepository.Register(logInModel);
        }
        public string ValidateUser(LogInModel logInModel)
        {
            //Old One
            if (_businessLogicUnitOfWork.AuthenticationLogic.ValidateUser(logInModel))
            {
                return _businessLogicUnitOfWork.AuthenticationLogic.GenerateToke(logInModel);
            }
            return "Invalid";
        }

        public int Validate_User(LogInModel logInModel)
        {
            var hashPassword = _accountRepository.Validate_User(logInModel.UserName,logInModel.Password);
            var result = _accountRepository.ValidateUser(logInModel);
            if (_businessLogicUnitOfWork.CryptoHelper.VerifyPassword(hashPassword, logInModel.Password))
            {
                result = 0;
            }
            return result;
        }
    }
}
