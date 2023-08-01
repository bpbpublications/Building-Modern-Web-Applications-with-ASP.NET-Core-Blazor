using Microsoft.JSInterop;

namespace EShop.WebAssembly.Utils;

public static class ProjectUtility
{
    [JSInvokable("getProj")]
    public static string GetProject(string key)
    {
        if (key == "Description")
        {
            return "This is an EShop project powered by Blazor WebAssembly.";
        }

        return "key not found.";
    }
}
