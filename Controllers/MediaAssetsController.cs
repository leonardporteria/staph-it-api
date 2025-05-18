using Microsoft.AspNetCore.Mvc;
using StaPHit.Models;
using StaPHit.Repositories.Interfaces;

namespace StaPHit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaAssetsController : ControllerBase
    {
        private readonly IMediaAssetRepository _repository;

        public MediaAssetsController(IMediaAssetRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var asset = await _repository.GetByIdAsync(id);
            return asset == null ? NotFound() : Ok(asset);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MediaAsset mediaAsset)
        {
            var created = await _repository.AddAsync(mediaAsset);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MediaAsset mediaAsset)
        {
            if (id != mediaAsset.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(mediaAsset);
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
