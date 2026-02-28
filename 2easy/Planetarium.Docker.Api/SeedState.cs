public class SeedState
{
    public int Id { get; set; }
    public string JsonHash { get; set; }

    // 1. ADD THIS: EF Core needs this to "materialize" the entity from the DB
    protected SeedState() { } 

    // 2. KEEP THIS: This is the one you use in your code
    public SeedState(string hash, DateTime date)
    {
        JsonHash = hash;
        DateCreated = date;
    }
    public DateTime DateCreated { get; set; }
}