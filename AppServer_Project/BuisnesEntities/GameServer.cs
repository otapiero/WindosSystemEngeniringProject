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
        public string GameName { get; set; }
        public string ServerName { get; set; }
        public string ServerRegion { get; set; }
        public int NumberOfPlayers { get; set; }
        public bool ServerUpDown { get; set; }
    }
}
