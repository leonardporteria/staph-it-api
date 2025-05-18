namespace StaPHit.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public string Position { get; set; } = string.Empty;
        public string PositionShortcut { get; set; } = string.Empty;

        public string? LinkedIn { get; set; }
        public string? Facebook { get; set; }
        public string? GitHub { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
