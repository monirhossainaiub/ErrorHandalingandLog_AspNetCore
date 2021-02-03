﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandalingAndLog.Exceptions
{
    //public class ErrorHandlerMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    private readonly ErrorHandlerOptions _options;
    //    private readonly ILogger _logger;

    //    public ErrorHandlerMiddleware(RequestDelegate next,
    //                                  ILoggerFactory loggerFactory,
    //                                  ErrorHandlerOptions options)
    //    {
    //        _next = next;
    //        _options = options;
    //        _logger = loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
    //        if (_options.ErrorHandler == null)
    //        {
    //            _options.ErrorHandler = _next;
    //        }
    //    }

    //    public async Task Invoke(HttpContext context)
    //    {
    //        try
    //        {
    //            await _next(context);
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError("An unhandled exception has occurred: " + ex.Message, ex);

    //            if (context.Response.HasStarted)
    //            {
    //                _logger.LogWarning("The response has already started, 
    
    //                                    the error handler will not be executed.");
    
    //                throw;
    //            }

    //            PathString originalPath = context.Request.Path;
    //            if (_options.ErrorHandlingPath.HasValue)
    //            {
    //                context.Request.Path = _options.ErrorHandlingPath;
    //            }
    //            try
    //            {
    //                var errorHandlerFeature = new ErrorHandlerFeature()
    //                {
    //                    Error = ex,
    //                };
    //                context.SetFeature<IErrorHandlerFeature>(errorHandlerFeature);
    //                context.Response.StatusCode = 500;
    //                context.Response.Headers.Clear();

    //                await _options.ErrorHandler(context);
    //                return;
    //            }
    //            catch (Exception ex2)
    //            {
    //                _logger.LogError("An exception was thrown attempting
    
    //                                  to execute the error handler.", ex2);
    //            }
    //            finally
    //            {
    //                context.Request.Path = originalPath;
    //            }

    //            throw; // Re-throw the original if we couldn't handle it
    //        }
    //    }
    //}
}
