using System.Text.Json.Serialization;

namespace AppServer_Project.BuisnesEntities
{
    /*
   define a class to store data on a game server

   the class should have the following attributes:
  - game_name (string)
  - server_name (string)
  - server_region (string)
  - number_of_players (int)
  - server_up_down (boolean)

   */
    public class GameServer
    {
        public string game_name { get; set; }
        public int number_of_players { get; set; }
        public List<object> results { get; set; }
        public string server_name { get; set; }
        public string server_region { get; set; }
        public string server_up_down { get; set; }
    }

    public class ServerList
    {
        public List<GameServer> game_servers { get; set; }
    }
}
