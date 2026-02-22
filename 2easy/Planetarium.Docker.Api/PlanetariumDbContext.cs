using Microsoft.EntityFrameworkCore;

public class PlanetariumDbContext : DbContext
{
    public PlanetariumDbContext(DbContextOptions<PlanetariumDbContext> options)
        : base(options) { }

    public DbSet<Planet> Planets => Set<Planet>();
    public DbSet<SeedState> SeedState => Set<SeedState>();
}
