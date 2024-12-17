using APIOpdracht_SteffVanWeereld.database;
using APIOpdracht_SteffVanWeereld.Models;
using APIOpdracht_SteffVanWeereld.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIOpdracht_SteffVanWeereld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Region>>> GetAll()
        {
            var allRegions = await _regionService.GetAllRegions();
            if (allRegions is null)
            {
                return NotFound("Not found");
            }
            return Ok(allRegions);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetById(int id)
        {
            var regionToGet = await _regionService.GetRegionById(id);

            if (regionToGet != null)
            {
                return Ok(regionToGet);
            }

            return NotFound("Not found");
        }
        [HttpGet("{id}/image")]
        public async Task<ActionResult<Region>> GetImage(int id)
        {
            var region = await _regionService.GetRegionById(id);

            if (region != null)
            {
                return Ok(new
                {
                    name = region.Name,
                    image = region.Image
                });
            }

            return NotFound("Not found");
        }
        [HttpGet("capital/{capitalName}")]
        public async Task<ActionResult<Region>> GetCapital(string capitalName)
        {
            var region = await _regionService.GetByCapital(capitalName);

            if (region == null)
            {
                return NotFound("Not found");
            }

            return Ok(region);
        }
        [HttpGet("boss/{bossId}")]
        public async Task<ActionResult<Region>> GetByBoss(int bossId)
        {
            var region = await _regionService.GetRegionByBoss(bossId);

            if (region == null)
            {
                return NotFound("Not found");
            }

            return Ok(region);
        }
        [HttpGet("quest/{questId}")]
        public async Task<ActionResult<Region>> GetByQuest(int questId)
        {
            var region = await _regionService.GetByQuest(questId);

            if (region == null)
            {
                return NotFound("Not found");
            }

            return Ok(region);
        }
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            await _regionService.CreateRegion(region);
            return CreatedAtAction(nameof(GetById), new { Id = region.Id }, region);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRegion(int id, Region region)
        {
            if (id != region.Id)
            {
                return BadRequest("Regionb ID mismatch.");
            }

            await _regionService.UpdateRegion(region);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegion(int id)
        {
            var existingQuest = await _regionService.GetRegionById(id);
            if (existingQuest == null)
            {
                return NotFound("Not found");
            }

            await _regionService.DeleteRegion(id);
            return NoContent();
        }

    }
}
