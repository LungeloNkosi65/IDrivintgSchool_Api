using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class ErrorMessageService<T> : IErrorMessageService<T>
    {
        private readonly ILogger<T> _logger;

        public ErrorMessageService(ILogger<T> logger)
        {
            _logger = logger;
        }
        public string AddSuccessMessage()
        {
            _logger.LogInformation("Post Request: Successfull");
            return "Record Added Successfully";
        }

        public string CrudFailureFailure()
        {
            return "There was an error while processing your request";
        }

        public string BadRequest(Exception ex)
        {
            //_logger.LogError("An error occured while processing your request", ex);
            return $"An error occured while processing your request {ex}";
        }

        public string DeleteSuccess(object id)
        {
            return  $"Record with Id : {id} successfully deleted";
        }

        public string NotFound()
        {
            return $"{"There were no records found please try again"}";
        }

        public string NullParameter()
        {
            //_logger.LogError("An error occured while processing request : Null parameter submited");
            return ("There was an error while proccessing your request : Null parameter submited");
        }

        public string UpdateSuccess()
        {
            _logger.LogInformation("Put Request: Successfull");
            return "Record Updated Successfully";
        }
    }
}
