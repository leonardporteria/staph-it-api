using StaPHit.Models;

namespace StaPHit.Repositories.Interfaces
{
    public interface IBuildNoteRepository
    {
        Task<IEnumerable<BuildNote>> GetAllAsync();
        Task<BuildNote?> GetByIdAsync(int id);
        Task<BuildNote> AddAsync(BuildNote buildNote);
        Task<BuildNote?> UpdateAsync(BuildNote buildNote);
        Task<bool> DeleteAsync(int id);
    }
}
