using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Security.Cryptography; 
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core with SQL Server
builder.Services.AddDbContext<PlanetsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PlanetsDb")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

// 1. Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PlanetsDbContext>();
    db.Database.Migrate();

    // 2. Seed JSON if database empty OR JSON changed
    await HelpMe.SeedPlanetsAsync(db);
}

// Minimal API endpoint
app.MapGet("/planets", async (PlanetsDbContext db) =>
    await db.Planets.ToListAsync());

app.Run();

