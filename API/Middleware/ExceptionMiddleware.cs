using API.Errors;
using System.Net;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware(IHostEnvironment environment, RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex, environment);
			}
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, IHostEnvironment environment)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = environment.IsDevelopment()
                ? new APIErrorResponse(context.Response.StatusCode, ex.Message, ex.StackTrace)
                : new APIErrorResponse(context.Response.StatusCode, ex.Message, "Internal server error.");
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);
            return context.Response.WriteAsync(json);
        }
    }
}
