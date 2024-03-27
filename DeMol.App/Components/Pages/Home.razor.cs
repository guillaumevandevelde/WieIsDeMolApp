using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace DeMol.App.Components.Pages;

public partial class Home
{
    private ClaimsPrincipal user;

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        user = authState.User;
    }
}