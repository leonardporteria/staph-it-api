using Microsoft.AspNetCore.Mvc;
using StaPHit.Models;
using StaPHit.Repositories.Interfaces;

namespace StaPHit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureRepository _repository;

        public FeaturesController(IFeatureRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var feature = await _repository.GetByIdAsync(id);
            return feature == null ? NotFound() : Ok(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Feature feature)
        {
            var created = await _repository.AddAsync(feature);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Feature feature)
        {
            if (id != feature.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(feature);
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
