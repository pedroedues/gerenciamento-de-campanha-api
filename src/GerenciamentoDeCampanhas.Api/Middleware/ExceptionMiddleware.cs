using FluentValidation;
using System.Net;
using System.Text.Json;

namespace GerenciamentoDeCampanhas.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case ValidationException:
                        await HandleExceptionAsync(context, ex, "Erro ao validar valores de entrada", HttpStatusCode.UnprocessableEntity);
                        break;

                    default:
                        await HandleExceptionAsync(context, ex, "Ocorreu um erro inesperado",HttpStatusCode.InternalServerError);
                        break;

                }
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, string erroMessage,HttpStatusCode status)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            var errorResponse = new
            {
                Message = erroMessage,
                ExceptionMessage = exception.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
