using System.Text.Json;

namespace HolloFabrika.Api.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            if (context.Response.HasStarted) return;

            var result = e switch
            {
                JsonException or { InnerException: JsonException } => Results.BadRequest("test"),
                _ => Results.StatusCode(StatusCodes.Status500InternalServerError)
            };

            await result.ExecuteAsync(context);
        }
    }
}