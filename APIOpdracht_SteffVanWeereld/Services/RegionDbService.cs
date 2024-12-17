using APIOpdracht_SteffVanWeereld.database;
using APIOpdracht_SteffVanWeereld.Models;
using Microsoft.EntityFrameworkCore;

namespace APIOpdracht_SteffVanWeereld.Services
{
    public class RegionDbService : IRegionService
    {
        private readonly AppDbContext _context;

        public RegionDbService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRegion(Region region)
        {
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Region>> GetAllRegions()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region?> GetByCapital(string capital)
        {
            return await _context.Regions
                .FirstOrDefaultAsync(r => r.Capital.ToLower() == capital.ToLower());
        }

        public async Task<Region?> GetByQuest(int questId)
        {
            return await _context.Regions
                .FirstOrDefaultAsync(r => r.QuestIds != null && r.QuestIds.Contains(questId));
        }

        public async Task<Region?> GetRegionByBoss(int bossId)
        {
            return await _context.Regions
                .FirstOrDefaultAsync(r => r.BossIds != null && r.BossIds.Contains(bossId));
        }

        public async Task<Region?> GetRegionById(int id)
        {
            return await _context.Regions.FindAsync(id);
        }

        public async Task UpdateRegion(Region region)
        {
            var existingRegion = await _context.Regions.FindAsync(region.Id);
            if (existingRegion != null)
            {
                existingRegion.Name = region.Name;
                existingRegion.Capital = region.Capital;
                existingRegion.BossIds = region.BossIds;
                existingRegion.QuestIds = region.QuestIds;
                existingRegion.Image = region.Image;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRegion(int id)
        {
            var regionToRemove = await _context.Regions.FindAsync(id);
            if (regionToRemove != null)
            {
                _context.Regions.Remove(regionToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
