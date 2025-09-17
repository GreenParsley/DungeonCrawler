namespace DungeonCrawler.Services;

public static class DrawService
{
    public static int GetRandomIndex(int count)
    {
        Random random = new();
        var index = random.Next(0, count);
        return index;
    }
}
