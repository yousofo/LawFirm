
namespace LawFirm.API.Middlewares
{
    public class ErrorHandlingMw(ILogger<ErrorHandlingMw> logger, RequestDelegate next)  
    {
        readonly ILogger<ErrorHandlingMw> _logger = logger;
        readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("ErrorHandlingMw: Handling request");
            await _next.Invoke(context);
            _logger.LogInformation("ErrorHandlingMw: after next");
            //try
            //{
            //    _logger.LogInformation("ErrorHandlingMw: Handling request");
            //     await next.Invoke(context);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogInformation("ErrorHandlingMw: after next");
            //    _logger.LogError(ex, ex.Message);
            //    context.Response.StatusCode = 500;
            //    await context.Response.WriteAsync("something went wrong");
            //}
        }
    }
}
