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
    public class QuestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Quest>>> GetAll()
        {
            var allQuests = await _context.Quests.ToListAsync();
            if (allQuests is null)
            {
                return NotFound("Not found");
            }
            return Ok(allQuests);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Quest>> GetById(int id)
        {
            var questToGet = await _context.Quests.FindAsync(id);

            if (questToGet != null)
            {
                return Ok(questToGet);
            }

            return NotFound("Not found");
        }
        [HttpGet("{id}/image")]
        public async Task<ActionResult<Quest>> GetImage(int id)
        {
            var quest = await _context.Quests.FindAsync(id);

            if (quest != null)
            {
                return Ok(new
                {
                    name = quest.Name,
                    image = quest.Image
                });
            }

            return NotFound("Not found");
        }
        [HttpGet("difficulty/{difficulty}")]
        public async Task<ActionResult<Quest>> GetByDifficulty(string difficulty)
        {
            var quests = await _context.Quests.Where(q => q.Difficulty == difficulty).ToListAsync();

            if (quests == null)
            {
                return NotFound("No found");
            }

            return Ok(quests);
        }
        [HttpGet("region/{regionId}")]
        public async Task<ActionResult<Quest>> GetByRegion(int regionId)
        {
            var quests = await _context.Quests.Where(q => q.RegionId == regionId).Include(q => q.Region).ToListAsync();

            if (quests == null)
            {
                return NotFound();
            }

            return Ok(quests);
        }
        [HttpGet("boss/{bossId}")]
        public async Task<ActionResult<Quest>> GetByBoss(int bossId)
        {
            var quest = await _context.Quests.Include(q => q.Boss).FirstOrDefaultAsync(q => q.BossId == bossId);

            if (quest == null)
            {
                return NotFound();
            }

            return Ok(quest);
        }
        [HttpPost]
        public async Task<ActionResult<Quest?>> PostQuest(Quest quest)
        {
            _context.Quests.Add(quest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { Id = quest.Id }, quest);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateQuest(int id, Quest quest)
        {
            if (id != quest.Id)
            {
                return BadRequest("Quest ID mismatch.");
            }

            _context.Entry(quest).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuest(int id)
        {
            var existingQuest = await _context.Quests.FindAsync(id);
            if (existingQuest == null)
            {
                return NotFound("Not found");
            }

            _context.Remove(existingQuest);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
