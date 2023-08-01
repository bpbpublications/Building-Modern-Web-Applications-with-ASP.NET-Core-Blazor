using System.ComponentModel.DataAnnotations;

namespace EShop.WebAssembly.Models;

public enum RequestItemSize
{
    Small,
    Medium,
    Large
}

public class RequestItem
{
    [Required(ErrorMessage = "Please fill in the item name.")]
    public string EShopItemName { get; set; }

    public RequestItemSize Size { get; set; }

    [Required(ErrorMessage = "Please fill in the item count.")]
    [Range(1, 10, ErrorMessage= "You may request no more than 10 items.")]
    public int Count { get; set; } = 1;
}