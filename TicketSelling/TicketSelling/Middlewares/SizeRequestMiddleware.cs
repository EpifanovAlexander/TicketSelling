namespace TicketSelling.Middlewares
{
    public class SizeRequestMiddleware
    {
        private const long REQUEST_SIZE_LIMIT = 2 * 1024;

        public readonly RequestDelegate next;

        public SizeRequestMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.ContentLength > REQUEST_SIZE_LIMIT)
            {
                httpContext.Response.StatusCode = StatusCodes.Status413PayloadTooLarge;
                await httpContext.Response.WriteAsJsonAsync(new { Message = "Недопустимая длина запроса" });
            }
            else 
            {
                await next(httpContext);
            }
        }
    }
}
