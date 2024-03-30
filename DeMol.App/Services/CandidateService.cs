using DeMol.App.Data;
using DeMol.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeMol.App.Services;

public class CandidateService
{
    private readonly AppDbContext _context;
    private readonly GameService _gameService;

    public CandidateService(
        AppDbContext context,
        GameService gameService)
    {
        _context = context;
        _gameService = gameService;
    }

    public async Task<List<Candidate?>> GetCandidatesAsync() => await _context.Candidates.ToListAsync();
    public async Task<List<Candidate?>> GetActiveCandidatesAsync() 
        => await _context.Candidates.Where(c => c.IsActive).ToListAsync();

    public async Task<Candidate?> GetCandidateByIdAsync(int id) => await _context.Candidates.FindAsync(id);

    public async Task AddCandidateAsync(Candidate? candidate)
    {
        var game = await _gameService.GetGameThisYear();
        candidate.GameId = game.Id;
        _context.Candidates.Add(candidate);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCandidateAsync(Candidate? candidate)
    {
        _context.Candidates.Update(candidate);
        await _context.SaveChangesAsync();
    }
}
