using BackendSR.Domain.Exceptions;

namespace BackendSR.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async void Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Error de NotFound: {Message}", ex.Message);
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new { message = ex.Message });
            }
            catch (UnauthorizedException ex)
            {
                _logger.LogError(ex, "Error de Unauthorized: {Message}", ex.Message);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { message = ex.Message });
            }
            catch (Exception ex) 
            { 
                _logger.LogError(ex, "Error Interno no servidor: {Message}", ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { message = ex.Message });
            }


            
        }
    }
}