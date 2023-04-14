using AppServer_Project;
using AppServer_Project.BuisnesEntities;
using System.Text.Json;
using System.Text.Json.Serialization;

//Defaultclass(args);
partial class Program
{
    static async Task Main(string[] args)
    {
        //  await TestOfEmulator();
       // Defaultclass(args);
          await TestOfEmulator();
        Console.WriteLine();
    }

    private static async Task TestOfEmulator()
    {
        // Example usage:

        var gameServerNames = new List<string> { "Call Of Duty", "Starcraft" };
        var serversData = await EmulatorManager.GetServersData(gameServerNames);
        Console.WriteLine(serversData);
        // convert the data to a list  of GameServer objects

        var gameServers = EmulatorManager.GetGameServers(serversData);
        // print the data to the console


        foreach (var gameServer in gameServers)
        {
            Console.WriteLine(gameServer.game_name);
            Console.WriteLine(gameServer.server_name);
            Console.WriteLine(gameServer.server_region);
            Console.WriteLine(gameServer.number_of_players);
            Console.WriteLine(gameServer.server_up_down);

            Console.WriteLine();
        }
    }







    static void Defaultclass(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}