using BookStore.Core.Generic.Responses;
using BookStore.Core.Generic.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

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
                        if (contextFeature.Error.GetType() == typeof(UnauthorizedAccessException))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        var res = new Response()
                        {
                            Result = false,
                            Errors = new[] { contextFeature.Error.Message }
                        };
                        await context.Response.WriteAsync(Helper.Json(res));
                    }
                });
            });
        }

        public static void ConfigureInvalidModelState(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(op =>
            {
                op.InvalidModelStateResponseFactory = (context) =>
                {
                    var modelState = context.ModelState.Values;
                    var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                    var res = new Response()
                    {
                        Result = false,
                        Errors = errors
                    };
                    return new JsonResult(res) { StatusCode = StatusCodes.Status400BadRequest };
                };
            });
        }
    }
}
