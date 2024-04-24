namespace Gallery.Domain.Entities;

public class Image
{
    // Main Properties
    public Guid Id { get; set; }
    public string Url { get; set; } = null!;

    // Relational Properties
    public Guid AlbumId { get; set; }
    public Album Album { get; set; } = null!;
}