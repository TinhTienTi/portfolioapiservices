using System.Net;
using System.Text.Json;

namespace PortfolioServices.Api.Infracstructure;

public static class MiddlewareExtensions
{
    public static void ConfigureCustomAuditMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<AuditMiddleware>();
    }
}
public class AuditMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AuditMiddleware> _logger;

    public AuditMiddleware(RequestDelegate next, ILogger<AuditMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        //catch (DivideByZeroException dex)
        //{
        //    _logger.LogError($"A DivideByZero exception has been thrown: {dex}");
        //    await HandleExceptionAsync(httpContext, dex);
        //}
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var message = exception switch
        {
            DivideByZeroException => "DivideByZero error from the custom middleware"
        };

        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());
    }
}

public class ErrorDetails
{
    public int StatusCode { get; set; }

    public string Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
