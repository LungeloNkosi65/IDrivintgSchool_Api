using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace DrivingSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookingTypesController : ControllerBase
    {
        private readonly IServicesUnitOfWork _servicesUnitOfWork;
        private readonly IErrorMessageService<BookingTypesController> _errorMessageService;

        public BookingTypesController(IServicesUnitOfWork  servicesUnitOfWork,IErrorMessageService<BookingTypesController> errorMessageService)
        {
            _servicesUnitOfWork = servicesUnitOfWork;
            _errorMessageService = errorMessageService;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            try
            {
                var results = _servicesUnitOfWork.BookingTypeService.GatAll().ToList();
                if (results.Any())
                {
                    return Ok(results);
                }
                else
                {
                    return NotFound(_errorMessageService.NotFound());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(_errorMessageService.BadRequest(ex));
            }
        }

        [HttpGet]
        [Route("GetSingleRecord")]
        public IActionResult GetSingle(int? bkTId)
        {
            try
            {
                if (bkTId.HasValue)
                {
                    var results = _servicesUnitOfWork.BookingTypeService.GetSingle(bkTId).ToList();
                    if (results.Any())
                    {
                        return Ok(results);
                    }
                    else
                    {
                        return NotFound(_errorMessageService.NotFound());
                    }
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(_errorMessageService.BadRequest(ex));
            }
        }

        [HttpPost]
        public IActionResult Create(BookingType bookingType)
        {
            try
            {
                if (bookingType !=null)
                {
                    _servicesUnitOfWork.BookingTypeService.Add(bookingType);
                    return Ok(_errorMessageService.AddSuccessMessage());
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(_errorMessageService.BadRequest(ex));
            }
        }

        [HttpDelete]
        public IActionResult Delete(int? bkTId)
        {
            try
            {
                if (bkTId.HasValue)
                {
                    var dbRecord = _servicesUnitOfWork.BookingTypeService.GetSingle(bkTId);
                    if (dbRecord.Any())
                    {
                        _servicesUnitOfWork.BookingTypeService.Delete(bkTId);
                        return Ok(_errorMessageService.DeleteSuccess(bkTId));
                    }
                    else
                    {
                        return NotFound(_errorMessageService.NotFound());
                    }
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(_errorMessageService.BadRequest(ex));
            }
        }

        [HttpPut]
        public IActionResult Update(int? bkTId, BookingType bookingType)
        {
            try
            {
                if(bkTId.HasValue && bookingType!=null && bkTId == bookingType.BookingTypeId)
                {
                    _servicesUnitOfWork.BookingTypeService.Update(bookingType);
                    return Ok(_errorMessageService.UpdateSuccess());
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(_errorMessageService.BadRequest(ex));
            }
        }


    }
}
