namespace EShop.Server;

public class LoggerMiddleware
{
    private readonly RequestDelegate _next;

    public LoggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string log = $"{context.Request.Scheme}://{context.Request.Host.Value}{context.Request.Path.Value}";
        Console.WriteLine($"client requests: {log}");

        // await context.Response.WriteAsync("hello world!");
        await _next.Invoke(context);
    }
}