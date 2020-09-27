using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Services.Interfaces
{
   public interface ItokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}
