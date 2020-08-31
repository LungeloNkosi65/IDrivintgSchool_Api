using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace DrivingSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTypesController : ControllerBase
    {
        private readonly IBookingTypeService _bookingTypeService;
        private readonly IErrorMessageService _errorMessageService;

        public BookingTypesController(IBookingTypeService bookingTypeService,IErrorMessageService errorMessageService)
        {
            _bookingTypeService = bookingTypeService;
            _errorMessageService = errorMessageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var results = _bookingTypeService.GatAll().ToList();
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
                    var results = _bookingTypeService.GetSingle(bkTId).ToList();
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
                    _bookingTypeService.Add(bookingType);
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
                    var dbRecord = _bookingTypeService.GetSingle(bkTId);
                    if (dbRecord.Any())
                    {
                        _bookingTypeService.Delete(bkTId);
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
                    _bookingTypeService.Update(bookingType);
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
