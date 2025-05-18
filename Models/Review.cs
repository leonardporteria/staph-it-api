namespace StaPHit.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; } // 1 to 5
        public bool Approved { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
