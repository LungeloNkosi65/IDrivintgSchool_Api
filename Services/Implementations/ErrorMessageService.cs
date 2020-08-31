using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class ErrorMessageService : IErrorMessageService
    {
        public string AddSuccessMessage()
        {
            return "Record Added Successfully";
        }

        public string CrudFailureFailure()
        {
            return "There was an error while processing your request";
        }

        public string BadRequest(Exception ex)
        {
            return $"An error occured while processing your request {ex}";
        }

        public string DeleteSuccess(object id)
        {
            return $"Record with Id : {id} successfully deleted";
        }

        public string NotFound()
        {
            return $"[There were no records found please try again]";
        }

        public string NullParameter()
        {
            return ("There was an error while proccessing your request : Null parameter submited");
        }

        public string UpdateSuccess()
        {
            return "Record Updated Successfully";
        }
    }
}
