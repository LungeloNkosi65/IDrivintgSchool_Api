using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogic.Interfaces
{
   public interface IBusinessLogicUnitOfWork
    {
         IAuthenticationLogic AuthenticationLogic { get; set; }
         ITokenBsLogic TokenBsLogic { get; set; }
        ICryptoHelper CryptoHelper { get; set; }
    }
}
