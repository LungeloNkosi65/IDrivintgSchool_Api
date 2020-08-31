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
    public class BookingPackagesController : ControllerBase
    {
        private readonly IBookingPackageService _bookingPackageService;
        private readonly IErrorMessageService<BookingPackagesController> _errorMessageService;

        public BookingPackagesController(IBookingPackageService bookingPackageService,IErrorMessageService<BookingPackagesController> errorMessageService)
        {
            _bookingPackageService = bookingPackageService;
            _errorMessageService = errorMessageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var results = _bookingPackageService.GatAll().ToList();
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
        [Route("GetVm")]
        public IActionResult GetVmDetails(int? bookiTypeId)
        {
            try
            {
                if (bookiTypeId.HasValue)
                {
                    var results = _bookingPackageService.GetVmDetails(bookiTypeId).ToList();
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

        [HttpGet]
        [Route("GetSingleRecord")]
        public IActionResult GetSingleRecord(int? bkpId)
        {
            try
            {
                if (bkpId.HasValue)
                {
                    var results = _bookingPackageService.GetSingle(bkpId).ToList();
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
        public IActionResult Create(BookingPackage bookingPackage)
        {
            try
            {
                if (bookingPackage != null)
                {
                    _bookingPackageService.Add(bookingPackage);
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
        public IActionResult Delete(int? bkpId)
        {
            try
            {
                if (bkpId.HasValue)
                {
                    var dbRecord = _bookingPackageService.GetSingle(bkpId);
                    if (dbRecord.Any())
                    {
                        _bookingPackageService.Delete(bkpId);
                        return Ok(_errorMessageService.DeleteSuccess(bkpId));
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
        public IActionResult Update(int? bkpId,BookingPackage bookingPackage)
        {

            try
            {
                if (bkpId.HasValue && bookingPackage != null && bkpId == bookingPackage.BookingTypeId)
                {
                    _bookingPackageService.Update(bookingPackage);
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
