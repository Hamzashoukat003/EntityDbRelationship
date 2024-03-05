using System.Text.Json.Serialization;

namespace EntityDbRelationship.Data.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}
