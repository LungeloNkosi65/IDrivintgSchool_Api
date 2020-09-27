using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Models;
using Services.Interfaces;

namespace DrivingSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServicesUnitOfWork _servicesUnitOfWork;
        public TokenController(IServicesUnitOfWork servicesUnitOfWork)
        {
            _servicesUnitOfWork = servicesUnitOfWork;
        }

        [HttpPost]
        [Route("Refresh")]
        public IActionResult Refresh(TokenApiModel tokenApiModel)
        {
            if(tokenApiModel is null)
            {
                return BadRequest("Invalid client request");
            }
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = _servicesUnitOfWork.TokenService.GetPrincipalFromExpiredToken(accessToken);
            var userName = principal.Identity.Name; //this is mapped to the Name cliam by default
            var newAccessToken = _servicesUnitOfWork.TokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _servicesUnitOfWork.TokenService.GenerateRefreshToken();
            int results = _servicesUnitOfWork.AuthenticationService.RefreshToke(userName, newRefreshToken);
            if (results == 0)
                return new ObjectResult (new
                { accessToken = newAccessToken, refreshToken = newRefreshToken });
            return BadRequest("User Not Found");
        }
        [HttpPost,Authorize]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            return Ok("I Will get back to you");
        }


    }
}
