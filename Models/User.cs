﻿namespace StaPHit.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // e.g., "admin", "editor"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
