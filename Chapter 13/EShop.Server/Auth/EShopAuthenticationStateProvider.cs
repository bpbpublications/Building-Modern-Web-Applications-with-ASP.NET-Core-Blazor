using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace EShop.Server.Auth;

public class EShopAuthenticationStateProvider : AuthenticationStateProvider
{
    private bool _isSignedIn = false;
    private string _username = string.Empty;

    private string Email { get => $"{_username.Replace(" ", "")}@eshop.com"; }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsIdentity claimsIdentity;

        if (_isSignedIn)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _username),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Role, _username.Contains("EShop")?"Employee":"Customer"),
                new Claim(ClaimTypes.PostalCode, _username.Contains("EShop")?"0123":"3210")
            };

            claimsIdentity = new ClaimsIdentity(claims, "EShopAuth");
        }
        else
        {
            claimsIdentity = new ClaimsIdentity();
        }

        var authenticationState = new AuthenticationState(new ClaimsPrincipal(claimsIdentity));

        return Task.FromResult(authenticationState);
    }

    public void SignIn(string username, string password)
    {
        _username = username;
        _isSignedIn = !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}