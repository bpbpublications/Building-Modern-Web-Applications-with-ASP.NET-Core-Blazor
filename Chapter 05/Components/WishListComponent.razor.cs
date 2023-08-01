using Microsoft.AspNetCore.Components;
using EShop.Models;

namespace EShop.Components
{
    public partial class WishListComponent : ComponentBase
    {
        [Parameter]
        public WishList? WishList { get; set; }

        [CascadingParameter(Name = "FontSize")]
        public string? FontSize { get; set; }

        [CascadingParameter(Name = "FontStyle")]
        public string? FontStyle { get; set; }

        [Parameter]
        public EventCallback<WishListItem> OnMovingToCart { get; set; }

        private async void MoveToCart(WishListItem item)
        {
            await OnMovingToCart.InvokeAsync(item);
        }
    }
}