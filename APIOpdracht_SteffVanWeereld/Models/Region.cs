using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIOpdracht_SteffVanWeereld.Models
{
    public class Region
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "Capital name cannot exceed 100 characters.")]
        public string Capital { get; set; } = string.Empty;
        public int[]? BossIds { get; set; }
        public int[]? QuestIds { get; set; }
        [JsonIgnore]
        public string Image { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Boss> Bosses { get; set; } = new List<Boss>();
        [JsonIgnore]
        public ICollection<Quest> Quests { get; set; } = new List<Quest>();
    }
}
