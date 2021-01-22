using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
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
            try
            {
                await this.next(context);
            }
            catch (HttpRequestException exh)
            {
                this.logger.LogError(exh, exh.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)(exh.StatusCode ?? HttpStatusCode.InternalServerError);
                var response = this.env.IsDevelopment() ?
                    new ApiException(context.Response.StatusCode,
                        exh.Message, exh.StackTrace?.ToString()) :
                    new ApiException(context.Response.StatusCode, "Unknown Error");

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
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
        }

    }
}
