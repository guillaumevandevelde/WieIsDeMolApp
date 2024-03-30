namespace DeMol.Domain;

public abstract class CandidateVote
{
    public int Id { get; set; }
    public int VoteId { get; set; }
    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; }
    public int Order { get; set; } 
 
}