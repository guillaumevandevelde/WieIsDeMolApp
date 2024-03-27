using System.ComponentModel.DataAnnotations;

namespace DeMol.Domain;

public class Vote
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string[] MolVotes { get; set; } = Array.Empty<string>();
    public string[] WinnerVotes { get; set; } = Array.Empty<string>();
    public int Round { get; set; }
}