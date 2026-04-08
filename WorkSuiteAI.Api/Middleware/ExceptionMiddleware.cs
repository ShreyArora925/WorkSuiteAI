using System.Net;
using Microsoft.AspNetCore.Http;
using System.Text.Json;


namespace WorkSuiteAI.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly  RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex.Message);
                await HandleExceptionAsync(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred");
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    "An unexpected error occurred. Please try again.");
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                status = (int)statusCode,
                message = message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
