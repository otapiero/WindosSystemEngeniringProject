using AppServer_Project.Models;

namespace AppServer_Project.Models
{
    public class GameServerDataStat
    {
        public string ServerName { get; set; }
        public DateTime DateTime { get; set; }
        // cpu usage
        public float CpuUsage { get; set; }
        public int PlayerCount { get; set; }
        // memory usage
        public float MemoryUsage { get; set; }
        // max memory
        public float MaxMemory { get; set; }
        // max cpu
        public float MaxCpu { get; set; }
        public bool ServerUp { get; set; }
        public int Temperature { get; set; }
    }
    public class ServersStatInList
    {
        public List<GameServerDataStat> GameServerDataStat { get; set; }
    }
}
