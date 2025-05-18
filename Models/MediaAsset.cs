namespace StaPHit.Models
{
    public class MediaAsset
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }

        public int UploadedById { get; set; }
        public User UploadedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
