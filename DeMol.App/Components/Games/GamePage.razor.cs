using DeMol.App.Services;
using Microsoft.AspNetCore.Components;
using DeMol.Domain;
namespace DeMol.App.Components.Games;

public partial class GamePage : ComponentBase
{
    private List<Game> games;

    protected override async Task OnInitializedAsync()
    {
        games = await GameService.GetAllGamesAsync();
    }

    private void CreateGame()
    {
        // Navigeer naar de pagina of modal voor het creëren van een nieuwe game
    }

    private void EditGame(int gameId)
    {
        // Navigeer naar de bewerkpagina of open een modal voor het bewerken van een game
    }

    private async Task DeleteGame(int gameId)
    {
        await GameService.DeleteGameAsync(gameId);
        games = await GameService.GetAllGamesAsync(); // Refresh de lijst
    }
}