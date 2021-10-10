using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;


namespace ProductShop.Infrastructure
{
    public class CustomMiddleware : IMiddleware
    {
        private readonly ILogger logger;

        public CustomMiddleware(ILogger<CustomMiddleware> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            logger.LogInformation(context.Request.Method.ToString());
            await next.Invoke(context);
            logger.LogInformation(context.Response.StatusCode.ToString());
        }
    }
}
