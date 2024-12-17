using APIOpdracht_SteffVanWeereld.database;
using APIOpdracht_SteffVanWeereld.Models;
using Microsoft.EntityFrameworkCore;

namespace APIOpdracht_SteffVanWeereld.Services
{
    public class QuestDbService : IQuestsService
    {
        private readonly AppDbContext _context;

        public QuestDbService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Quest>> GetAllQuests()
        {
            return await _context.Quests.ToListAsync();
        }

        public async Task<Quest?> GetQuestByBoss(int bossId)
        {
            return await _context.Quests
                .FirstOrDefaultAsync(q => q.BossId == bossId);
        }

        public async Task<List<Quest>> GetQuestsByDifficulty(string difficulty)
        {
            return await _context.Quests
                .Where(q => q.Difficulty.ToLower() == difficulty.ToLower())
                .ToListAsync();
        }

        public async Task<List<Quest>> GetQuestsByRegion(int regionId)
        {
            return await _context.Quests
                .Where(q => q.RegionId == regionId)
                .ToListAsync();
        }

        public async Task<Quest?> GetQuestById(int id)
        {
            return await _context.Quests.FindAsync(id);
        }

        public async Task CreateQuest(Quest quest)
        {
            await _context.Quests.AddAsync(quest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuest(Quest quest)
        {
            var existingQuest = await _context.Quests.FindAsync(quest.Id);
            if (existingQuest != null)
            {
                existingQuest.Name = quest.Name;
                existingQuest.QuestPoints = quest.QuestPoints;
                existingQuest.Lenght = quest.Lenght;
                existingQuest.Difficulty = quest.Difficulty;
                existingQuest.Series = quest.Series;
                existingQuest.BossId = quest.BossId;
                existingQuest.RegionId = quest.RegionId;
                existingQuest.Image = quest.Image;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteQuest(int id)
        {
            var questToRemove = await _context.Quests.FindAsync(id);
            if (questToRemove != null)
            {
                _context.Quests.Remove(questToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
