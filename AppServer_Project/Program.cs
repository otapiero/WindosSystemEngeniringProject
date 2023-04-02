using AppServer_Project;

//NewMethod(args);
partial class Program
{
    static async Task Main(string[] args)
    {
        // Example usage:
        
        var gameServerNames = new List<string> { "Call Of Duty", "Starcraft" };
        var serversData = await EmulatorManager.GetServersData(gameServerNames);
        Console.WriteLine(serversData);
    }
    







    static void NewMethod(string[] args)
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