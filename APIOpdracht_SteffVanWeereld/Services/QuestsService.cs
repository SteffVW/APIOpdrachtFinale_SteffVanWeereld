using APIOpdracht_SteffVanWeereld.database;
using APIOpdracht_SteffVanWeereld.Models;
using Microsoft.EntityFrameworkCore;

namespace APIOpdracht_SteffVanWeereld.Services
{
    public class QuestsService : IQuestsService
    {
        private readonly AppDbContext _context;

        public QuestsService(AppDbContext context)
        {
            _context = context;
        }

        private static readonly List<Quest> Quests = new List<Quest>
        {
            new Quest {Id = 1, Name = "Dragonslayer 2", Lenght = "Very Long", Difficulty = "Grandmaster", Series = "Dragonkin", QuestPoints = 5, BossId = 1, RegionId = 2, Image= "https://oldschool.runescape.wiki/images/Dragon_Slayer_II_reward_scroll.png?55a92"},
            new Quest {Id = 2, Name = "Song of the elves", Lenght = "Very Long", Difficulty = "Grandmaster", Series = "Elfs", QuestPoints = 4, BossId = 2, RegionId = 6, Image= "https://oldschool.runescape.wiki/images/Song_of_the_Elves_reward_scroll.png?85a1f"},
            new Quest {Id = 3, Name = "Sins of the father", Lenght = "Long", Difficulty = "Master", Series = "Myreque", QuestPoints = 2, BossId = 3, RegionId = 7, Image= "https://oldschool.runescape.wiki/images/Sins_of_the_Father_reward_scroll.png?6c96f"},
            new Quest {Id = 4, Name = "Great brain robbery", Lenght = "Medium", Difficulty = "Experienced", Series = "Pirate", QuestPoints = 2, BossId = 4, RegionId = 7, Image= "https://oldschool.runescape.wiki/images/The_Great_Brain_Robbery_reward_scroll.png?e9e6c"},
            new Quest {Id = 5, Name = "The Fremennik Isles", Lenght = "Medium", Difficulty = "Experienced", Series = "Fremmennik", QuestPoints = 1, BossId = 5, RegionId = 2, Image= "https://oldschool.runescape.wiki/images/The_Fremennik_Isles_reward_scroll.png?805aa"},
            new Quest {Id = 6, Name = "Dragonslayer 1", Lenght = "Medium", Difficulty = "Experienced", Series = "Dragonkin", QuestPoints = 2, BossId = 6, RegionId = 5, Image= "https://oldschool.runescape.wiki/images/Dragon_Slayer_reward_scroll.png?5517f"},
            new Quest {Id = 7, Name = "A kingdom divided", Lenght = "Long", Difficulty = "Experienced", Series = "Great Kourend", QuestPoints = 2, BossId = 7, RegionId = 3, Image= "https://oldschool.runescape.wiki/images/A_Kingdom_Divided_reward_scroll.png?5a404"},
            new Quest {Id = 8, Name = "The Slug Menace", Lenght = "Medium", Difficulty = "Intermediate", Series = "Temple knight", QuestPoints = 2, BossId = 8, RegionId = 1, Image= "https://oldschool.runescape.wiki/images/The_Slug_Menace_reward_scroll.png?8291b"},
            new Quest {Id = 9, Name = "Hazeel cult", Lenght = "Very Short", Difficulty = "Novice", Series = "Mahjarrat", QuestPoints = 1, BossId = 9, RegionId = 4, Image= "https://oldschool.runescape.wiki/w/File:Hazeel_Cult_reward_scroll.png"},
        };

        public Task<Quest?> GetQuestByBoss(int bossId)
        {
            var questByBoss = Quests.FirstOrDefault(x => x.BossId == bossId);

            return Task.FromResult(questByBoss);
        }

        public Task<List<Quest>> GetQuestsByDifficulty(string difficulty)
        {
            var questByBoss = Quests.Where(x => x.Difficulty.ToLower() == difficulty.ToLower()).ToList();

            return Task.FromResult(questByBoss);
        }

        public Task<List<Quest>> GetQuestsByRegion(int regionId)
        {
            var questByBoss = Quests.Where(x => x.RegionId == regionId).ToList();

            return Task.FromResult(questByBoss);
        }

        public Task<List<Quest>> GetAllQuests()
        {
            return Task.FromResult(Quests);
        }

        public Task<Quest?> GetQuestById(int id)
        {
            var questToGet = Quests.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(questToGet);
        }
        public Task CreateQuest(Quest quest)
        {
            Quests.Add(quest);
            return Task.CompletedTask;
        }
        public async Task UpdateQuest(Quest quest)
        {
            var existingQuest = Quests.FirstOrDefault(q => q.Id == quest.Id);
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
            }
            await Task.CompletedTask;
        }
        public async Task DeleteQuest(int id)
        {
            var questToRemove = Quests.FirstOrDefault(q => q.Id == id);
            if (questToRemove != null)
            {
                Quests.Remove(questToRemove);
            }
            await Task.CompletedTask;
        }
    }
}
