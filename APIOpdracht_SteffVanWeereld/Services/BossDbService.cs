using APIOpdracht_SteffVanWeereld.database;
using APIOpdracht_SteffVanWeereld.Models;
using Microsoft.EntityFrameworkCore;

namespace APIOpdracht_SteffVanWeereld.Services
{
    public class BossDbService : IBossesService
    {
        private readonly AppDbContext _context;

        public BossDbService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Boss>> GetAllBosses()
        {
            return await _context.Bosses.Include(boss => boss.Quest).Include(b => b.Region).ToListAsync();
        }

        public async Task<Boss?> GetBossById(int id)
        {
            return await _context.Bosses.Include(boss => boss.Quest).Include(b => b.Region).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Boss>> GetBossesByRegion(int regionId)
        {
            return await _context.Bosses.Include(boss => boss.Quest).Include(b => b.Region).Where(boss => boss.RegionId == regionId).ToListAsync();
        }

        public async Task<List<Boss>> GetTopBossesByMaxHit(int count)
        {
            return await _context.Bosses.Include(boss => boss.Quest).Include(b => b.Region).OrderByDescending(boss => boss.MaxHit).Take(count).ToListAsync();
        }

        public async Task<Boss?> SearchBossesByName(string name)
        {
            return await _context.Bosses.Include(boss => boss.Quest).Include(b => b.Region).FirstOrDefaultAsync(boss => boss.Name.ToLower() == name.ToLower());
        }

        public async Task CreateBoss(Boss boss)
        {
            await _context.Bosses.AddAsync(boss);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBoss(Boss boss)
        {
            var existingBoss = await _context.Bosses.FirstOrDefaultAsync(b => b.Id == boss.Id);
            if (existingBoss != null)
            {
                existingBoss.Name = boss.Name;
                existingBoss.CombatLevel = boss.CombatLevel;
                existingBoss.MaxHit = boss.MaxHit;
                existingBoss.RegionId = boss.RegionId;
                existingBoss.QuestId = boss.QuestId;
                existingBoss.ExamineText = boss.ExamineText;
                existingBoss.Image = boss.Image;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBoss(int id)
        {
            var bossToRemove = await _context.Bosses.FirstOrDefaultAsync(b => b.Id == id);
            if (bossToRemove != null)
            {
                _context.Bosses.Remove(bossToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
