using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// EF Core with SQL Server
builder.Services.AddDbContext<PlanetariumDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 1. Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PlanetariumDbContext>();
    db.Database.Migrate();

    // 2. Seed JSON if database empty OR JSON changed
    await HelpMe.SeedPlanetsAsync(db);
}

// Minimal API endpoint
app.MapGet("/planets", async (PlanetariumDbContext db) =>
    await db.Planets.ToListAsync());

app.Run();

