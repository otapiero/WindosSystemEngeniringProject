using AppServer_Project;
using AppServer_Project.Data;
using AppServer_Project.Models;
using AppServer_Project.SourcesManegers;
using System.Text.Json;
using System.Text.Json.Serialization;

//RunApp(args);
partial class Program
{
    static async Task Main(string[] args)
    {
        RunApp(args);
        // await IGDBManager.GetGamesFromApi();
        
    }


    private static async Task TestOfEmulator()
    {
        // Example usage:

        var serverData = await EmulatorManager.CreateGameServer(gameName: "game1", serverName: "server1");
        Console.WriteLine(serverData);
        // convert the data to a list  of GameServer objects
        var serversStatData = await EmulatorManager.CreateGameServerStats(serverName: "server1", dateTimeStart: "2021-05-01 00:00:00", dateTimeEnd: "2021-05-01 23:59:59");
        Console.WriteLine(serversStatData);
        var serverStatData = await EmulatorManager.CreateGameServerLive(serverName: "server1");
        Console.WriteLine(serverStatData);


        // print the data to the console
        Console.WriteLine();


       
    }







    static void RunApp(string[] args)
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