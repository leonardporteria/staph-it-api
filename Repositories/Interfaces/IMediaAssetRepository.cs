using StaPHit.Models;

namespace StaPHit.Repositories.Interfaces
{
    public interface IMediaAssetRepository
    {
        Task<IEnumerable<MediaAsset>> GetAllAsync();
        Task<MediaAsset?> GetByIdAsync(int id);
        Task<MediaAsset> AddAsync(MediaAsset mediaAsset);
        Task<MediaAsset?> UpdateAsync(MediaAsset mediaAsset);
        Task<bool> DeleteAsync(int id);
    }
}
