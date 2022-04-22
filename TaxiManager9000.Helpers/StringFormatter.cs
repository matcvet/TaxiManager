namespace TaxiManager9000.Services.Helpers
{
    public static class StringFormatter
    {
        public static void Colorize(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
