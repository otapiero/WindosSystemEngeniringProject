using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppServer_Project.Models;

public class GameServer
{
    public string GameName { get; set; }

    public int PlayerCount { get; set; }
    [Key]
    [Column(Order = 0)]
    public string ServerName { get; set; }

    public string ServerRegion { get; set; }
    [Key]
    [Column(Order = 1)]
    public DateTime DateTime { get; set; }
    public float CpuUsage { get; set; }
    public float MemoryUsage { get; set; }
    public bool ServerUp { get; set; }
    public int Temperature { get; set; }
    public int MaxScore { get; set; }
    public int PlayerTimeMin { get; set; }
}
class ServerList
{
    public List<GameServer> game_servers { get; set; }
}
