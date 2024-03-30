using DeMol.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeMol.App.Data;

public class AppDbContext : DbContext
{
    public DbSet<Candidate?> Candidates { get; set; }
    public DbSet<VotingRound?> VotingRounds { get; set; }
    public DbSet<Game?> Games { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }

    public AppDbContext(
        DbContextOptions<AppDbContext> options
    )
        : base(options)
    {
       
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        SeedData.Seed(modelBuilder);
    }
       
}