using EShop.Server;
using EShop.Server.Auth;
using EShop.Server.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<EShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<EShopAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(f => f.GetRequiredService<EShopAuthenticationStateProvider>());
builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("AddShopItemPolicy", p => p.Requirements.Add(new AddShopItemRequirement('2', "Employee")));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
