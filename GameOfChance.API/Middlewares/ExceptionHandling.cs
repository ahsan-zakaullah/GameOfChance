using System.Net;
using GameOfChance.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace GameOfChance.Api.Middlewares
{
    public static class ExceptionHandling
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
                        // TODO: We can implement the logging here to log the exception in File or DB
                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Something went wrong. Please contact the admin!"
                        }.ToString() ?? string.Empty);
                    }
                });
            });
        }
    }
}
