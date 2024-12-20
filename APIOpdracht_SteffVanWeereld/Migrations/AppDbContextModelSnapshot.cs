﻿// <auto-generated />
using APIOpdracht_SteffVanWeereld.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIOpdracht_SteffVanWeereld.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("APIOpdracht_SteffVanWeereld.Models.Boss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CombatLevel")
                        .HasColumnType("int");

                    b.Property<string>("ExamineText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MaxHit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("QuestId")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Bosses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CombatLevel = 732,
                            ExamineText = "This won't be fun.",
                            Image = "https://oldschool.runescape.wiki/w/Vorkath#/media/File:Vorkath.png",
                            MaxHit = 80,
                            Name = "Vorkath",
                            QuestId = 1,
                            RegionId = 2
                        },
                        new
                        {
                            Id = 2,
                            CombatLevel = 494,
                            ExamineText = "The brightest light casts the darkest shadow.",
                            Image = "https://oldschool.runescape.wiki/w/Seren#/media/File:Seren.png",
                            MaxHit = 73,
                            Name = "Fragment of Seren",
                            QuestId = 2,
                            RegionId = 6
                        },
                        new
                        {
                            Id = 3,
                            CombatLevel = 459,
                            ExamineText = "Formally Ascertes Hallow, now an evil vampyre.",
                            Image = "https://oldschool.runescape.wiki/w/Vanstrom_Klause#/media/File:Vanstrom_Klause_(vampyre).png",
                            MaxHit = 24,
                            Name = "Vanstrom Klause",
                            QuestId = 3,
                            RegionId = 7
                        },
                        new
                        {
                            Id = 4,
                            CombatLevel = 190,
                            ExamineText = "It's trying to mash you flat! Less examine, more fight",
                            Image = "https://oldschool.runescape.wiki/w/Barrelchest#/media/File:Barrelchest.png",
                            MaxHit = 35,
                            Name = "Barrelchest",
                            QuestId = 4,
                            RegionId = 7
                        },
                        new
                        {
                            Id = 5,
                            CombatLevel = 122,
                            ExamineText = "An impressive looking troll.",
                            Image = "https://oldschool.runescape.wiki/w/Ice_Troll_King#/media/File:Ice_Troll_King.png",
                            MaxHit = 21,
                            Name = "Ice Troll King",
                            QuestId = 5,
                            RegionId = 2
                        },
                        new
                        {
                            Id = 6,
                            CombatLevel = 83,
                            ExamineText = "Roar! A dragon!",
                            Image = "https://oldschool.runescape.wiki/w/Elvarg#/media/File:Elvarg.png",
                            MaxHit = 8,
                            Name = "Elvarg",
                            QuestId = 6,
                            RegionId = 5
                        },
                        new
                        {
                            Id = 7,
                            CombatLevel = 239,
                            ExamineText = "If evil had a look, this would be it.",
                            Image = "https://oldschool.runescape.wiki/w/Xamphur#/media/File:Xamphur_(monster).png",
                            MaxHit = 18,
                            Name = "Xamphur",
                            QuestId = 7,
                            RegionId = 3
                        },
                        new
                        {
                            Id = 8,
                            CombatLevel = 62,
                            ExamineText = "A child of aquatic evil.",
                            Image = "https://oldschool.runescape.wiki/w/Slug_Prince#/media/File:Slug_Prince.png",
                            MaxHit = 6,
                            Name = "Slug Prince",
                            QuestId = 8,
                            RegionId = 1
                        },
                        new
                        {
                            Id = 9,
                            CombatLevel = 13,
                            ExamineText = "Leader of the Hazeel Cult.",
                            Image = "https://oldschool.runescape.wiki/w/Alomone#/media/File:Alomone.png",
                            MaxHit = 5,
                            Name = "Alomone",
                            QuestId = 9,
                            RegionId = 4
                        });
                });

            modelBuilder.Entity("APIOpdracht_SteffVanWeereld.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BossId")
                        .HasColumnType("int");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lenght")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("QuestPoints")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BossId")
                        .IsUnique();

                    b.HasIndex("RegionId");

                    b.ToTable("Quests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BossId = 1,
                            Difficulty = "Grandmaster",
                            Image = "https://oldschool.runescape.wiki/images/Dragon_Slayer_II_reward_scroll.png?55a92",
                            Lenght = "Very Long",
                            Name = "Dragonslayer 2",
                            QuestPoints = 5,
                            RegionId = 2,
                            Series = "Dragonkin"
                        },
                        new
                        {
                            Id = 2,
                            BossId = 2,
                            Difficulty = "Grandmaster",
                            Image = "https://oldschool.runescape.wiki/images/Song_of_the_Elves_reward_scroll.png?85a1f",
                            Lenght = "Very Long",
                            Name = "Song of the elves",
                            QuestPoints = 4,
                            RegionId = 6,
                            Series = "Elfs"
                        },
                        new
                        {
                            Id = 3,
                            BossId = 3,
                            Difficulty = "Master",
                            Image = "https://oldschool.runescape.wiki/images/Sins_of_the_Father_reward_scroll.png?6c96f",
                            Lenght = "Long",
                            Name = "Sins of the father",
                            QuestPoints = 2,
                            RegionId = 7,
                            Series = "Myreque"
                        },
                        new
                        {
                            Id = 4,
                            BossId = 4,
                            Difficulty = "Experienced",
                            Image = "https://oldschool.runescape.wiki/images/The_Great_Brain_Robbery_reward_scroll.png?e9e6c",
                            Lenght = "Medium",
                            Name = "Great brain robbery",
                            QuestPoints = 2,
                            RegionId = 7,
                            Series = "Pirate"
                        },
                        new
                        {
                            Id = 5,
                            BossId = 5,
                            Difficulty = "Experienced",
                            Image = "https://oldschool.runescape.wiki/images/The_Fremennik_Isles_reward_scroll.png?805aa",
                            Lenght = "Medium",
                            Name = "The Fremennik Isles",
                            QuestPoints = 1,
                            RegionId = 2,
                            Series = "Fremmennik"
                        },
                        new
                        {
                            Id = 6,
                            BossId = 6,
                            Difficulty = "Experienced",
                            Image = "https://oldschool.runescape.wiki/images/Dragon_Slayer_reward_scroll.png?5517f",
                            Lenght = "Medium",
                            Name = "Dragonslayer 1",
                            QuestPoints = 2,
                            RegionId = 5,
                            Series = "Dragonkin"
                        },
                        new
                        {
                            Id = 7,
                            BossId = 7,
                            Difficulty = "Experienced",
                            Image = "https://oldschool.runescape.wiki/images/A_Kingdom_Divided_reward_scroll.png?5a404",
                            Lenght = "Long",
                            Name = "A kingdom divided",
                            QuestPoints = 2,
                            RegionId = 3,
                            Series = "Great Kourend"
                        },
                        new
                        {
                            Id = 8,
                            BossId = 8,
                            Difficulty = "Intermediate",
                            Image = "https://oldschool.runescape.wiki/images/The_Slug_Menace_reward_scroll.png?8291b",
                            Lenght = "Medium",
                            Name = "The Slug Menace",
                            QuestPoints = 2,
                            RegionId = 1,
                            Series = "Temple knight"
                        },
                        new
                        {
                            Id = 9,
                            BossId = 9,
                            Difficulty = "Novice",
                            Image = "https://oldschool.runescape.wiki/w/File:Hazeel_Cult_reward_scroll.png",
                            Lenght = "Very Short",
                            Name = "Hazeel cult",
                            QuestPoints = 1,
                            RegionId = 4,
                            Series = "Mahjarrat"
                        });
                });

            modelBuilder.Entity("APIOpdracht_SteffVanWeereld.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Capital")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capital = "Falador",
                            Image = "https://oldschool.runescape.wiki/w/Asgarnia#/media/File:Asgarnia_map.png",
                            Name = "Asgarnia"
                        },
                        new
                        {
                            Id = 2,
                            Capital = "Rellekka",
                            Image = "https://oldschool.runescape.wiki/w/Fremennik_Province#/media/File:Fremennik_Province_map.png",
                            Name = "Fremmennik"
                        },
                        new
                        {
                            Id = 3,
                            Capital = "Kourend Castle",
                            Image = "https://oldschool.runescape.wiki/w/Great_Kourend#/media/File:Great_Kourend_map.png",
                            Name = "Great Kourend"
                        },
                        new
                        {
                            Id = 4,
                            Capital = "Ardougne",
                            Image = "https://oldschool.runescape.wiki/w/Kandarin#/media/File:Kandarin_map.png",
                            Name = "Kandarin"
                        },
                        new
                        {
                            Id = 5,
                            Capital = "Varrock",
                            Image = "https://oldschool.runescape.wiki/w/Misthalin#/media/File:Misthalin_map.png",
                            Name = "Misthalin"
                        },
                        new
                        {
                            Id = 6,
                            Capital = "Prifddinas",
                            Image = "https://oldschool.runescape.wiki/w/Prifddinas#/media/File:Prifddinas_entrance_artwork.jpg",
                            Name = "Tirannwn"
                        },
                        new
                        {
                            Id = 7,
                            Capital = "Darkmeyer",
                            Image = "https://oldschool.runescape.wiki/w/Morytania#/media/File:Morytania_map.png",
                            Name = "Morytania"
                        });
                });

            modelBuilder.Entity("APIOpdracht_SteffVanWeereld.Models.Boss", b =>
                {
                    b.HasOne("APIOpdracht_SteffVanWeereld.Models.Region", "Region")
                        .WithMany("Bosses")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("APIOpdracht_SteffVanWeereld.Models.Quest", b =>
                {
                    b.HasOne("APIOpdracht_SteffVanWeereld.Models.Boss", "Boss")
                        .WithOne("Quest")
                        .HasForeignKey("APIOpdracht_SteffVanWeereld.Models.Quest", "BossId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIOpdracht_SteffVanWeereld.Models.Region", "Region")
                        .WithMany("Quests")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boss");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("APIOpdracht_SteffVanWeereld.Models.Boss", b =>
                {
                    b.Navigation("Quest");
                });

            modelBuilder.Entity("APIOpdracht_SteffVanWeereld.Models.Region", b =>
                {
                    b.Navigation("Bosses");

                    b.Navigation("Quests");
                });
#pragma warning restore 612, 618
        }
    }
}
