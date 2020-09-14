using BuisinessLogic.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuisinessLogic.Implementations
{
    public class AuthenticationLogic : IAuthenticationLogic
    {
        public string GenerateToke(LogInModel validUser)
        {
                var secreteKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secreteKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,validUser.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            };
                var tokeOptions = new JwtSecurityToken(
                      issuer: "http://localhost:56384",
                      audience: "http://localhost:56384",
                      claims: claims,
                      expires: DateTime.Now.AddMinutes(5),
                      signingCredentials: signingCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
        }

        public bool ValidateUser(LogInModel logInModel)
        {
            return logInModel.UserName == "Lungelo" && logInModel.Password == "Lu12345#";

        }
    }
}
