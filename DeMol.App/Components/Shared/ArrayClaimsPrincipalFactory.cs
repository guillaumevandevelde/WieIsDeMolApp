using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace DeMol.App.Components.Shared;

public class ArrayClaimsPrincipalFactory<TUser> : UserClaimsPrincipalFactory<TUser> where TUser : RemoteUserAccount
{
    public ArrayClaimsPrincipalFactory(UserManager<TUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(TUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim("name", user.Name ?? ""));
        return identity;
    }
}
