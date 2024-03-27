using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeMol.Domain;

public class Game
{
    [Key]
    public int Id { get; set; }
    public int Year { get; } = DateTime.Now.Year;
    public User Winner { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrizeMoney { get; set; }
    public List<Candidate> Candidates { get; set; }
    public List<VotingRound> VotingRounds { get; set; }
}