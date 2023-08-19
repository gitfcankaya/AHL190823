namespace _3_Middleware.Middlewares
{
    public class OrnekMiddleware
    {
        private readonly RequestDelegate _next;

        public OrnekMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //logic
            Console.WriteLine("BizimMiddleware çalıştı");

            await _next.Invoke(context);
        }

    }
}
