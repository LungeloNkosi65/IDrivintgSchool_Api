using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrivingSchool_Api;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrivingSchoolBackOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTypesController : ControllerBase
    {
        private readonly IServicesUnitOfWork _servicesUnitOfWork; 
        public BookingTypesController(IServicesUnitOfWork servicesUnitOfWork)
        {
            _servicesUnitOfWork = servicesUnitOfWork;
        }

        // GET: api/<BookingTypesController>
        [HttpGet]
        public IActionResult Get()
        {
            var results = _servicesUnitOfWork.BookingTypeService.GatAll().ToList();
            return Ok(results);
        }

        // GET api/<BookingTypesController>/5
        [HttpGet("{id}")]
        public IActionResult GetAll(int? bookingTypeId)
        {
            try
            {
                if (bookingTypeId.HasValue)
                {
                    var results = _servicesUnitOfWork.BookingTypeService.GetSingle(bookingTypeId).ToList();
                    return Ok(results);
                }
                else
                {
                    return BadRequest("Fuck");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<BookingTypesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookingTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
