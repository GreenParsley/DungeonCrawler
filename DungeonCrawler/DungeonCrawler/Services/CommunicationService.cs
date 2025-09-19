using DungeonCrawler.Enums;
using System;
using System.Net.NetworkInformation;

namespace DungeonCrawler.Services;

public class CommunicationService
{
    public static string GetValue(string message)
    {
        Console.WriteLine(message);
        while (true)
        {
            try
            {
                var value = Console.ReadLine();
                return value;
            }
            catch (Exception)
            {

                Console.WriteLine("Wrong action.");
            }
        }
    }

    public static string GetValue(string message, params string[] availableValues)
    {
        Console.WriteLine(message);
        while (true)
        {
            try
            {
                var value = Console.ReadLine();
                if (!availableValues.Any(x => x.Equals(value!.ToLower(), StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Wrong action.");
                    continue;
                }
                return value!;
            }
            catch (Exception)
            {

                Console.WriteLine("Wrong action.");
            }
        }
    }

    public static (bool HasQuit, int Index) GetIndex(int size)
    {
        while (true)
        {
            try
            {
                var value = Console.ReadLine();
                if (value.ToLower() == "q")
                {
                    return (true, -1);
                }
                else if (int.Parse(value) >= size)
                {
                    Console.WriteLine("Wrong action.");
                    continue;
                }
                return (false, int.Parse(value));
            }
            catch (Exception)
            {

                Console.WriteLine("Wrong action.");
            }
        }
    }
}
