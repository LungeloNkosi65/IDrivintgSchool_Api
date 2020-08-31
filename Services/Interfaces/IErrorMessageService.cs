using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IErrorMessageService<T>
    {
        string AddSuccessMessage();
        string UpdateSuccess();
        string CrudFailureFailure();
        string BadRequest(Exception ex);

        string DeleteSuccess(object id);

        string NullParameter();
        string NotFound();
    }
}
