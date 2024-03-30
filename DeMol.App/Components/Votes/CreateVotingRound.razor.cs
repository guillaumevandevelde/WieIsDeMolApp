using DeMol.App.Services;
using DeMol.Domain;
using Microsoft.AspNetCore.Components;


namespace DeMol.App.Components.Votes;

public partial class CreateVotingRound : ComponentBase
{
    private VotingRound? newVotingRound = new VotingRound();
    
    [Inject]
    private VoteService VoteRoundService { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private async Task HandleValidSubmit()
    {
        await VoteRoundService.AddVotingRoundAsync(newVotingRound);
        NavigationManager.NavigateTo("/");
    }
}