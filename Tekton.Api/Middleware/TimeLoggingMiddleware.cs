using System.Diagnostics;

namespace Tekton.Api.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class TimeLoggingMiddleware
    {
        private readonly RequestDelegate _next; 
        private readonly ILogger<TimeLoggingMiddleware> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public TimeLoggingMiddleware(RequestDelegate next,
                                     ILogger<TimeLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            await _next(context);

            watch.Stop();

            _logger.LogInformation("Tiempo de la ejecución: " + watch.ElapsedMilliseconds + " milliseconds.");
        }
    }
}
