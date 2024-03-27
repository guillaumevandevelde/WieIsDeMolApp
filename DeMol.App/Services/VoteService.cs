using DeMol.App.Data;
using DeMol.Domain;

namespace DeMol.App.Services;

public class VoteService
{
    private readonly AppDbContext _context;
    
    public VoteService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddVotingRoundAsync(VotingRound? votingRound)
    {
        if (votingRound != null) _context.VotingRounds.Add(votingRound);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddVoteAsync(Vote? vote)
    {
        if (vote != null) _context.Votes.Add(vote);
        await _context.SaveChangesAsync();
    }
    
}