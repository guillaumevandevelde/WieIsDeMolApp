using DeMol.App.Services;
using Microsoft.AspNetCore.Components;
using DeMol.Domain;
namespace DeMol.App.Components.Games;

public partial class GamesPage : ComponentBase
{
    private List<Game> games;
    [Inject]
    private GameService GameService { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        games = await GameService.GetAllGamesAsync();
    }

    private async Task CreateGame()
    {
        await GameService.CreateGameAsync();
        NavigationManager.NavigateTo("/games");
    }
    
    private async Task EditGame()
    {
        NavigationManager.NavigateTo($"/game/edit/");
    }



    private async Task DeleteGame(int gameId)
    {
        await GameService.DeleteGameAsync(gameId);
        games = await GameService.GetAllGamesAsync(); 
    }
}