using DeMol.App.Data;
using DeMol.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeMol.App.Services;

public class GameService
{
    private readonly AppDbContext _context;

    public GameService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateGameAsync()
    {
        if ( await GetGameThisYear() == null)
        {
            var game = new Game();
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Game>> GetAllGamesAsync()
    {
        return await _context.Games.Include(g => g.Candidates).Include(g => g.VotingRounds).ToListAsync();
    }

    public async Task<Game> GetGameByIdAsync(int id)
    {
        return await _context.Games.Include(g => g.Candidates).Include(g => g.VotingRounds)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task AddGameAsync(Game? game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGameAsync(Game? game)
    {
        _context.Games.Update(game);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGameAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game != null)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Game?> GetGameThisYear()
    {
        return _context.Games.SingleOrDefault(e => e.Year == DateTime.Now.Year);
    }
}
