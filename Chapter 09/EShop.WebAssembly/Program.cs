using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EShop.WebAssembly;
using System.Text.Json;

var myInstance = new MyClass()
{
    Type = "Blazor",
    Content = "Hello, world!"
};

string jsonString = JsonSerializer.Serialize(myInstance);
Console.WriteLine(jsonString);

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
