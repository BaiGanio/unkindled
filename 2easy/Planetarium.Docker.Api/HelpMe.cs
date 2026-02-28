using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

public static class HelpMe
{
    public static async Task SeedPlanetsAsync(PlanetariumDbContext db)
    {
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "planets.json");
        var json = await File.ReadAllTextAsync(jsonPath);

        // Compute hash of JSON
        using var sha = SHA256.Create();
        var hash = Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(json)));

        // Get last seed state
        var state = await db.SeedState.FirstOrDefaultAsync();

        bool shouldSeed = state == null || state.JsonHash != hash;

        if (!shouldSeed)
            return;

        // Parse JSON
        var planets = JsonSerializer.Deserialize<List<Planet>>(json)!;

        // Clear table and reseed
        db.Planets.RemoveRange(db.Planets);
        await db.SaveChangesAsync();

        await db.Planets.AddRangeAsync(planets);

        // Update seed state
        if (state == null)
            db.SeedState.Add(new SeedState(hash, DateTime.Now));
        else
            state.JsonHash = hash;
            state.DateCreated = DateTime.Now;

        await db.SaveChangesAsync();
    }
}


