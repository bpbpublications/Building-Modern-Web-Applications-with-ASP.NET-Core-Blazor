using EShop.Server.Auth;
using EShop.Server.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace EShop.Server.Pages;

public partial class SignIn : ComponentBase
{
    private SignInFormModel _model = new SignInFormModel();
    private bool _authenticated = false;

    [Inject]
    private EShopAuthenticationStateProvider AuthenticationStateProvider { get; set; }

    private void HandleValidSubmit()
    {
        AuthenticationStateProvider.SignIn(_model.Name, _model.Password);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        AuthenticationStateProvider.AuthenticationStateChanged += OnAuthenticationStateChangedAsync;
    }

    private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
    {
        var state = await task;
        _authenticated = state.User.Identity.IsAuthenticated;
    }
}