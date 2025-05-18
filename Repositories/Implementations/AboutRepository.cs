using Microsoft.EntityFrameworkCore;
using StaPHit.Models;
using StaPHit.Repositories.Interfaces;

namespace StaPHit.Repositories.Implementations
{
    public class AboutRepository : IAboutRepository
    {
        private readonly AppDbContext _context;

        public AboutRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<About>> GetAllAsync() =>
            await _context.Abouts.ToListAsync();

        public async Task<About?> GetByIdAsync(int id) =>
            await _context.Abouts.FindAsync(id);

        public async Task<About> AddAsync(About about)
        {
            _context.Abouts.Add(about);
            await _context.SaveChangesAsync();
            return about;
        }

        public async Task<About?> UpdateAsync(About about)
        {
            if (!_context.Abouts.Any(a => a.Id == about.Id)) return null;

            about.UpdatedAt = DateTime.UtcNow;
            _context.Abouts.Update(about);
            await _context.SaveChangesAsync();
            return about;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            if (about == null) return false;

            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
