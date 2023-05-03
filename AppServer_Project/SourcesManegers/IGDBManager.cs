using IGDB;
using IGDB.Models;
using AppServer_Project.Models;
using AppServer_Project.Tools;

namespace AppServer_Project;

public class IGDBManager
{
    //  function that create a IGDB client
    /// <summary>
    /// creates the i g d b client.
    /// </summary>
    /// <returns>An IGDBClient.</returns>
    static public IGDBClient createIGDBClient()
    {
        var client = new IGDBClient(
                     // Found in Twitch Developer portal for your app
                     "vua19ya4ma9e4ukj3lzpb7v0wtry7y",
                     "nbpf4rhy1c82c9og1jcfzlirei3iu1");
        return client;
    }

    //  function that due a query to igdb api
    static public async Task<List<GameData>> GetGamesFromApi()
    {
        try
        {
            var client = createIGDBClient();
            var gamesAvailableNamesAsString = $"({string.Join(",", AvailebleGames.GetGames().Select(g => $"\"{g}\""))})";
           
            var gamesFromIGDB = await client.QueryAsync<Game>(IGDBClient.Endpoints.Games,
                query: $"fields artworks.*,name,summary,id; where name ={gamesAvailableNamesAsString};");
            var listOfGames = new List<GameData>();
            foreach (var game in gamesFromIGDB)
            {

                if (game.Artworks != null)
                {
                    var gameEntity = new GameData
                    {
                        Name = game.Name,
                        ArtworkUrl = game.Artworks.Values[0].ImageId,
                        Id = (int)game.Id,
                        Summary = game.Summary
                    };
                    listOfGames.Add(gameEntity);
                }
            }

            return listOfGames;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new List<GameData>();
        }
    }

}
