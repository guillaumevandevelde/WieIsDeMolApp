using System.ComponentModel.DataAnnotations;

namespace DeMol.Domain;

public class VotingRound
{
    public int Id { get; set; }
    public List<Vote> Votes { get; set; } = new List<Vote>();
    public int Round { get; set; }
    public int GameId { get; set; }
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; }  = DateTime.Now + TimeSpan.FromDays(7);
    
    public void AddVote(Vote vote)
    {
        Votes.Add(vote);
    }
    
}