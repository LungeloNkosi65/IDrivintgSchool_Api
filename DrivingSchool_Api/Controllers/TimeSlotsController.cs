using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;

namespace DrivingSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotsController : ControllerBase
    {
        private readonly ITimeSlotService _timeSlotService;
        private readonly IErrorMessageService _errorMessageService;

        public TimeSlotsController(ITimeSlotService timeSlotService,IErrorMessageService errorMessageService)
        {
            _timeSlotService = timeSlotService;
            _errorMessageService = errorMessageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var results = _timeSlotService.GetAll().ToList();
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
        public IActionResult GetSingleRecord(int? timeId)
        {
            try
            {
                if (timeId.HasValue)
                {
                    var result = _timeSlotService.GetSingleRecord(timeId).ToList();
                    if (result.Any())
                    {
                        return Ok(result);
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
        public IActionResult Create(TimeSlot timeSlot)
        {
            try
            {
                if (timeSlot != null)
                {
                    _timeSlotService.Add(timeSlot);
                    return Ok(_errorMessageService.AddSuccessMessage());
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {

                return BadRequest( _errorMessageService.BadRequest(ex));
            }
        }

        [HttpDelete]

        public IActionResult Delete(int? timeId)
        {
            try
            {
                if (timeId.HasValue)
                {
                    var dbRecord = _timeSlotService.GetSingleRecord(timeId);
                    if (dbRecord.Any())
                    {
                        _timeSlotService.Delete(timeId);
                        // Test if passing an id of int or what ever data type would work when the interface expects an object type
                        return Ok(_errorMessageService.DeleteSuccess(timeId));
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
        public IActionResult Update(int? timeId, TimeSlot timeSlot)
        {
            try
            {
                if(timeId.HasValue && timeId!=null && timeId == timeSlot.TimeId)
                {
                    _timeSlotService.Update(timeSlot);
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
