using StaPHit.Models;

namespace StaPHit.Repositories.Interfaces
{
    public interface IAboutRepository
    {
        Task<IEnumerable<About>> GetAllAsync();
        Task<About?> GetByIdAsync(int id);
        Task<About> AddAsync(About about);
        Task<About?> UpdateAsync(About about);
        Task<bool> DeleteAsync(int id);
    }
}
