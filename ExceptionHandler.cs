using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;

namespace ErrorHandalingAndLog.Exceptions
{
    public static class ExceptionHandler
    {
        public static void ThrowHttpException(this HttpRequest request, Exception ex)
        {
            //Log error in server Side
            //IErrorLogService _errorLogService = new ErrorLogService();


            //SecurityHeader _securityHeader = HelperMethods.GetHttpHeaderValue(request.Headers.Authorization.Parameter);

            // _errorLogService.LogServerSideError(ex, _securityHeader);

            //if (ex.InnerException != null && (ex.InnerException as SqlException) != null)
            //{
            //    var sqlex = ex.InnerException as SqlException;

            //    //If an entity used in another table then DB system creates a foreign key exception and creates code is 547. 
            //    //DB Command: SELECT  * FROM SYS.messages WHERE message_id = 547 AND (severity BETWEEN 11 AND 16 ) AND language_id = 1033
            //    if (sqlex.Number == 547)
            //    {
            //        if (ex.InnerException.Message.Contains("INSERT"))
            //        {
            //            //Error while deleting data. It has been used in another scope.
            //            ex = (Exception)Activator.CreateInstance(ex.GetType(), "708", ex);
            //        }
            //        else
            //        {
            //            //Error while deleting data. It has been used in another scope.
            //            ex = (Exception)Activator.CreateInstance(ex.GetType(), "703", ex);
            //        }

            //    }
            //    //Unique key or check constaints  viaolation
            //    //DB Command: SELECT  * FROM SYS.messages WHERE message_id = 2601 AND (severity BETWEEN 11 AND 16 ) AND language_id = 1033
            //    else if (sqlex.Number == 2601)
            //    {
            //        ex =
            //            (Exception)
            //                Activator.CreateInstance(ex.GetType(),
            //                    "710", ex);
            //    }
            //    //Primary key or foreign key viaolation
            //    //DB Command: SELECT  * FROM SYS.messages WHERE message_id = 2627 AND (severity BETWEEN 11 AND 16 ) AND language_id = 1033
            //    else if (sqlex.Number == 2627)
            //    {
            //        //{"Violation of UNIQUE KEY constraint 'IX_SET_CommonElement'. Cannot insert duplicate key in object 'dbo.SET_CommonElement'. The duplicate key value is (z, 42).\r\nThe statement has been terminated."}
            //        // {"Violation of PRIMARY KEY constraint 'PK_SET_CommonElement'. Cannot insert duplicate key in object 'dbo.SET_CommonElement'. The duplicate key value is (100000526).\r\nThe statement has been terminated."}
            //        if (ex.InnerException.Message.Contains("UNIQUE KEY"))
            //        {
            //            ex =
            //           (Exception)
            //               Activator.CreateInstance(ex.GetType(),
            //                   "707", ex);
            //        }
            //        else
            //        {
            //            ex =
            //           (Exception)
            //               Activator.CreateInstance(ex.GetType(),
            //                   "709", ex);
            //        }

            //    }
            //    else
            //    {
            //        ex =
            //            (Exception)
            //                Activator.CreateInstance(ex.GetType(),
            //                    "709", ex);
            //    }
            //}
            new HttpResponseException(ex);
            //if (ex.GetType() == typeof(ArgumentNullException))
            //{
               
            //}
            //else if (ex.GetType() == typeof(ArgumentOutOfRangeException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            //}
            //else if (ex.GetType() == typeof(ArrayTypeMismatchException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.Ambiguous, ex.Message));
            //}
            //else if (ex.GetType() == typeof(DirectoryNotFoundException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message));
            //}
            //else if (ex.GetType() == typeof(DivideByZeroException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotImplemented, ex.Message));
            //}
            //else if (ex.GetType() == typeof(FileNotFoundException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message));
            //}
            //else if (ex.GetType() == typeof(FormatException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ex.Message));
            //}
            //else if (ex.GetType() == typeof(IndexOutOfRangeException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.RequestedRangeNotSatisfiable, ex.Message));
            //}
            //else if (ex.GetType() == typeof(InvalidCastException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message));
            //}
            //else if (ex.GetType() == typeof(InvalidOperationException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message));
            //}
            //else if (ex.GetType() == typeof(IOException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message));
            //}
            //else if (ex.GetType() == typeof(KeyNotFoundException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message));
            //}
            //else if (ex.GetType() == typeof(NotImplementedException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotImplemented, ex.Message));
            //}
            //else if (ex.GetType() == typeof(NullReferenceException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.LengthRequired, ex.Message));
            //}
            //else if (ex.GetType() == typeof(OutOfMemoryException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, ex.Message));
            //}
            //else if (ex.GetType() == typeof(OverflowException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.RequestEntityTooLarge, ex.Message));
            //}
            //else if (ex.GetType() == typeof(StackOverflowException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.RequestEntityTooLarge, ex.Message));
            //}
            //else if (ex.GetType() == typeof(TypeInitializationException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NoContent, ex.Message));
            //}
            //else if (ex.GetType() == typeof(HttpException))
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            //}
            //else
            //{
            //    _exception = new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            //}

        }
    }
}
