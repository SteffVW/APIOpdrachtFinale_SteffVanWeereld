using APIOpdracht_SteffVanWeereld.Models;

namespace APIOpdracht_SteffVanWeereld.Services
{
    public interface IQuestsService
    {
        Task<List<Quest>> GetAllQuests();
        Task<Quest?> GetQuestById(int id);
        Task<List<Quest>> GetQuestsByDifficulty(string difficulty);
        Task<Quest?> GetQuestByBoss(int bossId);
        Task<List<Quest>> GetQuestsByRegion(int regionId);
        Task CreateQuest(Quest quest);
        Task UpdateQuest(Quest quest);
        Task DeleteQuest(int id);
        void AddQuest(Quest newQuest);
        List<Quest> GetAllQuestsDb();
    }
}
