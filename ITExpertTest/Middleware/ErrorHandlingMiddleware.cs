using ITExpertTest.Exceptions;
using ITExpertTest.Responses;

namespace ITExpertTest.Middleware;

public class ErrorHandlingMiddleware: Exception
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate  next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ErrorException ex)
        {
            _logger.LogError(ex, ex?.ErrorMessage);
            var response = new ErrorResponse
            {
                ErrorMessage = ex.ErrorMessage,
                ErrorDescription = ex.ErrorDescription
            };
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}