using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDapperBaseRepository _dapperBaseRepository;

        public AccountRepository(IDapperBaseRepository dapperBaseRepository)
        {
            _dapperBaseRepository = dapperBaseRepository;
        }

        public int AddRefereshToken(LogInModel logInModel)
        {
            string sqlCommand = "AddRefreshToken";
            var parameters = new
            {
                logInModel.UserName,
                logInModel.RefereshToken,
                logInModel.RefreshTokenExpiryTime
            };
            return _dapperBaseRepository.ExecuteWithDynamicParameter(sqlCommand, parameters);
        }

        public int RefreshToken(string userName, string refreshToken)
        {
            var parameters = new { userName, refreshToken };
            return _dapperBaseRepository.ExecuteWithDynamicParameter("RefreshToken", parameters);
        }

        public int Register(LogInModel logInModel)
        {
            var parameters = new
            {
                logInModel.UserId,
                logInModel.UserName,
                logInModel.Password
            };
            return _dapperBaseRepository.ExecuteWithDynamicParameter("Register", parameters);
        }

        public int ValidateUser(LogInModel logInModel)
        {
            string sqlCommand = "ValidateUser";
            var parameters = new
            {
                logInModel.UserName,
                logInModel.Password
            };
            return _dapperBaseRepository.ExecuteWithDynamicParameter(sqlCommand, parameters);
        }

        public string Validate_User(string UserName,string Password)
        {
            string sqlCommand = "ValidateUser";
            string hashPassword = "";
            var parameters = new
            {
                UserName,
                Password,
                @hashPassword= hashPassword
            };
            return _dapperBaseRepository.ExecuteWithDynamicParameterStr(sqlCommand, parameters);
        }
    }
}
