using System.Text;
using TicketSelling.Core.Validators;

namespace TicketSelling.Middlewares
{
    public class JsonSchemaValidationMiddleware
    {
        private readonly IJsonSchemaValidator _jsonSchemaValidator;

        public readonly RequestDelegate next;

        public JsonSchemaValidationMiddleware(RequestDelegate next, IJsonSchemaValidator jsonSchemaValidator)
        {
            this.next = next;
            _jsonSchemaValidator = jsonSchemaValidator;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            using var reader = new StreamReader(httpContext.Request.Body);
            var content = await reader.ReadToEndAsync();
            httpContext.Request.Body = new MemoryStream(Encoding.ASCII.GetBytes(content));

            var requestPath = httpContext.Request.Path.Value;
            string jsonSchemaName = "";
            if (requestPath != null)
            {
                requestPath = requestPath.EndsWith("/") ? requestPath.Substring(0, requestPath.Length - 1) : requestPath;
                jsonSchemaName = requestPath.Substring(requestPath.LastIndexOf('/') + 1);
            }

            bool isContentValid = _jsonSchemaValidator.IsValid(content, jsonSchemaName);
            if (isContentValid)
            {
                await next(httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsJsonAsync(new { Message = "Неверное тело запроса" });
            }
        }
    }
}
