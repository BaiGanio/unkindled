public static class HelpMe
{
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