using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace DrivingSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageInclusionsController : ControllerBase
    {
        private readonly IServicesUnitOfWork _servicesUnitOfWork;
        private readonly IErrorMessageService<PackageInclusionsController> _errorMessageService;
        public PackageInclusionsController(IServicesUnitOfWork servicesUnitOfWork, IErrorMessageService<PackageInclusionsController> errorMessageService)
        {
            _servicesUnitOfWork = servicesUnitOfWork;
            _errorMessageService = errorMessageService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var results = _servicesUnitOfWork.PackageInclusion.GetAll().ToList();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("GetVmForPackage")]
        public IActionResult GetInclusionForPackage(int? bkpId)
        {
            try
            {
                var results = _servicesUnitOfWork.PackageInclusion.GetInclusionForPackage(bkpId).ToList();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public IActionResult GetSingle(int? inclusionId)
        {
            try
            {
                if (inclusionId.HasValue)
                {
                    var results = _servicesUnitOfWork.PackageInclusion.GetSingle(inclusionId);
                    return Ok(results);
                }
                else
                {
                    return BadRequest(_errorMessageService.NullParameter());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Create(PackageInclusions packageInclusions)
        {
            try
            {
                if (packageInclusions != null)
                {
                    var result = _servicesUnitOfWork.PackageInclusion.Add(packageInclusions);
                    if (result == true)
                    {
                        return Ok(_errorMessageService.AddSuccessMessage());
                    }
                    return BadRequest(_errorMessageService.CrudFailureFailure());
                }
                else
                {
                    return BadRequest(_errorMessageService.CrudFailureFailure());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
    }
}
