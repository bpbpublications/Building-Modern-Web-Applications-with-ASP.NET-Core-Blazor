using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EShop.WebAssembly.Pages;

public partial class Lottery : ComponentBase
{
    private string _lotteryNo;
    private string _resultClasses = "hide";
    private string _lotteryResult = string.Empty;
    private DotNetObjectReference<Lottery>? _instanceRef;
    private IJSObjectReference? _module;
    private ElementReference _audio;

    [Inject]
    private IJSRuntime JS { get; set; }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _instanceRef = DotNetObjectReference.Create(this);
            _module = await JS.InvokeAsync<IJSObjectReference>("import", "./Pages/Lottery.razor.js?v=1");
            await _module.InvokeVoidAsync("getRef", _instanceRef);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    private async void DrawAsync()
    {
        // business logic for lottery drawing
        await _module.InvokeVoidAsync("draw", _lotteryNo, _audio);
    }

    [JSInvokable("display")]
    public void DisplayResult(string result)
    {
        _resultClasses = string.Empty;
        _lotteryResult = result;

        StateHasChanged();
    }
}