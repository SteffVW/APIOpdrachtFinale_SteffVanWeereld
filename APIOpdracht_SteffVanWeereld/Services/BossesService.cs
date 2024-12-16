using APIOpdracht_SteffVanWeereld.database;
using APIOpdracht_SteffVanWeereld.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIOpdracht_SteffVanWeereld.Services
{
    public class BossesService: IBossesService
    {
        private readonly AppDbContext _context;
        public BossesService(AppDbContext context)
        {
            _context = context;
        }

        private static readonly List<Boss> Bosses = new List<Boss>
        {
            new Boss {Id = 1, Name = "Vorkath", MaxHit = 80, CombatLevel = 732, ExamineText = "This won't be fun.", RegionId = 2, QuestId = 1, Image = "https://oldschool.runescape.wiki/w/Vorkath#/media/File:Vorkath.png"},
            new Boss {Id = 2, Name = "Fragment of Seren", MaxHit = 73, ExamineText = "The brightest light casts the darkest shadow.", CombatLevel = 494, RegionId = 6, QuestId = 2, Image = "https://oldschool.runescape.wiki/w/Seren#/media/File:Seren.png"},
            new Boss {Id = 3, Name = "Vanstrom Klause", MaxHit = 24, ExamineText = "Formally Ascertes Hallow, now an evil vampyre.", CombatLevel = 459, RegionId = 7, QuestId = 3, Image = "https://oldschool.runescape.wiki/w/Vanstrom_Klause#/media/File:Vanstrom_Klause_(vampyre).png"},
            new Boss {Id = 4, Name = "Barrelchest", MaxHit = 35, ExamineText = "It's trying to mash you flat! Less examine, more fight", CombatLevel = 190, RegionId = 7, QuestId = 4, Image = "https://oldschool.runescape.wiki/w/Barrelchest#/media/File:Barrelchest.png"},
            new Boss {Id = 5, Name = "Ice Troll King", MaxHit = 21, CombatLevel = 122, ExamineText = "An impressive looking troll.", RegionId = 2, QuestId = 5, Image = "https://oldschool.runescape.wiki/w/Ice_Troll_King#/media/File:Ice_Troll_King.png"},
            new Boss {Id = 6, Name = "Elvarg", MaxHit = 8, CombatLevel = 83, ExamineText = "Roar! A dragon!", RegionId = 5, QuestId = 6, Image = "https://oldschool.runescape.wiki/w/Elvarg#/media/File:Elvarg.png"},
            new Boss {Id = 7, Name = "Xamphur", MaxHit = 18, CombatLevel = 239, ExamineText = "If evil had a look, this would be it.", RegionId = 3, QuestId = 7, Image = "https://oldschool.runescape.wiki/w/Xamphur#/media/File:Xamphur_(monster).png"},
            new Boss {Id = 8, Name = "Slug Prince", MaxHit = 6, CombatLevel = 62, ExamineText = "A child of aquatic evil.", RegionId = 1, QuestId = 8, Image = "https://oldschool.runescape.wiki/w/Slug_Prince#/media/File:Slug_Prince.png"},
            new Boss {Id = 9, Name = "Alomone", MaxHit = 5, CombatLevel = 13, ExamineText = "Leader of the Hazeel Cult.", RegionId = 4, QuestId = 9, Image = "https://oldschool.runescape.wiki/w/Alomone#/media/File:Alomone.png"},
        };

        public List<Boss> GetAllBossesDb()
        {
            return _context.Bosses.Include(b => b.Region).Include(b => b.Quest).ToList();
        }

        public void AddBoss(Boss newBoss)
        {
            _context.Bosses.Add(newBoss);
            _context.SaveChanges();
        }

        public Task<List<Boss>> GetAllBosses()
        {
            return Task.FromResult(Bosses);
        }

        public Task<Boss?> GetBossById(int id)
        {
            var bossToGet = Bosses.FirstOrDefault(x => x.Id == id);
           
            return Task.FromResult(bossToGet);
        }

        public Task<List<Boss>> GetBossesByRegion(int regionId)
        {
            var bosses = Bosses.Where(boss => boss.RegionId == regionId).ToList();

            return Task.FromResult(bosses);
        }

        public Task<List<Boss>> GetTopBossesByMaxHit(int count)
        {
            var topBosses = Bosses.OrderByDescending(boss => boss.MaxHit).Take(count).ToList();

            return Task.FromResult(topBosses);
        }

        public Task<Boss?> SearchBossesByName(string name)
        {
            var bosses = Bosses.FirstOrDefault(boss => boss.Name.ToLower() == name.ToLower());

            return Task.FromResult(bosses);
        }
        public Task CreateBoss(Boss boss)
        {
            Bosses.Add(boss);
            return Task.CompletedTask;
        }
        public async Task UpdateBoss(Boss boss)
        {
            var existingBoss = Bosses.FirstOrDefault(b => b.Id == boss.Id);
            if (existingBoss != null)
            {
                existingBoss.Name = boss.Name;
                existingBoss.CombatLevel = boss.CombatLevel;
                existingBoss.MaxHit = boss.MaxHit;
                existingBoss.RegionId = boss.RegionId;
                existingBoss.QuestId = boss.QuestId;
                existingBoss.ExamineText = boss.ExamineText;
                existingBoss.Image = boss.Image;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteBoss(int id)
        {
            var bossToRemove = Bosses.FirstOrDefault(b => b.Id == id);
            if (bossToRemove != null)
            {
                Bosses.Remove(bossToRemove);
            }
            await Task.CompletedTask;
        }
    }
}
