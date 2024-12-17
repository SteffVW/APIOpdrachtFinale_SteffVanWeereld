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
        private readonly IQuestsService _questService;

        public QuestsController(IQuestsService questsService)
        {
            _questService = questsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Quest>>> GetAll()
        {
            var allQuests = await _questService.GetAllQuests();
            if (allQuests is null)
            {
                return NotFound("Not found");
            }
            return Ok(allQuests);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Quest>> GetById(int id)
        {
            var questToGet = await _questService.GetQuestById(id);

            if (questToGet != null)
            {
                return Ok(questToGet);
            }

            return NotFound("Not found");
        }
        [HttpGet("{id}/image")]
        public async Task<ActionResult<Quest>> GetImage(int id)
        {
            var quest = await _questService.GetQuestById(id);

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
            var quests = await _questService.GetQuestsByDifficulty(difficulty);

            if (quests == null)
            {
                return NotFound("No found");
            }

            return Ok(quests);
        }
        [HttpGet("region/{regionId}")]
        public async Task<ActionResult<Quest>> GetByRegion(int regionId)
        {
            var quests = await _questService.GetQuestsByRegion(regionId);

            if (quests == null)
            {
                return NotFound();
            }

            return Ok(quests);
        }
        [HttpGet("boss/{bossId}")]
        public async Task<ActionResult<Quest>> GetByBoss(int bossId)
        {
            var quest = await _questService.GetQuestByBoss(bossId);

            if (quest == null)
            {
                return NotFound();
            }

            return Ok(quest);
        }
        [HttpPost]
        public async Task<ActionResult<Quest?>> PostQuest(Quest quest)
        {
            await _questService.CreateQuest(quest);
            return CreatedAtAction(nameof(GetById), new { Id = quest.Id }, quest);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateQuest(int id, Quest quest)
        {
            if (id != quest.Id)
            {
                return BadRequest("Quest ID mismatch.");
            }

            await _questService.UpdateQuest(quest);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuest(int id)
        {
            var existingQuest = await _questService.GetQuestById(id);
            if (existingQuest == null)
            {
                return NotFound("Not found");
            }

            await _questService.DeleteQuest(id);
            return NoContent();
        }
    }
}
