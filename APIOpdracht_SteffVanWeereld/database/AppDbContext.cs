using APIOpdracht_SteffVanWeereld.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace APIOpdracht_SteffVanWeereld.database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Boss> Bosses { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boss>().HasData(
                 new Boss { Id = 1, Name = "Vorkath", MaxHit = 80, CombatLevel = 732, ExamineText = "This won't be fun.", RegionId = 2, QuestId = 1, Image = "https://oldschool.runescape.wiki/w/Vorkath#/media/File:Vorkath.png" },
                 new Boss { Id = 2, Name = "Fragment of Seren", MaxHit = 73, ExamineText = "The brightest light casts the darkest shadow.", CombatLevel = 494, RegionId = 6, QuestId = 2, Image = "https://oldschool.runescape.wiki/w/Seren#/media/File:Seren.png" },
                 new Boss { Id = 3, Name = "Vanstrom Klause", MaxHit = 24, ExamineText = "Formally Ascertes Hallow, now an evil vampyre.", CombatLevel = 459, RegionId = 7, QuestId = 3, Image = "https://oldschool.runescape.wiki/w/Vanstrom_Klause#/media/File:Vanstrom_Klause_(vampyre).png" },
                 new Boss { Id = 4, Name = "Barrelchest", MaxHit = 35, ExamineText = "It's trying to mash you flat! Less examine, more fight", CombatLevel = 190, RegionId = 7, QuestId = 4, Image = "https://oldschool.runescape.wiki/w/Barrelchest#/media/File:Barrelchest.png" },
                 new Boss { Id = 5, Name = "Ice Troll King", MaxHit = 21, CombatLevel = 122, ExamineText = "An impressive looking troll.", RegionId = 2, QuestId = 5, Image = "https://oldschool.runescape.wiki/w/Ice_Troll_King#/media/File:Ice_Troll_King.png" },
                 new Boss { Id = 6, Name = "Elvarg", MaxHit = 8, CombatLevel = 83, ExamineText = "Roar! A dragon!", RegionId = 5, QuestId = 6, Image = "https://oldschool.runescape.wiki/w/Elvarg#/media/File:Elvarg.png" },
                 new Boss { Id = 7, Name = "Xamphur", MaxHit = 18, CombatLevel = 239, ExamineText = "If evil had a look, this would be it.", RegionId = 3, QuestId = 7, Image = "https://oldschool.runescape.wiki/w/Xamphur#/media/File:Xamphur_(monster).png" },
                 new Boss { Id = 8, Name = "Slug Prince", MaxHit = 6, CombatLevel = 62, ExamineText = "A child of aquatic evil.", RegionId = 1, QuestId = 8, Image = "https://oldschool.runescape.wiki/w/Slug_Prince#/media/File:Slug_Prince.png" },
                 new Boss { Id = 9, Name = "Alomone", MaxHit = 5, CombatLevel = 13, ExamineText = "Leader of the Hazeel Cult.", RegionId = 4, QuestId = 9, Image = "https://oldschool.runescape.wiki/w/Alomone#/media/File:Alomone.png" }
             );

            // Seed data for Regions
            modelBuilder.Entity<Region>().HasData(
                new Region { Id = 1, Capital = "Falador", Name = "Asgarnia", Image = "https://oldschool.runescape.wiki/w/Asgarnia#/media/File:Asgarnia_map.png" },
                new Region { Id = 2, Capital = "Rellekka", Name = "Fremmennik", Image = "https://oldschool.runescape.wiki/w/Fremennik_Province#/media/File:Fremennik_Province_map.png" },
                new Region { Id = 3, Capital = "Kourend Castle", Name = "Great Kourend", Image = "https://oldschool.runescape.wiki/w/Great_Kourend#/media/File:Great_Kourend_map.png" },
                new Region { Id = 4, Capital = "Ardougne", Name = "Kandarin", Image = "https://oldschool.runescape.wiki/w/Kandarin#/media/File:Kandarin_map.png" },
                new Region { Id = 5, Capital = "Varrock", Name = "Misthalin", Image = "https://oldschool.runescape.wiki/w/Misthalin#/media/File:Misthalin_map.png" },
                new Region { Id = 6, Capital = "Prifddinas", Name = "Tirannwn", Image = "https://oldschool.runescape.wiki/w/Prifddinas#/media/File:Prifddinas_entrance_artwork.jpg" },
                new Region { Id = 7, Capital = "Darkmeyer", Name = "Morytania", Image = "https://oldschool.runescape.wiki/w/Morytania#/media/File:Morytania_map.png" }
            );

            // Seed data for Quests
            modelBuilder.Entity<Quest>().HasData(
                new Quest { Id = 1, Name = "Dragonslayer 2", Lenght = "Very Long", Difficulty = "Grandmaster", Series = "Dragonkin", QuestPoints = 5, BossId = 1, RegionId = 2, Image = "https://oldschool.runescape.wiki/images/Dragon_Slayer_II_reward_scroll.png?55a92" },
                new Quest { Id = 2, Name = "Song of the elves", Lenght = "Very Long", Difficulty = "Grandmaster", Series = "Elfs", QuestPoints = 4, BossId = 2, RegionId = 6, Image = "https://oldschool.runescape.wiki/images/Song_of_the_Elves_reward_scroll.png?85a1f" },
                new Quest { Id = 3, Name = "Sins of the father", Lenght = "Long", Difficulty = "Master", Series = "Myreque", QuestPoints = 2, BossId = 3, RegionId = 7, Image = "https://oldschool.runescape.wiki/images/Sins_of_the_Father_reward_scroll.png?6c96f" },
                new Quest { Id = 4, Name = "Great brain robbery", Lenght = "Medium", Difficulty = "Experienced", Series = "Pirate", QuestPoints = 2, BossId = 4, RegionId = 7, Image = "https://oldschool.runescape.wiki/images/The_Great_Brain_Robbery_reward_scroll.png?e9e6c" },
                new Quest { Id = 5, Name = "The Fremennik Isles", Lenght = "Medium", Difficulty = "Experienced", Series = "Fremmennik", QuestPoints = 1, BossId = 5, RegionId = 2, Image = "https://oldschool.runescape.wiki/images/The_Fremennik_Isles_reward_scroll.png?805aa" },
                new Quest { Id = 6, Name = "Dragonslayer 1", Lenght = "Medium", Difficulty = "Experienced", Series = "Dragonkin", QuestPoints = 2, BossId = 6, RegionId = 5, Image = "https://oldschool.runescape.wiki/images/Dragon_Slayer_reward_scroll.png?5517f" },
                new Quest { Id = 7, Name = "A kingdom divided", Lenght = "Long", Difficulty = "Experienced", Series = "Great Kourend", QuestPoints = 2, BossId = 7, RegionId = 3, Image = "https://oldschool.runescape.wiki/images/A_Kingdom_Divided_reward_scroll.png?5a404" },
                new Quest { Id = 8, Name = "The Slug Menace", Lenght = "Medium", Difficulty = "Intermediate", Series = "Temple knight", QuestPoints = 2, BossId = 8, RegionId = 1, Image = "https://oldschool.runescape.wiki/images/The_Slug_Menace_reward_scroll.png?8291b" },
                new Quest { Id = 9, Name = "Hazeel cult", Lenght = "Very Short", Difficulty = "Novice", Series = "Mahjarrat", QuestPoints = 1, BossId = 9, RegionId = 4, Image = "https://oldschool.runescape.wiki/w/File:Hazeel_Cult_reward_scroll.png" }
            );

            modelBuilder.Entity<Region>()
                .Ignore(r => r.BossIds)
                .Ignore(r => r.QuestIds);

            // Configure other relationships as before
            modelBuilder.Entity<Boss>()
                .HasOne(b => b.Quest)
                .WithOne(q => q.Boss)
                .HasForeignKey<Quest>(q => q.BossId);

            modelBuilder.Entity<Boss>()
                .HasOne(b => b.Region)
                .WithMany(r => r.Bosses)
                .HasForeignKey(b => b.RegionId);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.Region)
                .WithMany(r => r.Quests)
                .HasForeignKey(q => q.RegionId);
        }
    }
}
