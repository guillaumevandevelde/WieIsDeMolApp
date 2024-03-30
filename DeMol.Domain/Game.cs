using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeMol.Domain;

public class Game
{
    public int Id { get; set; }
    public int Year { get; private set; } 
    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrizeMoney { get; set; }
    public List<Candidate> Candidates { get; set; }
    public List<VotingRound> VotingRounds { get; set; }

    public Game()
    {
        Candidates = new List<Candidate>();
        VotingRounds = new List<VotingRound>();
        Year = DateTime.Now.Year;
    }
    
}