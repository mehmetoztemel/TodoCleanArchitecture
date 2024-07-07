using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace TodoCleanArchitecture.WebAPI.Middlewares
{
    // IExceptionHandler .net 8 ile geldi
    public class MyExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // inner exception database den gelen hatayı verir
            string errorMessage = exception.Message;

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;

            var error = new { ErrorMessage = errorMessage };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(error));
            return true;
        }
    }
}
