using Microsoft.EntityFrameworkCore;
using StaPHit.Models;
using StaPHit.Repositories.Interfaces;

namespace StaPHit.Repositories.Implementations
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly AppDbContext _context;

        public FeatureRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Feature>> GetAllAsync() =>
            await _context.Features.ToListAsync();

        public async Task<Feature?> GetByIdAsync(int id) =>
            await _context.Features.FindAsync(id);

        public async Task<Feature> AddAsync(Feature feature)
        {
            _context.Features.Add(feature);
            await _context.SaveChangesAsync();
            return feature;
        }

        public async Task<Feature?> UpdateAsync(Feature feature)
        {
            if (!_context.Features.Any(f => f.Id == feature.Id)) return null;

            _context.Features.Update(feature);
            await _context.SaveChangesAsync();
            return feature;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var feature = await _context.Features.FindAsync(id);
            if (feature == null) return false;

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
