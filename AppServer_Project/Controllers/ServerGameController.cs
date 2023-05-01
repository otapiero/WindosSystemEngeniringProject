using AppServer_Project.Models;
using AppServer_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServer_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerGameController : ControllerBase
    {
        private readonly int timeUpdate = 10;
        private readonly ServerContext _context;
        private readonly Timer _timer;
        private readonly ILogger<ServerGameController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerGameController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public ServerGameController(ServerContext context, ILogger<ServerGameController> logger)
        {
            _context = context;
            _timer = new Timer(UpdateServers, null, TimeSpan.Zero, TimeSpan.FromSeconds(timeUpdate));
            _logger = logger;
        }
        [HttpGet("ServersList", Name = "GetServersList")]
        public async Task<IActionResult> GetServersList()
        {
            // get from data base one GameServer for each different nameserver
            var servers = _context.Servers.ToList();
            return Ok(servers);
        }
        [HttpGet("ServerStat", Name = "GetServerStat")]
        public async Task<IActionResult> GetServerStat(string serverName ,DateTime? from ,DateTime? until)
        {
            if (from != null && until != null)
            {

                var serverStats = _context.Servers.Where(x => x.ServerName == serverName &&
                (x.DateTime >= from && x.DateTime <= until)).ToList();
                return Ok(serverStats);

            }
            // return an error if the server name is not found
            return NotFound("server name not found");

        }









        // Method to update servers in the local database
        /// <summary>
        /// Updates the servers.
        /// </summary>
        /// <param name="state">The state.</param>
        private async void UpdateServers(object state)
        {
            try
            {
                foreach (var gameName in AvailebleGames.GetGames())
                {
                    var serverName = gameName + " server";
                    var server = _context.Servers.FirstOrDefault(x => x.GameName == gameName);
                    if (server == null)
                    {
                        _context.Servers.Add(await EmulatorManager.CreateGameServer(gameName,serverName));
                    }
                    else
                    {
                        var serverStatLive = await EmulatorManager.CreateGameServerLive(serverName);
                        var gameSeverUpdate = new GameServer
                        {
                            GameName = server.GameName,
                            ServerName = server.ServerName,
                            ServerRegion = server.ServerRegion,
                            PlayerCount = serverStatLive.PlayerCount,
                            DateTime = serverStatLive.DateTime,
                            CpuUsage = serverStatLive.CpuUsage,
                            MemoryUsage = serverStatLive.MemoryUsage,
                            MaxCpu = serverStatLive.MaxCpu,
                            MaxMemory = serverStatLive.MaxMemory,
                            ServerUp = serverStatLive.ServerUp,
                            Temperature = serverStatLive.Temperature           
                        };
                        _context.Servers.Add(gameSeverUpdate);
                    }
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
           
        }


    }
}

