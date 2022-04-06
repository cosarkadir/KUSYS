using KUSYS.Core.Contracts;

namespace KUSYS.Web.Api.Middleware
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILogger logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, logger);

                httpContext.Response.StatusCode = 500;
                ServiceResponse<bool> response = new ServiceResponse<bool>(false)
                {
                    IsSuccessfull = false,
                    Errors = new List<string>() { ex.Message }
                };
                await httpContext.Response.WriteAsJsonAsync<ServiceResponse<bool>>(response);
            }
            finally
            {
                logger.LogInformation(
                    "Request {method} {url} => {statusCode}",
                    httpContext.Request?.Method,
                    httpContext.Request?.Path.Value,
                    httpContext.Response?.StatusCode);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex, ILogger svc)
        {
            svc.LogError(ex.ToString());
            return Task.CompletedTask;
        }
    }
}
