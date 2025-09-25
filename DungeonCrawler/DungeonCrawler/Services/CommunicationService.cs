using System.Diagnostics.CodeAnalysis;

namespace DungeonCrawler.Services;

[ExcludeFromCodeCoverage]
public static class CommunicationService
{
    public static string GetValue(string message)
    {
        Console.WriteLine(message);
        while (true)
        {
            try
            {
                var value = Console.ReadLine();
                if (value == null)
                {
                    continue;
                }
                Console.WriteLine();
                return value;
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong action.");
            }
        }
    }

    public static int GetIndex(string message, int size)
    {
        Console.WriteLine(message);
        while (true)
        {
            try
            {
                var value = Console.ReadLine();
                if (value is null || int.Parse(value) >= size)
                {
                    Console.WriteLine("Wrong action.");
                    continue;
                }
                Console.WriteLine();
                return int.Parse(value);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong action.");
            }
        }
    }

    public static T GetEnumChoice<T>(string message, params T[] allowed) where T : struct, Enum
    {
        Console.WriteLine(message);

        var availableValues = allowed
            .Select(v => Convert.ToInt32(v))
            .ToList();

        while (true)
        {
            var input = Console.ReadLine();

            if (int.TryParse(input, out var intValue))
            {
                if (availableValues.Contains(intValue))
                {
                    Console.WriteLine();
                    return (T)(object)intValue;
                }
            }
            Console.WriteLine("Wrong action. Try again.");
        }
    }
}
