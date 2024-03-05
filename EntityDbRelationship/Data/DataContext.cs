using EntityDbRelationship.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityDbRelationship.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options
            ) :base(options) { }
        public DbSet<Character> CharacterSet { get; set; }
        public DbSet<Backpack> BackpackSet { get; set; }

    }
}
