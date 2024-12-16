using APIOpdracht_SteffVanWeereld.Models;

namespace APIOpdracht_SteffVanWeereld.Services
{
    public interface IRegionService
    {
        Task<List<Region>> GetAllRegions();
        Task<Region?> GetRegionById(int id);
        Task<Region?> GetByCapital(string capital);
        Task<Region?> GetByQuest(int questId);
        Task<Region?> GetRegionByBoss(int bossId);
        Task CreateRegion(Region region);
        Task UpdateRegion(Region region);
        Task DeleteRegion(int id);
        void AddRegion(Region region);
    }
}
