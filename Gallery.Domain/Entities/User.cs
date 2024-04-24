namespace Gallery.Domain.Entities;

public class User
{
    // Main Properties
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    // Relational Properties
    public ICollection<Album> Albums { get; set; } = null!;
}