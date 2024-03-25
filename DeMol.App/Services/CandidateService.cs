using DeMol.App.Data;
using DeMol.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeMol.App.Services;

public class CandidateService
{
    private readonly AppDbContext _context;

    public CandidateService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Candidate?>> GetCandidatesAsync() => await _context.Candidates.ToListAsync();

    public async Task<Candidate?> GetCandidateByIdAsync(int id) => await _context.Candidates.FindAsync(id);

    public async Task AddCandidateAsync(Candidate? candidate)
    {
        _context.Candidates.Add(candidate);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCandidateAsync(Candidate? candidate)
    {
        _context.Candidates.Update(candidate);
        await _context.SaveChangesAsync();
    }
}
