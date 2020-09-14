using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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
                var tokenString = _servicesUnitOfWork.AuthenticationService.ValidateUser(user);
                if (user == null)
                {
                    return BadRequest();
                }
                else if(tokenString != "Invalid")
                {
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
