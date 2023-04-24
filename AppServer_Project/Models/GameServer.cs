using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppServer_Project.BuisnesEntities
{
    /*
   define a class to store data on a game server

   the class should have the following attributes:
  - GameName (string)
  - ServerName (string)
  - ServerRegion (string)
  - PlayerCount (int)
  - server_up_down (boolean)

   */
    public class GameServer
    {
        public string GameName { get; set; }

        public int PlayerCount { get; set; }
        [Key]
        public string ServerName { get; set; }

        public string ServerRegion { get; set; }

        public DateTime DateTime { get; set; }
        // cpu usage
        public float CpuUsage { get; set; }
        // memory usage
        public float MemoryUsage { get; set; }
        // max memory
        public float MaxMemory { get; set; }

        // max cpu
        public float MaxCpu { get; set; }

        public bool ServerUp { get; set; }

        public int Temperature { get; set; }
    }

    public class ServerList
    {
        public List<GameServer> game_servers { get; set; }
    }
}
