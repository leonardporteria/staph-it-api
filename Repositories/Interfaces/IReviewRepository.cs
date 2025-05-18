using StaPHit.Models;

namespace StaPHit.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int id);
        Task<Review> AddAsync(Review review);
        Task<Review?> UpdateAsync(Review review);
        Task<bool> DeleteAsync(int id);
    }
}
