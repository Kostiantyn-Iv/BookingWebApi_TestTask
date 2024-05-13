using BLL.Exceptions;
using System.Net;

namespace BookingWebApi.ExceptionHandling
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _delegate;

        public ExceptionHandlerMiddleware(RequestDelegate rdelegate)
        {
            _delegate = rdelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _delegate(httpContext);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(
                    httpContext,
                    HttpStatusCode.BadRequest,
                    ex.Message);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(
                    httpContext,
                    HttpStatusCode.NotFound,
                    ex.Message);
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext httpContext,
            HttpStatusCode httpStatusCode,
            string message)
        {
            HttpResponse response = httpContext.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            var result = new
            {
                message,
                StatusCode = (int)httpStatusCode,
            };

            await response.WriteAsJsonAsync(result);
        }
    }
}
