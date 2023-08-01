using EShop.WebAssembly.Models;
using Microsoft.AspNetCore.Components;

namespace EShop.WebAssembly.Components
{
    public partial class CartComponent
    {
        [Parameter]
        public Cart? Cart { get; set; }

        [CascadingParameter(Name = "FontSize")]
        public string? FontSize { get; set; }

        [CascadingParameter(Name = "FontStyle")]
        public string? FontStyle { get; set; }

        [Parameter]
        public EventCallback<CartItem> OnCartItemRemoved { get; set; }

        [Parameter]
        public EventCallback<CartItem> OnMovingToWishList { get; set; }

        private void Remove(CartItem item)
        {
            OnCartItemRemoved.InvokeAsync(item);
        }

        public void Checkout()
        {
            foreach (var item in Cart!.Items)
            {
                Console.WriteLine($"Checkout {item.Count} {item.Item.Name}, the total is {item.Count * item.Item.Price}");
            }
        }

        private async void MoveToWishList(CartItem item)
        {
            await OnMovingToWishList.InvokeAsync(item);
        }
    }
}