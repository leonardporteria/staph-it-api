using Microsoft.EntityFrameworkCore;
using StaPHit.Models;
using StaPHit.Repositories.Interfaces;

namespace StaPHit.Repositories.Implementations
{
    public class MediaAssetRepository : IMediaAssetRepository
    {
        private readonly AppDbContext _context;

        public MediaAssetRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<MediaAsset>> GetAllAsync() =>
            await _context.MediaAssets
                .Include(m => m.UploadedBy)
                .ToListAsync();

        public async Task<MediaAsset?> GetByIdAsync(int id) =>
            await _context.MediaAssets
                .Include(m => m.UploadedBy)
                .FirstOrDefaultAsync(m => m.Id == id);

        public async Task<MediaAsset> AddAsync(MediaAsset mediaAsset)
        {
            _context.MediaAssets.Add(mediaAsset);
            await _context.SaveChangesAsync();
            return mediaAsset;
        }

        public async Task<MediaAsset?> UpdateAsync(MediaAsset mediaAsset)
        {
            if (!_context.MediaAssets.Any(m => m.Id == mediaAsset.Id)) return null;

            _context.MediaAssets.Update(mediaAsset);
            await _context.SaveChangesAsync();
            return mediaAsset;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var mediaAsset = await _context.MediaAssets.FindAsync(id);
            if (mediaAsset == null) return false;

            _context.MediaAssets.Remove(mediaAsset);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
