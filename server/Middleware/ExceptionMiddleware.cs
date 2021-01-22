using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Middleware
{
    /// <summary>
    /// Handling an catuthed exptions, and filtring them from geting to the client
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly IHostEnvironment env;
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.logger = logger;
            this.next = next;
            this.env = env;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            string logMsg = "[Request:]\t";
            logMsg += "\n" + "[Path:]\t" + context.Request.Path;
            logMsg += "\n" + "[Method:]\t" + context.Request.Method;
            logMsg += "\n" + "[TOKEN:]\t" + context.Request.Headers["Authorization"];
            var timer = new Stopwatch();
            timer.Start();


            this.logger.LogInformation(LoggingId.GenrealHttpRequestInfo, logMsg);

            try
            {   
                await this.next(context);
            }

            catch (Exception ex) 
            {
                this.logger.LogError(LoggingId.GenrealServerError, ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = this.env.IsDevelopment() ?
                    new ApiException(context.Response.StatusCode,
                        ex.Message, ex.StackTrace?.ToString()) :
                    new ApiException(context.Response.StatusCode, "Internal Server Error");

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);

            }
            timer.Stop();
            this.logger.LogInformation(LoggingId.GenrealTrackingInfo, "The request took '{0}' ms", timer.ElapsedMilliseconds);


        }

    }
}
