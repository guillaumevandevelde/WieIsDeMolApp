using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeMol.Domain;

public class Candidate
{
    [Key]
    public int Id { get;set; }
    [ForeignKey(nameof(Game))]
    public int GameId { get;set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ContributedPrizeMoney { get;set; }
    public string? Name { get;set; }
    public string? PhotoUrl { get;set; }
    public bool IsMol { get;set; } = false;
    public bool IsWinner { get;set; } = false;
    public bool IsActive { get;set; } = true;
}