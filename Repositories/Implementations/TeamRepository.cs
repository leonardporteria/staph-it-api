using Microsoft.EntityFrameworkCore;
using StaPHit.Models;
using StaPHit.Repositories.Interfaces;

namespace StaPHit.Repositories.Implementations
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;

        public TeamRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Team>> GetAllAsync() =>
            await _context.Teams.ToListAsync();

        public async Task<Team?> GetByIdAsync(int id) =>
            await _context.Teams.FindAsync(id);

        public async Task<Team> AddAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team?> UpdateAsync(Team team)
        {
            if (!_context.Teams.Any(t => t.Id == team.Id)) return null;

            team.UpdatedAt = DateTime.UtcNow;
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
