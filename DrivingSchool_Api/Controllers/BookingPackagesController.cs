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
        private readonly IServicesUnitOfWork _bookingPackageService;
        private readonly IErrorMessageService<BookingPackagesController> _errorMessageService;

        public BookingPackagesController(IServicesUnitOfWork bookingPackageService,IErrorMessageService<BookingPackagesController> errorMessageService)
        {
            _bookingPackageService = bookingPackageService;
            _errorMessageService = errorMessageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var results = _bookingPackageService.BookingPackageService.GatAll().ToList();
                if (results.Any())
                {
                    return Ok(results);
                }
                else
                {
                    return Ok(_errorMessageService.NotFound());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(_errorMessageService.BadRequest(ex));
            }
        }

        [HttpGet]
        [Route("GetVm")]
        public IActionResult GetVmDetails(int? bookingTypeId)
        {
            try
            {
                if (bookingTypeId.HasValue)
                {
                    var results = _bookingPackageService.BookingPackageService.GetVmDetails(bookingTypeId).ToList();
                    if (results.Any())
                    {
                        return Ok(results);
                    }
                    else
                    {
                        return Ok(_errorMessageService.NotFound());
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
                    var results = _bookingPackageService.BookingPackageService.GetSingle(bkpId).ToList();
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
                    _bookingPackageService.BookingPackageService.Add(bookingPackage);
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
                    var dbRecord = _bookingPackageService.BookingPackageService.GetSingle(bkpId);
                    if (dbRecord.Any())
                    {
                        _bookingPackageService.BookingPackageService.Delete(bkpId);
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
                    _bookingPackageService.BookingPackageService.Update(bookingPackage);
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
