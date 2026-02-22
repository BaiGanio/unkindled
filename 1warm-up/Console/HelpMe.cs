
using System.Text.Json;
public static class HelpMe
{
    public static List<Planet> ReadPlanets()
    {
        string json = File.ReadAllText("planets.json");
        return JsonSerializer.Deserialize<List<Planet>>(json);
    }

    public static void TextColorizer(string text)
    {
        var colors = Enum.GetValues(typeof(ConsoleColor));
        var color = (ConsoleColor)colors.GetValue(Random.Shared.Next(colors.Length));   
        Console.ForegroundColor = color;
        Console.WriteLine($"{text}");
        // Console.WriteLine($"{text} -> {color}");
        Console.ResetColor();
    }
}