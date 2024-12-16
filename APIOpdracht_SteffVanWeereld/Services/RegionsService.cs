using APIOpdracht_SteffVanWeereld.database;
using APIOpdracht_SteffVanWeereld.Models;
using Microsoft.EntityFrameworkCore;

namespace APIOpdracht_SteffVanWeereld.Services
{
    public class RegionService : IRegionService
    {
        private static readonly List<Region> Regions = new List<Region>
        {
           new Region {Id = 1, Capital = "Falador", Name = "Asgarnia", BossIds = [8], QuestIds = [8], Image = "https://oldschool.runescape.wiki/w/Asgarnia#/media/File:Asgarnia_map.png"},
           new Region {Id = 2, Capital = "Rellekka", Name = "Fremmennik", BossIds = [1, 5], QuestIds = [5, 1], Image = "https://oldschool.runescape.wiki/w/Fremennik_Province#/media/File:Fremennik_Province_map.png"},
           new Region {Id = 3, Capital = "Kourend Castle", Name = "Great Kourend", BossIds = [7], QuestIds = [7], Image = "https://oldschool.runescape.wiki/w/Great_Kourend#/media/File:Great_Kourend_map.png"},
           new Region {Id = 4, Capital = "Ardougne", Name = "Kandarin", BossIds = [9], QuestIds = [9], Image = "https://oldschool.runescape.wiki/w/Kandarin#/media/File:Kandarin_map.png"},
           new Region {Id = 5, Capital = "Varrock", Name = "Misthalin", BossIds = [6], QuestIds = [6], Image = "https://oldschool.runescape.wiki/w/Misthalin#/media/File:Misthalin_map.png"},
           new Region {Id = 6, Capital = "Prifddinas", Name = "Tirannwn", BossIds = [2], QuestIds = [2], Image = "https://oldschool.runescape.wiki/w/Prifddinas#/media/File:Prifddinas_entrance_artwork.jpg"},
           new Region {Id = 7, Capital = "Darkmeyer", Name = "Morytania", BossIds = [3, 4], QuestIds = [3, 4], Image = "https://oldschool.runescape.wiki/w/Morytania#/media/File:Morytania_map.png"},
        };

        private readonly AppDbContext _context;

        public RegionService(AppDbContext context)
        {
            _context = context;
        }

        public void AddRegion(Region region)
        {
            _context.Regions.Add(region);
            _context.SaveChanges();
        }

        public Task<List<Region>> GetAllRegions()
        {
            return Task.FromResult(Regions);
        }

        public Task<Region?> GetByCapital(string capital)
        {
            var region = Regions.FirstOrDefault(x => x.Capital.ToLower() == capital.ToLower());

            return Task.FromResult(region);
        }

        public Task<Region?> GetByQuest(int questId)
        {
            var region = Regions.FirstOrDefault(x => x.QuestIds!.Contains(questId));

            return Task.FromResult(region);
        }

        public Task<Region?> GetRegionByBoss(int bossId)
        {
            var region = Regions.FirstOrDefault(x => x.BossIds!.Contains(bossId));

            return Task.FromResult(region);
        }

        public Task<Region?> GetRegionById(int id)
        {
            var bossToGet = Regions.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(bossToGet);
        }
        public Task CreateRegion(Region region)
        {
            Regions.Add(region);

            return Task.CompletedTask;
        }
        public async Task UpdateRegion(Region region)
        {
            var existingRegion = Regions.FirstOrDefault(r => r.Id == region.Id);
            if (existingRegion != null)
            {
                existingRegion.Name = region.Name;
                existingRegion.Capital = region.Capital;
                existingRegion.BossIds = region.BossIds;
                existingRegion.QuestIds = region.QuestIds;
                existingRegion.Image = region.Image;
            }
            await Task.CompletedTask;
        }
        public async Task DeleteRegion(int id)
        {
            var regionToRemove = Regions.FirstOrDefault(r => r.Id == id);
            if (regionToRemove != null)
            {
                Regions.Remove(regionToRemove);
            }
            await Task.CompletedTask;
        }

    }
}