using Npgsql;
using System.Data.Entity.Core;

namespace TicketSelling.Middlewares
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }

            catch (EntityException entityException)
            {
                Console.WriteLine($"Ошибка Entity: {entityException.Message}");
                httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                await httpContext.Response.WriteAsJsonAsync(new { Message = "Запрос не может быть выполнен из-за конфликта на сервере" });
            }

            catch (PostgresException exception)
            {
                int httpStatusCode = StatusCodes.Status500InternalServerError;
                string message = "Внутренняя ошибка сервера";

                switch (exception.SqlState)
                {
                    case PostgresErrorCodes.UniqueViolation:
                        httpStatusCode = StatusCodes.Status409Conflict;
                        message = "Запрос не может быть выполнен из-за конфликта на сервере";
                        break;
                    case PostgresErrorCodes.SerializationFailure:
                        httpStatusCode = StatusCodes.Status408RequestTimeout;
                        message = "Время ожидания запроса истекло. Повторите попытку позднее";
                        break;
                }
                Console.WriteLine($"Ошибка Postgres: {exception.SqlState}. {exception.Message}");
                httpContext.Response.StatusCode = httpStatusCode;
                await httpContext.Response.WriteAsJsonAsync(new { Message = message });
            }

            catch (Exception exception)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                Console.WriteLine("Внутренняя ошибка сервера: " + exception.Message);
                await httpContext.Response.WriteAsJsonAsync(new { Message = "Внутренняя ошибка сервера"});
            }
        }
    }
}
