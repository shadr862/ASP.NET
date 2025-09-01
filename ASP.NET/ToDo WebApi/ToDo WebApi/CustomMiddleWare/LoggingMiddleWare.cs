using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ToDo_WebApi.CustomMiddleWare
{
    public class LoggingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleWare> _logger;

        public LoggingMiddleWare(RequestDelegate next, ILogger<LoggingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unexpected error occurred.");
            //More log stuff        

            ExceptionResponse response = exception switch
            {
                ApplicationException _ => new ExceptionResponse(HttpStatusCode.BadRequest, "Application exception occurred."),
                KeyNotFoundException _ => new ExceptionResponse(HttpStatusCode.NotFound, "The request key not found."),
                UnauthorizedAccessException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Unauthorized."),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;

            var messagedetails = new
            {
                StatusCode = "10001",
                StatusMessage = exception.Message
            };
            await context.Response.WriteAsJsonAsync(messagedetails);
        }
    }

    
}
