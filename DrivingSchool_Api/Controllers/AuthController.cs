using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Enums;
using Services.Interfaces;

namespace DrivingSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServicesUnitOfWork _servicesUnitOfWork;
        public AuthController(IServicesUnitOfWork servicesUnitOfWork)
        {
            _servicesUnitOfWork = servicesUnitOfWork;
        }
        [HttpPost,Route("Login")]
        public IActionResult LogIn([FromBody]LogInModel user)
        {
            try
            {
                //var tokenString = _servicesUnitOfWork.AuthenticationService.ValidateUser(user);
                var validateaResults = _servicesUnitOfWork.AuthenticationService.Validate_User(user);
                var IsUserValid = (EnumService.UserStatus)validateaResults ;
                switch (IsUserValid)
                {
                    case EnumService.UserStatus.Valid:
                        var claims = new List<Claim>
                        {
                              new Claim(ClaimTypes.Name,user.UserName),
                               new Claim(ClaimTypes.Role,"Admin")
                        };
                        var refreshToken = _servicesUnitOfWork.TokenService.GenerateRefreshToken();
                        var accessToken = _servicesUnitOfWork.TokenService.GenerateAccessToken(claims);  // you need to add the claims here
                        user.RefereshToken = refreshToken;
                        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                        _servicesUnitOfWork.AuthenticationService.AddRefereshToken(user);
                        var principal = _servicesUnitOfWork.TokenService.GetPrincipalFromExpiredToken(accessToken);
                        var userName = principal.Identity.Name; //this is mapped to the Name cliam by default
                        return StatusCode(200,new { Token = accessToken, RefreshToken = refreshToken ,UserName=userName});

                    case EnumService.UserStatus.Null:
                        return Unauthorized();
                    default:
                        return BadRequest(Unauthorized());
                }
                //if (user == null)
                //{
                //    return BadRequest();
                //}
                //else if(tokenString != "Invalid")
                //{
                //    return Ok(new { Token = tokenString });
                //}
                //else
                //{
                //    return Unauthorized();
                //}
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(LogInModel logInModel)
        {
            try
            {
                var results = _servicesUnitOfWork.AuthenticationService.Register(logInModel);
                var enumReslts = (EnumService.RegisterResults)results;
                return enumReslts switch
                {
                    EnumService.RegisterResults.Success => Ok("User successfully Registerd"),
                    EnumService.RegisterResults.Fialed => BadRequest("One or more validation errors occured"),
                    EnumService.RegisterResults.Exists => BadRequest("User Name is already taken please use another UserName"),
                    _ => BadRequest("There was an error while proccessing your request"),
                };
                ;
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
