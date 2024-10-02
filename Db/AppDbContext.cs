using Microsoft.EntityFrameworkCore;

namespace SevenShipsServer.Db
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Ship> Ships => Set<Ship>();

        public async Task InitializeDatabaseAsync()
        {
            await Database.EnsureCreatedAsync();
        }
    }
}