using Core.Utilities.Responses;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }
        //TODO: Hata kodlarini ve mesajlarini duzenle.
        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            var type = e.GetType();
            string message = string.Empty;
            ErrorResponse errorResponse = new ErrorResponse(message: "Internal Server Error", 500);//, resultCodes: ResponseCodes.HTTP_InternalServerError);

            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))
            {
                errors = ((ValidationException)e).Errors;
                string dataError = "";
                foreach (var itemError in errors)
                {
                    dataError += itemError.ErrorMessage + ";";
                }
                errorResponse = new ErrorResponse(dataError, 400);
            }
            else
            if (e.GetType() == typeof(UnauthorizedAccessException))
            {
                errorResponse = new ErrorResponse(e.Message, 500);
            }
            else
            if (e.GetType() == typeof(KeyNotFoundException))
            {
                errorResponse = new ErrorResponse(e.Message, 500);
            }
            else
            if (e.GetType() == typeof(Exception))
            {
                errorResponse = new ErrorResponse(e.Message, 500);
            }
            else
            {
                errorResponse = new ErrorResponse(e.Message, 500);

            }

            var result = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions() { PropertyNamingPolicy = null });

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = errorResponse.ResultCode;

            return httpContext.Response.WriteAsync(result);
        }

    }
}
