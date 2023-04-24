using IGDB;
using IGDB.Models;
using AppServer_Project.BuisnesEntities;
namespace AppServer_Project;

public class IGDBManager
{
    //  function that create a IGDB client
    static public IGDBClient createIGDBClient()
    {
        var client = new IGDBClient(
                     // Found in Twitch Developer portal for your app
                     "vua19ya4ma9e4ukj3lzpb7v0wtry7y",
                     "nbpf4rhy1c82c9og1jcfzlirei3iu1");
        return client;
    }

    //  function that due a query to igdb api
    static public async Task<List<GameData>> QueryFromIGDBAPI()
    {
        var client = createIGDBClient();
        var games = await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields artworks.*,name,summary,id; limit 50; where rating > 95;");
        var listOfGames = new List<GameData>();
        var x = 0;
        foreach (var game in games)
        {

            if (game.Artworks != null)
            {
                var gameEntitie = new GameData
                {
                    Name = game.Name,
                    ArtworkUrl = game.Artworks.Values[0].ImageId,
                    Id = ((int)game.Id),
                    Summary = game.Summary
                };
                listOfGames.Add(gameEntitie);
            }
            else
                x++;

        }

        Console.WriteLine(x);

        return listOfGames;

    }

}