using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace EShop.WebAssembly;

public partial class App : IDisposable
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged;
    }

    private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        Console.WriteLine(e.Location);
        Console.WriteLine(e.IsNavigationIntercepted);
    }

    private async Task OnNavigateAsync(NavigationContext args)
    {
        Console.WriteLine(args.Path);
    }
}