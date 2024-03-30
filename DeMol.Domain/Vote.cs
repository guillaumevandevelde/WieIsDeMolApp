using System.ComponentModel.DataAnnotations;

namespace DeMol.Domain;

public class Vote
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public List<MoleVote> MoleVotes { get; set; } = new List<MoleVote>();
    public List<WinnerVote> WinnerVotes { get; set; } = new List<WinnerVote>();
}