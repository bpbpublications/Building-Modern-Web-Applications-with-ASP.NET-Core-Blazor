using Microsoft.AspNetCore.Components;

namespace EShop.WebAssembly.Shared
{
    public partial class GroupContainer
    {
        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public string? Description { get; set; }

        [Parameter]
        public string? FontSize { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        private RenderFragment<string> _descriptionRF = (desc) => (b) =>
        {
            b.OpenElement(-3, "p");
            b.AddAttribute(-2, "class", "mb-1");
            b.AddContent(-1, desc);
            b.CloseElement();
        };
    }
}