using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Enums;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrivingSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IServicesUnitOfWork _servicesUnitOfWork;
        private readonly IErrorMessageService<BookingPackagesController> _errorMessageService;
        public BookingsController(IServicesUnitOfWork servicesUnitOfWork, IErrorMessageService<BookingPackagesController> errorMessageService)
        {
            _servicesUnitOfWork = servicesUnitOfWork;
            _errorMessageService = errorMessageService;
        }
        // GET: api/<BookingsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var userName = User.Identity.Name;
                var results = _servicesUnitOfWork.BookingService.GetAll().ToList();
                return User.IsInRole("Customer") ? Ok(results.Where(x=>x.CustomerEmail==userName)) : Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<BookingsController>/5
        [HttpGet]
        [Route("GetSingle")]
        public IActionResult GetSingle(int? bookingId)
        {
            try
            {
                if (bookingId.HasValue)
                {
                    
                    var results = _servicesUnitOfWork.BookingService.GetSingle(bookingId);
                    return Ok(results);
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<BookingsController>
        [HttpPost]
        public IActionResult Post([FromBody] Booking booking)
        {
            try
            {
                if (booking != null)
                {
                    var results = _servicesUnitOfWork.BookingService.Add(booking);
                    var enumResults = (EnumService.CrudResult)results;
                    switch (enumResults)
                    {
                        case EnumService.CrudResult.Success:
                            return Ok(_errorMessageService.AddSuccessMessage());
                        case EnumService.CrudResult.Fialed:
                            return BadRequest(_errorMessageService.DateValidation());
                        case EnumService.CrudResult.Exisist:
                            return BadRequest(_errorMessageService.TimeSlotTaken());
                        default:
                            return BadRequest();
                    }
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BookingsController>/5
        [HttpPut]
        public IActionResult Update([FromBody] Booking booking)
        {
            try
            {

                var dbRecord = _servicesUnitOfWork.BookingService.GetSingle(booking.BookingId);
                if (dbRecord!=null && booking != null)
                {
                    var results = _servicesUnitOfWork.BookingService.Update(booking);
                    return Ok(_errorMessageService.UpdateSuccess());
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete]
        public IActionResult Delete(int? bookingId)
        {
            try
            {
                var dbRecord = _servicesUnitOfWork.BookingService.GetSingle(bookingId);

                if (bookingId.HasValue && dbRecord!=null)
                {
                    var results = _servicesUnitOfWork.BookingService.Delete(bookingId);
                    return Ok(_errorMessageService.DeleteSuccess(bookingId));
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
