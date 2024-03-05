using EntityDbRelationship.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityDbRelationship.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options
            ) :base(options) { }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> BackpackSet { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Faction> Factions { get; set; }
    }
}
