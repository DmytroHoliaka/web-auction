namespace WebAuction.Backend.Middlewares
{
    public class CookieSetterMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieSetterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies["userStatus"] == null)
            {
                context.Response.Cookies.Append("userStatus", "guest");
            }

            await _next(context);
        }
    }
}
