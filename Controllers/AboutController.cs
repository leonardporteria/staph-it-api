using Microsoft.AspNetCore.Mvc;
using StaPHit.Models;
using StaPHit.Repositories.Interfaces;

namespace StaPHit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly IAboutRepository _repository;

        public AboutController(IAboutRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var about = await _repository.GetByIdAsync(id);
            return about == null ? NotFound() : Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create(About about)
        {
            var created = await _repository.AddAsync(about);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, About about)
        {
            if (id != about.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(about);
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
