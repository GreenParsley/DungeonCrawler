using DungeonCrawler;
using DungeonCrawler.Services;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawler.Utils;
using DungeonCrawler.Utils.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using var host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((builder, services) =>
        {
            services.AddSingleton<App>();
            services.AddScoped<IItemFactory, ItemFactory>();
            services.AddTransient<IMonsterFactory, MonsterFactory>();
            services.AddScoped<IRoomFactory, RoomFactory>();
            services.AddScoped<IBattleService, BattleService>();
            services.AddSingleton<IDungeonMapService, DungeonMapService>();
            services.AddSingleton<IMovementService, MovementService>();
            services.AddSingleton<IGameService, GameService>();
            services.AddSingleton<ISaveService, SaveService>();
            services.AddSingleton<IDialogService, DialogService>();
        });
}