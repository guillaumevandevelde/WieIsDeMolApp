using System.ComponentModel.DataAnnotations;

namespace DeMol.Domain;

public class VotingRound
{
    [Key]
    public int Round { get; set; }
    public int GameId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsActive { get; set; } 
}