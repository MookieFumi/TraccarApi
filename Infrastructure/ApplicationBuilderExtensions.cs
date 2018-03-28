using Microsoft.AspNetCore.Builder;
using TraccarApi.Infrastructure.Middlewares;

namespace TraccarApi.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRequestResponseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}