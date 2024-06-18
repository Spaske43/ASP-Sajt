using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.Logging;
using FluentValidation;

namespace EcommerceShop.API.Core;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {

            httpContext.Response.ContentType = "application/json";
            object response = null;
            var statusCode = StatusCodes.Status500InternalServerError;

            if (ex is UnauthorizedAccessException unauthEx)
            {
                statusCode = StatusCodes.Status401Unauthorized;
                response = new ErrorResponse
                {
                    Message = unauthEx.Message,
                    AdditionalData = ex.ToString()
                };
            }

            if (ex is ValidationException validationEx)
            {
                statusCode = StatusCodes.Status422UnprocessableEntity;
                response = new ErrorResponse
                {
                    Message = validationEx.Message,
                    AdditionalData = ex.ToString()
                };
            }

            if (ex is EntityNotFound notFoundException)
            {
                statusCode = StatusCodes.Status401Unauthorized;
                response = new ErrorResponse
                {
                    Message = notFoundException.Message,
                    AdditionalData = ex.ToString()
                };
            }

            if (ex is EntityForbiddenAccess forbiddenex)
            {
                statusCode = StatusCodes.Status403Forbidden;
                response = new ErrorResponse
                {
                    Message = forbiddenex.Message,
                    AdditionalData = ex.ToString()
                };
            }

            httpContext.Response.StatusCode = statusCode;
            if (response != null)
            {
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}

