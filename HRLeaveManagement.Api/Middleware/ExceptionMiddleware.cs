using HRLeaveManagement.Api.Models;
using HRLeaveManagement.Application.Exceptions;
using System.Net;

namespace HRLeaveManagement.Api.MIddleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        this._next = next; 
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {

            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomValidationProblemDetails problem = new();

        switch (ex)
        {
            case BadRequestException badHttpRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomValidationProblemDetails()
                {
                    Title = badHttpRequestException.Message,
                    Status = (int)statusCode,
                    Detail = badHttpRequestException.InnerException?.Message,
                    Type = nameof(BadHttpRequestException),
                    Errors = badHttpRequestException.ValidationErrors
                }; 
                    break;
            case NotFoundException notFoundException:
                problem = new CustomValidationProblemDetails()
                {
                    Title = notFoundException.Message,
                    Status = (int)statusCode,
                    Detail = notFoundException.InnerException?.Message,
                    Type = nameof(NotFoundException),
                };
                break;
            default:
                problem = new CustomValidationProblemDetails()
                {
                    Title = ex.Message,
                    Status = (int)statusCode,
                    Type = nameof(HttpStatusCode.InternalServerError),
                    Detail = ex.InnerException?.Message,
                };
                break;
        }

        httpContext.Response.StatusCode = (int)statusCode;
        await httpContext.Response.WriteAsJsonAsync(problem);
    }
}
