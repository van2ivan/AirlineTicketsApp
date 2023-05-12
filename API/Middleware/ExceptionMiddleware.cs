using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // if there is no exception, request
                // goes to the next peace of middleware 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                //write also response into context to show it to the client
                context.Response.ContentType = "application/json"; // json formatted response
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // internal server error

                //in first case we are in developemtn mode, in second - production
                var response = _environment.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString());

                //return response in camel case
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options); //formating response into json

                await context.Response.WriteAsync(json);

            }
        }
    }
}