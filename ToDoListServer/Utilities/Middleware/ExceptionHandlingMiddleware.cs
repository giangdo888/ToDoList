using Microsoft.EntityFrameworkCore;

namespace ToDoListServer.Utilities.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Unexpected error with database");
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal server error");
            }
        }
    }
}
