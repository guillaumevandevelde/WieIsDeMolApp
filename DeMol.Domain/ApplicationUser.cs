using System.ComponentModel.DataAnnotations;

namespace DeMol.Domain;

public class ApplicationUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public bool IsAdmin { get; set; } = false;
}