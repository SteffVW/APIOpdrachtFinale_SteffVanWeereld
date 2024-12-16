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
        private readonly AppDbContext _context;

        public RegionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Region>>> GetAll()
        {
            var allRegions = await _context.Regions.ToListAsync();
            if (allRegions is null)
            {
                return NotFound("Not found");
            }
            return Ok(allRegions);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetById(int id)
        {
            var regionToGet = await _context.Regions.FindAsync(id);

            if (regionToGet != null)
            {
                return Ok(regionToGet);
            }

            return NotFound("Not found");
        }
        [HttpGet("{id}/image")]
        public async Task<ActionResult<Region>> GetImage(int id)
        {
            var region = await _context.Regions.FindAsync(id);

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
            var region = await _context.Regions.FirstOrDefaultAsync(r => r.Capital == capitalName);

            if (region == null)
            {
                return NotFound("Not found");
            }

            return Ok(region);
        }
        [HttpGet("boss/{bossId}")]
        public async Task<ActionResult<Region>> GetByBoss(int bossId)
        {
            var region = await _context.Regions.Include(r => r.Bosses).FirstOrDefaultAsync(r => r.Bosses.Any(b => b.Id == bossId));

            if (region == null)
            {
                return NotFound("Not found");
            }

            return Ok(region);
        }
        [HttpGet("quest/{questId}")]
        public async Task<ActionResult<Region>> GetByQuest(int questId)
        {
            var region = await _context.Regions.Include(r => r.Quests).FirstOrDefaultAsync(r => r.Quests.Any(q => q.Id == questId));

            if (region == null)
            {
                return NotFound("Not found");
            }

            return Ok(region);
        }
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { Id = region.Id }, region);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRegion(int id, Region region)
        {
            if (id != region.Id)
            {
                return BadRequest("Region ID mismatch.");
            }

            _context.Entry(region).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegion(int id)
        {
            var existingRegion = await _context.Regions.FindAsync(id);
            if (existingRegion == null)
            {
                return NotFound("Not found");
            }

            _context.Remove(existingRegion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
