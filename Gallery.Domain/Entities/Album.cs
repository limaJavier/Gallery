using System.ComponentModel.DataAnnotations;

namespace Gallery.Domain.Entities;

public class Album
{
    // Main Properties
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    // Relational Properties
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Image> Images { get; set; } = null!;
}