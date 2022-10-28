using NLog;

namespace Registration_System.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly NLog.ILogger _logger;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }
    }
}
