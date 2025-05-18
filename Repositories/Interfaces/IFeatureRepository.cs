using StaPHit.Models;

namespace StaPHit.Repositories.Interfaces
{
    public interface IFeatureRepository
    {
        Task<IEnumerable<Feature>> GetAllAsync();
        Task<Feature?> GetByIdAsync(int id);
        Task<Feature> AddAsync(Feature feature);
        Task<Feature?> UpdateAsync(Feature feature);
        Task<bool> DeleteAsync(int id);
    }
}
