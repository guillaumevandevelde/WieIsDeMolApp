using DeMol.App.Services;
using DeMol.Domain;
using Microsoft.AspNetCore.Components;

namespace DeMol.App.Components.Games;

public partial class GameEditPage : ComponentBase
{
    [Parameter]
    public int GameId { get; set; }

    private Game? game;
    [Inject]
    private GameService GameService { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    { 
        game = await GameService.GetGameThisYear();
         
    }

    private async Task HandleValidSubmit()
    {
        await GameService.UpdateGameAsync(game);
        NavigationManager.NavigateTo("/games");
    }
}