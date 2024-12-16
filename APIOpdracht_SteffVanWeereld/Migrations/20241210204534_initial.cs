using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIOpdracht_SteffVanWeereld.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capital = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bosses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CombatLevel = table.Column<int>(type: "int", nullable: false),
                    QuestId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    MaxHit = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExamineText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bosses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bosses_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestPoints = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lenght = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Difficulty = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Series = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BossId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quests_Bosses_BossId",
                        column: x => x.BossId,
                        principalTable: "Bosses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quests_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Capital", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Falador", "https://oldschool.runescape.wiki/w/Asgarnia#/media/File:Asgarnia_map.png", "Asgarnia" },
                    { 2, "Rellekka", "https://oldschool.runescape.wiki/w/Fremennik_Province#/media/File:Fremennik_Province_map.png", "Fremmennik" },
                    { 3, "Kourend Castle", "https://oldschool.runescape.wiki/w/Great_Kourend#/media/File:Great_Kourend_map.png", "Great Kourend" },
                    { 4, "Ardougne", "https://oldschool.runescape.wiki/w/Kandarin#/media/File:Kandarin_map.png", "Kandarin" },
                    { 5, "Varrock", "https://oldschool.runescape.wiki/w/Misthalin#/media/File:Misthalin_map.png", "Misthalin" },
                    { 6, "Prifddinas", "https://oldschool.runescape.wiki/w/Prifddinas#/media/File:Prifddinas_entrance_artwork.jpg", "Tirannwn" },
                    { 7, "Darkmeyer", "https://oldschool.runescape.wiki/w/Morytania#/media/File:Morytania_map.png", "Morytania" }
                });

            migrationBuilder.InsertData(
                table: "Bosses",
                columns: new[] { "Id", "CombatLevel", "ExamineText", "Image", "MaxHit", "Name", "QuestId", "RegionId" },
                values: new object[,]
                {
                    { 1, 732, "This won't be fun.", "https://oldschool.runescape.wiki/w/Vorkath#/media/File:Vorkath.png", 80, "Vorkath", 1, 2 },
                    { 2, 494, "The brightest light casts the darkest shadow.", "https://oldschool.runescape.wiki/w/Seren#/media/File:Seren.png", 73, "Fragment of Seren", 2, 6 },
                    { 3, 459, "Formally Ascertes Hallow, now an evil vampyre.", "https://oldschool.runescape.wiki/w/Vanstrom_Klause#/media/File:Vanstrom_Klause_(vampyre).png", 24, "Vanstrom Klause", 3, 7 },
                    { 4, 190, "It's trying to mash you flat! Less examine, more fight", "https://oldschool.runescape.wiki/w/Barrelchest#/media/File:Barrelchest.png", 35, "Barrelchest", 4, 7 },
                    { 5, 122, "An impressive looking troll.", "https://oldschool.runescape.wiki/w/Ice_Troll_King#/media/File:Ice_Troll_King.png", 21, "Ice Troll King", 5, 2 },
                    { 6, 83, "Roar! A dragon!", "https://oldschool.runescape.wiki/w/Elvarg#/media/File:Elvarg.png", 8, "Elvarg", 6, 5 },
                    { 7, 239, "If evil had a look, this would be it.", "https://oldschool.runescape.wiki/w/Xamphur#/media/File:Xamphur_(monster).png", 18, "Xamphur", 7, 3 },
                    { 8, 62, "A child of aquatic evil.", "https://oldschool.runescape.wiki/w/Slug_Prince#/media/File:Slug_Prince.png", 6, "Slug Prince", 8, 1 },
                    { 9, 13, "Leader of the Hazeel Cult.", "https://oldschool.runescape.wiki/w/Alomone#/media/File:Alomone.png", 5, "Alomone", 9, 4 }
                });

            migrationBuilder.InsertData(
                table: "Quests",
                columns: new[] { "Id", "BossId", "Difficulty", "Image", "Lenght", "Name", "QuestPoints", "RegionId", "Series" },
                values: new object[,]
                {
                    { 1, 1, "Grandmaster", "https://oldschool.runescape.wiki/images/Dragon_Slayer_II_reward_scroll.png?55a92", "Very Long", "Dragonslayer 2", 5, 2, "Dragonkin" },
                    { 2, 2, "Grandmaster", "https://oldschool.runescape.wiki/images/Song_of_the_Elves_reward_scroll.png?85a1f", "Very Long", "Song of the elves", 4, 6, "Elfs" },
                    { 3, 3, "Master", "https://oldschool.runescape.wiki/images/Sins_of_the_Father_reward_scroll.png?6c96f", "Long", "Sins of the father", 2, 7, "Myreque" },
                    { 4, 4, "Experienced", "https://oldschool.runescape.wiki/images/The_Great_Brain_Robbery_reward_scroll.png?e9e6c", "Medium", "Great brain robbery", 2, 7, "Pirate" },
                    { 5, 5, "Experienced", "https://oldschool.runescape.wiki/images/The_Fremennik_Isles_reward_scroll.png?805aa", "Medium", "The Fremennik Isles", 1, 2, "Fremmennik" },
                    { 6, 6, "Experienced", "https://oldschool.runescape.wiki/images/Dragon_Slayer_reward_scroll.png?5517f", "Medium", "Dragonslayer 1", 2, 5, "Dragonkin" },
                    { 7, 7, "Experienced", "https://oldschool.runescape.wiki/images/A_Kingdom_Divided_reward_scroll.png?5a404", "Long", "A kingdom divided", 2, 3, "Great Kourend" },
                    { 8, 8, "Intermediate", "https://oldschool.runescape.wiki/images/The_Slug_Menace_reward_scroll.png?8291b", "Medium", "The Slug Menace", 2, 1, "Temple knight" },
                    { 9, 9, "Novice", "https://oldschool.runescape.wiki/w/File:Hazeel_Cult_reward_scroll.png", "Very Short", "Hazeel cult", 1, 4, "Mahjarrat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bosses_RegionId",
                table: "Bosses",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_BossId",
                table: "Quests",
                column: "BossId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quests_RegionId",
                table: "Quests",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Bosses");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
