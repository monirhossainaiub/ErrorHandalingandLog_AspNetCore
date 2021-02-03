using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ErrorHandalingAndLog.Exceptions
{
    public class HttpResponseException : Exception
    {



        public int Status { get; set; }

        public object Value { get; set; }
     
        public HttpResponseException(Exception ex) : base(ex.Message)
        {
            GenerateException(ex);
        }
        public HttpResponseException(int httpStatusCode, string message) : base(message)
        {
            this.Status = httpStatusCode;
        }
        
        private void GenerateException(Exception ex)
        {

            if (ex.InnerException != null && (ex.InnerException as SqlException) != null)
            {
                var sqlex = ex.InnerException as SqlException;

                //If an entity used in another table then DB system creates a foreign key exception and creates code is 547. 
                //DB Command: SELECT  * FROM SYS.messages WHERE message_id = 547 AND (severity BETWEEN 11 AND 16 ) AND language_id = 1033
                if (sqlex.Number == 547)
                {
                    if (ex.InnerException.Message.Contains("INSERT"))
                    {
                        //Error while deleting data. It has been used in another scope.
                        ex = (Exception)Activator.CreateInstance(ex.GetType(), "708", ex);
                    }
                    else
                    {
                        //Error while deleting data. It has been used in another scope.
                        ex = (Exception)Activator.CreateInstance(ex.GetType(), "703", ex);
                    }

                }
                //Unique key or check constaints  viaolation
                //DB Command: SELECT  * FROM SYS.messages WHERE message_id = 2601 AND (severity BETWEEN 11 AND 16 ) AND language_id = 1033
                else if (sqlex.Number == 2601)
                {
                    ex =
                        (Exception)
                            Activator.CreateInstance(ex.GetType(),
                                "710", ex);
                }
                //Primary key or foreign key viaolation
                //DB Command: SELECT  * FROM SYS.messages WHERE message_id = 2627 AND (severity BETWEEN 11 AND 16 ) AND language_id = 1033
                else if (sqlex.Number == 2627)
                {
                    //{"Violation of UNIQUE KEY constraint 'IX_SET_CommonElement'. Cannot insert duplicate key in object 'dbo.SET_CommonElement'. The duplicate key value is (z, 42).\r\nThe statement has been terminated."}
                    // {"Violation of PRIMARY KEY constraint 'PK_SET_CommonElement'. Cannot insert duplicate key in object 'dbo.SET_CommonElement'. The duplicate key value is (100000526).\r\nThe statement has been terminated."}
                    if (ex.InnerException.Message.Contains("UNIQUE KEY"))
                    {
                        ex =
                       (Exception)
                           Activator.CreateInstance(ex.GetType(),
                               "707", ex);
                    }
                    else
                    {
                        ex =
                       (Exception)
                           Activator.CreateInstance(ex.GetType(),
                               "709", ex);
                    }

                }
                else
                {
                    ex =
                        (Exception)
                            Activator.CreateInstance(ex.GetType(),
                                "709", ex);
                }
            }



            if (ex.GetType() == typeof(ArgumentNullException))
            {
                Status = (int)HttpStatusCode.BadRequest;
            }
            else if (ex.GetType() == typeof(ArgumentOutOfRangeException))
            {
                Status = (int)HttpStatusCode.BadRequest;
            }
            else if (ex.GetType() == typeof(ArrayTypeMismatchException))
            {
                Status = (int)HttpStatusCode.Ambiguous;
            }
            else if (ex.GetType() == typeof(DirectoryNotFoundException))
            {
                Status = (int)HttpStatusCode.NotFound;
            }
            else if (ex.GetType() == typeof(DivideByZeroException))
            {
                Status = (int)HttpStatusCode.NotImplemented;
            }
            else if (ex.GetType() == typeof(FileNotFoundException))
            {
                Status = (int)HttpStatusCode.NotFound;
            }
            else if (ex.GetType() == typeof(FormatException))
            {
                Status = (int)HttpStatusCode.MethodNotAllowed;
            }
            else if (ex.GetType() == typeof(IndexOutOfRangeException))
            {
                Status = (int)HttpStatusCode.RequestedRangeNotSatisfiable;
            }
            else if (ex.GetType() == typeof(InvalidCastException))
            {
                Status = (int)HttpStatusCode.ExpectationFailed;
            }
            else if (ex.GetType() == typeof(InvalidOperationException))
            {
                Status = (int)HttpStatusCode.ExpectationFailed;
            }
            else if (ex.GetType() == typeof(IOException))
            {
                Status = (int)HttpStatusCode.ExpectationFailed;
            }
            else if (ex.GetType() == typeof(KeyNotFoundException))
            {
                Status = (int)HttpStatusCode.ExpectationFailed;
            }
            else if (ex.GetType() == typeof(NotImplementedException))
            {
                Status = (int)HttpStatusCode.NotImplemented;
            }
            else if (ex.GetType() == typeof(NullReferenceException))
            {
                Status = (int)HttpStatusCode.LengthRequired;
            }
            else if (ex.GetType() == typeof(OutOfMemoryException))
            {
                Status = (int)HttpStatusCode.UnsupportedMediaType;
            }
            else if (ex.GetType() == typeof(OverflowException))
            {
                Status = (int)HttpStatusCode.RequestEntityTooLarge;
            }
            else if (ex.GetType() == typeof(StackOverflowException))
            {
                Status = (int)HttpStatusCode.RequestEntityTooLarge;
            }
            else if (ex.GetType() == typeof(TypeInitializationException))
            {
                Status = (int)HttpStatusCode.NoContent;
            }
            else if (ex.GetType() == typeof(HttpException))
            {
                Status = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                Status = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
