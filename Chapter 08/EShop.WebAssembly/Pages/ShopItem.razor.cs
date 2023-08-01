using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace EShop.WebAssembly.Pages
{
    public partial class ShopItem : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }

        [Parameter]
        [SupplyParameterFromQuery(Name = "size")]
        public int? Size { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Models.ShopItem Item { get; private set; }

        public string? Content { get; set; }

        private string _base64Image = string.Empty;

        protected override void OnParametersSet()
        {
            Name = Name ?? "T-Shirt";
            Size = Size ?? 5;
            Item = new Models.ShopItem($"{Name} of size {Size}", "The best ever with lower price!", 19.9);
            Item.ImageUrl = "https://ts1.cn.mm.bing.net/th/id/R-C.614bdee2065be0f1976bdf839c725e26?rik=EJ2vSWnKs9a9vQ&riu=http%3a%2f%2fclipart-library.com%2fimg%2f828773.png&ehk=avi5QwUJFS0v4Qtu8ggI5Ariopp4uJwf7r5QlOnJQ0o%3d&risl=&pid=ImgRaw&r=0";
        }

        private void AddComment()
        {
            System.Console.WriteLine("AddComment");
            if (string.IsNullOrWhiteSpace(Content))
            {
                return;
            }

            var comment = new Models.Comment(Content!, _base64Image);
            Item.AddComment(comment);

            Console.WriteLine(Content);
        }

        private async void UploadImageAsync(InputFileChangeEventArgs args)
        {
            var file = await args.File.RequestImageFileAsync(args.File.ContentType, 300, 500);
            using var stream = file.OpenReadStream();
            byte[] buffer = new byte[stream.Length];
            await stream.ReadAsync(buffer, 0, buffer.Length);
            _base64Image = $"data:{file.ContentType};base64,{Convert.ToBase64String(buffer)}";
        }

        public void ToCart()
        {
            Console.WriteLine("go to cart");

            NavigationManager.NavigateTo("/cart", false);
        }
    }
}