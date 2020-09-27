using BuisinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogic.Implementations
{
    public class BusinessLogicUnitOfWork : IBusinessLogicUnitOfWork
    {
        public IAuthenticationLogic AuthenticationLogic { get; set; }
        public ITokenBsLogic TokenBsLogic { get; set; }
        public ICryptoHelper CryptoHelper { get; set; }

        public BusinessLogicUnitOfWork(IAuthenticationLogic authenticationLogic, ITokenBsLogic tokenBsLogic,ICryptoHelper cryptoHelper)
        {
            AuthenticationLogic = authenticationLogic;
            TokenBsLogic = tokenBsLogic;
            CryptoHelper = cryptoHelper;
        }
    }
}
