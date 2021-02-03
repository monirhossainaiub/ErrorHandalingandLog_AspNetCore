using ErrorHandalingAndLog.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;


namespace ErrorHandalingAndLog.Exceptions
{
    
    internal class HttpExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public HttpExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch (Exception ex)
            {
                HttpResponseException exp = new HttpResponseException(ex);
                context.Response.ContentType = "application/json";
                if (exp.Status > 0)
                    context.Response.StatusCode = exp.Status;

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message
                }.ToString());
            }
        }
    }
}
