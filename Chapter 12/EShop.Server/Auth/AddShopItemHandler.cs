using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EShop.Server.Auth;

public class AddShopItemHandler : AuthorizationHandler<AddShopItemRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AddShopItemRequirement requirement)
    {
        if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role) && !context.User.HasClaim(c => c.Type == ClaimTypes.PostalCode))
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var postalCode = context.User.FindFirstValue(ClaimTypes.PostalCode);
        var role = context.User.FindFirstValue(ClaimTypes.Role);
        if (postalCode.EndsWith(requirement.PostalCodeSuffix) && role == requirement.Role)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        context.Fail();
        return Task.CompletedTask;
    }
}