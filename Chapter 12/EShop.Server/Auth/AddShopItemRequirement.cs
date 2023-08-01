using Microsoft.AspNetCore.Authorization;

namespace EShop.Server.Auth;

public class AddShopItemRequirement : IAuthorizationRequirement
{
    public char PostalCodeSuffix { get; }
    public string Role { get; }

    public AddShopItemRequirement(char postalCodeSuffix, string role)
    {
        PostalCodeSuffix = postalCodeSuffix;
        Role = role;
    }
}