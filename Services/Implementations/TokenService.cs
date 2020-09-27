using BuisinessLogic.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Services.Implementations
{
    public class TokenService : ItokenService
    {
        private readonly IBusinessLogicUnitOfWork _businessLogicUnitOfWork;
        public TokenService(IBusinessLogicUnitOfWork businessLogicUnitOfWork)
        {
            _businessLogicUnitOfWork = businessLogicUnitOfWork;
        }
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            return _businessLogicUnitOfWork.TokenBsLogic.GenerateAccessToken(claims);
        }

        public string GenerateRefreshToken()
        {
            return _businessLogicUnitOfWork.TokenBsLogic.GenerateRefreshToken();
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            return _businessLogicUnitOfWork.TokenBsLogic.GetPrincipalFromExpiredToken(token);
        }
    }
}
