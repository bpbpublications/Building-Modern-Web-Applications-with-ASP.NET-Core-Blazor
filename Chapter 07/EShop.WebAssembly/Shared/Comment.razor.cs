using Microsoft.AspNetCore.Components;

namespace EShop.WebAssembly.Shared
{
    public partial class Comment
    {
        [Parameter]
        public Models.Comment? CommentModel { get; set; }
    }
}