var builder = WebApplication.CreateBuilder(args);

// Add SignalR
builder.Services.AddSignalR();

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<NotificationHub>("/Notification");

// app.MapGet("/", () => "Hello World!");

app.Run();
