using System.Net.Http.Json;
using EShop.WebAssembly.Pages;

namespace EShop.WebAssembly.Utils;

public class EShopHttpClient
{
    private readonly HttpClient _httpClient;

    public EShopHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DownloadStatus> GetDownloadStatusAsync()
    {
        var status = await _httpClient.GetFromJsonAsync<DownloadStatus>("foo.json");

        return status;
    }
}