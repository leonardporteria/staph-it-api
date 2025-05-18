using Microsoft.EntityFrameworkCore;
using StaPHit.Models;
using StaPHit.Repositories.Interfaces;

namespace StaPHit.Repositories.Implementations
{
    public class BuildNoteRepository : IBuildNoteRepository
    {
        private readonly AppDbContext _context;

        public BuildNoteRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<BuildNote>> GetAllAsync() =>
            await _context.BuildNotes.ToListAsync();

        public async Task<BuildNote?> GetByIdAsync(int id) =>
            await _context.BuildNotes.FindAsync(id);

        public async Task<BuildNote> AddAsync(BuildNote buildNote)
        {
            _context.BuildNotes.Add(buildNote);
            await _context.SaveChangesAsync();
            return buildNote;
        }

        public async Task<BuildNote?> UpdateAsync(BuildNote buildNote)
        {
            if (!_context.BuildNotes.Any(b => b.Id == buildNote.Id)) return null;

            _context.BuildNotes.Update(buildNote);
            await _context.SaveChangesAsync();
            return buildNote;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var buildNote = await _context.BuildNotes.FindAsync(id);
            if (buildNote == null) return false;

            _context.BuildNotes.Remove(buildNote);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
