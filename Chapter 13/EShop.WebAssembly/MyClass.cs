using System.Text.Json.Serialization;

namespace EShop.WebAssembly;

public class MyClass
{
    // [JsonPropertyName("type")]
    public string Type { get; set; }

    // [JsonPropertyName("content")]
    public string Content { get; set; }
}