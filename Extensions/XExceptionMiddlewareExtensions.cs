using ErrorHandalingAndLog.Exceptions;
using ErrorHandalingAndLog.LoggerService;
using ErrorHandalingAndLog.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ErrorHandalingAndLog.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = contextFeature.Error; // Your exception
                    if (((HttpResponseException)exception).Status > 0)
                        context.Response.StatusCode = ((HttpResponseException)exception).Status;

                    if (contextFeature != null)
                    {
                        //log here
                        //logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message.ToString()
                        }.ToString());
                    }
                });
            });
        }
    }
}
