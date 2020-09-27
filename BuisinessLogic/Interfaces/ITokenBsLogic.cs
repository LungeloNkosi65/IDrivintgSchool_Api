﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BuisinessLogic.Interfaces
{
  public  interface ITokenBsLogic
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
