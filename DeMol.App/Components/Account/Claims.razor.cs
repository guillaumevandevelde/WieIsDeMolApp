using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace DeMol.App.Components.Account;

public partial class Claims
{
    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;
    public IEnumerable<Claim> claims;
    public ClaimsPrincipal user = default!;
    
    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        user = authState.User;
        claims = user.Claims;
    }
}