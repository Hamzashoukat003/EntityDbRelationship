namespace EntityDbRelationship.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BackpackId { get; set; }
        public Backpack Backpack { get; set; }
    }
}
