using System.Security.Claims;
using DeMol.App.Services;
using DeMol.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace DeMol.App.Components.Votes;

public partial class VotePage : ComponentBase
{
    private List<Candidate?> _candidates = [];
    private List<Candidate?> _moles = [];
    private List<Candidate?> _winners = []; 
    private VotingRound?  _currentVotingRound ;
    
    [Inject]
    private CandidateService CandidateService { get; set; }
    [Inject]
    private VoteService VoteService { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    [Inject]
    private UserService UserService { get; set; }
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    private bool VotedForWinners { get; set; }
    private bool VotedForMoles { get; set; }
    private bool ShowMoles { get; set; } = false;
    private ApplicationUser? _currentUser { get; set; }  = new ApplicationUser();
    
    
    protected override async Task OnInitializedAsync()
    {
        _candidates = await CandidateService.GetActiveCandidatesAsync();
        _currentVotingRound = await VoteService.GetLatestVotingRoundAsync();
        await CheckUserAuthentication();
        
        if (_currentVotingRound.Votes.Count != 0 )
        {
            VotedForWinners = _currentVotingRound?.Votes.Any(v => v.UserId == _currentUser.Id && v.WinnerVotes.Any()) == true;
            VotedForMoles =  _currentVotingRound?.Votes.Any(v => v.UserId == _currentUser.Id && v.MoleVotes.Any()) == true;
            ;
        }else
        {
            VotedForWinners = false;
            VotedForMoles = false;
        }
        
    }
    
    private async Task VoteWinners()
    {
        
        var winnerVotes = _winners.Select(w => new WinnerVote()
        {
            Candidate = w,
            Order = _winners.IndexOf(w)+1
        }).ToList();

        await CheckUserAuthentication();
        
        var vote = new Vote()
        {
            UserId = _currentUser.Id,
            WinnerVotes = winnerVotes
        };
        
        _currentVotingRound.AddVote(vote);
        await VoteService.UpdateVotingRoundAsync(_currentVotingRound);
        VotedForWinners = true;
        _candidates.AddRange(_winners);
        StateHasChanged();
    }
    
    private async Task VoteMoles()
    {
        var moleVotes = _moles.Select(w => new MoleVote()
        {
            Candidate = w,
            Order = _moles.IndexOf(w)+1
        }).ToList();

        await CheckUserAuthentication();
        
        var vote = new Vote()
        {
            UserId = _currentUser.Id,
            MoleVotes = moleVotes

        };
        
        _currentVotingRound?.AddVote(vote);
        await VoteService.UpdateVotingRoundAsync(_currentVotingRound);
        VotedForMoles = true;
        NavigationManager.NavigateTo("/");
     
    }
 
    private async Task CheckUserAuthentication()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            var userEmail = user.FindFirst(c => c.Type.Equals(ClaimTypes.Email))?.Value; // E-mail van de gebruiker
            _currentUser = await UserService.GetUserByMailAsync(userEmail);
        }
    }

}