using BuisinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogic.Implementations
{
    public class BusinessLogicUnitOfWork : IBusinessLogicUnitOfWork
    {
        public IAuthenticationLogic AuthenticationLogic { get; set; }
        public BusinessLogicUnitOfWork(IAuthenticationLogic authenticationLogic)
        {
            AuthenticationLogic = authenticationLogic;
        }
    }
}
