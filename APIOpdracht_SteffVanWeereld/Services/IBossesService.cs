using APIOpdracht_SteffVanWeereld.Models;

namespace APIOpdracht_SteffVanWeereld.Services
{
    public interface IBossesService
    {
        Task<List<Boss>> GetAllBosses();
        Task<Boss?> GetBossById(int id);
        Task<List<Boss>> GetBossesByRegion(int regionId);
        Task<Boss?> SearchBossesByName(string name);
        Task<List<Boss>> GetTopBossesByMaxHit(int count);
        Task CreateBoss(Boss boss);
        Task UpdateBoss(Boss boss);
        Task DeleteBoss(int id);
    }
}