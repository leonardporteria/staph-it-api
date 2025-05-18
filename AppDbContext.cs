using Microsoft.EntityFrameworkCore;
using StaPHit.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StaPHit
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options) { }

        public DbSet<Feature> Features { get; set; }
        public DbSet<BuildNote> BuildNotes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MediaAsset> MediaAssets { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<About> Abouts { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
