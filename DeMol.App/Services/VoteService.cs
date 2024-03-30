using DeMol.App.Data;
using DeMol.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeMol.App.Services;

public class VoteService
{
    
    private readonly GameService _gameService;
    private readonly AppDbContext _context;
    
    public VoteService(
        AppDbContext context,
        GameService gameService)
    {
        _context = context;
        _gameService = gameService;
    }
    
    public async Task AddVotingRoundAsync(VotingRound? votingRound)
    {
        var game = await _gameService.GetGameThisYear();
        if (votingRound != null) 
            votingRound.GameId = game.Id;
            _context.VotingRounds.Add(votingRound);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateVotingRoundAsync(VotingRound? votingRound)
    {
        if (votingRound != null)
            _context.VotingRounds.Update(votingRound);
            await _context.SaveChangesAsync();
    }
    
    public async Task<VotingRound?> GetLatestVotingRoundAsync()
    {
        return await _context.VotingRounds
            .OrderByDescending(vr => vr.Id)
            .SingleOrDefaultAsync();
    }
    
    public async Task<Vote> GetLastUserVoteAsync(int userId)
    {
        var votingRound = await GetLatestVotingRoundAsync();
        return votingRound?.Votes.Single(v => v.UserId == userId) ?? new Vote();
    }
    
    public async Task<bool> HasUserVotedMolesAsync(int userId)
    {
        var vote = await GetLastUserVoteAsync(userId);
        return vote.MoleVotes.Count != 0;
    }
    
    public async Task<bool> HasUserVotedWinnersAsync(int userId)
    {
        var vote = await GetLastUserVoteAsync(userId);
        return vote.WinnerVotes.Count != 0;
    }
    
}