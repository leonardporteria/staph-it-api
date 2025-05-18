using Microsoft.AspNetCore.Mvc;
using StaPHit.Models;
using StaPHit.Repositories.Interfaces;

namespace StaPHit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _repository;

        public TeamsController(ITeamRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _repository.GetByIdAsync(id);
            return team == null ? NotFound() : Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            var created = await _repository.AddAsync(team);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Team team)
        {
            if (id != team.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(team);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
