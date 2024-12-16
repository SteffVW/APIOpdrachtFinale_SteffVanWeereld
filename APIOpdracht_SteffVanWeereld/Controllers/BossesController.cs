using APIOpdracht_SteffVanWeereld.database;
using APIOpdracht_SteffVanWeereld.Models;
using APIOpdracht_SteffVanWeereld.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIOpdracht_SteffVanWeereld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BossesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BossesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Boss>>> GetAll()
        {
            var allBosses = await _context.Bosses.ToListAsync();
            if(allBosses is null)
            {
                return NotFound("Not found");
            }
            return Ok(allBosses);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Boss>> GetById(int id)
        {
            var bossToGet = await _context.Bosses.FindAsync(id);

            if (bossToGet != null)
            {
                return Ok(bossToGet);
            }

            return NotFound("Not found");
        }
        [HttpGet("{id}/image")]
        public async Task<ActionResult<Boss>> GetImage(int id)
        {
            var boss = await _context.Bosses.FindAsync(id);

            if (boss != null)
            {
                return Ok(new {
                    name = boss.Name,
                    image = boss.Image
                });
            }

            return NotFound("Not found");
        }
        [HttpGet("region/{regionId}")]
        public async Task<ActionResult<List<Boss>>> GetByRegion(int regionId)
        {
            var bossesInRegion = await _context.Bosses.Where(x => x.RegionId == regionId).ToListAsync();

            if (bossesInRegion != null)
            {
                return Ok(bossesInRegion);
            }

            return NotFound();
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<Boss>>> SearchByName([FromQuery] string name)
        {
            var matchingBosses = await _context.Bosses.Where(x => x.Name.Contains(name)).ToListAsync();

            if (matchingBosses != null)
            {
                return Ok(matchingBosses);
            }
            return NotFound("Not found");
        }
        [HttpGet("maxHit/{count}")]
        public async Task<ActionResult<List<Boss>>> GetTopBosses(int count)
        {
            var topBosses = await _context.Bosses.OrderByDescending(x => x.MaxHit).Take(count).ToListAsync();

            if (topBosses.Any())
            {
                return Ok(topBosses);
            }
            return NotFound("No found");
        }
        [HttpPost]
        public async Task<ActionResult<Boss?>> PostBoss(Boss boss)
        {
            _context.Bosses.Add(boss);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { Id = boss.Id }, boss);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBoss(int id, Boss boss)
        {
            if (id != boss.Id)
            {
                return BadRequest("Boss ID mismatch.");
            }

            _context.Entry(boss).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBoss(int id)
        {
            var existingBoss = await _context.Bosses.FindAsync(id);
            if (existingBoss == null)
            {
                return NotFound("Not found");
            }

            _context.Remove(existingBoss);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
