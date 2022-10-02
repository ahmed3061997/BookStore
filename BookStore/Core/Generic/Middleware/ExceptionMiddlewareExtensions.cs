using BookStore.Core.Generic.Responses;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace BookStore.Core.Generic.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var res = new Response()
                        {
                            Result = false,
                            Errors = new[] { contextFeature.Error.Message }
                        };
                        await context.Response.WriteAsync(res.ToString());
                    }
                });
            });
        }
    }
}
