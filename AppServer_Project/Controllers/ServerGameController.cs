using AppServer_Project.Models;
using AppServer_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServer_Project.SourcesManegers;
using AppServer_Project.Tools;

namespace AppServer_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerGameController : ControllerBase
    {
        private readonly int timeUpdate = 1000;
        private readonly DataBaseManager dbManager;
        private readonly Timer _timer;
        private readonly ILogger<ServerGameController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerGameController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public ServerGameController(ILogger<ServerGameController> logger)
        {
            dbManager = new();
            _timer = new Timer(UpdateServers, null, TimeSpan.Zero, TimeSpan.FromSeconds(timeUpdate));
            _logger = logger;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ServerGameController is up");
            Console.ResetColor();
            Console.WriteLine();
        }
        [HttpGet("ServersList", Name = "GetServer")]
        public async Task<IActionResult> GetServersList()
        {
            var serversList = await dbManager.GetServersList();
            return Ok(serversList);
        }
        [HttpGet("ServerStat", Name = "GetServerStat")]
        public async Task<IActionResult> GetServerStat(string serverName, DateTime? from, DateTime? until)
        {
            if (from != null && until != null)
            {

                var serverStats = await dbManager.GetServersByDate(serverName, from, until);
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
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("UpdateServers");
            Console.ResetColor();
            Console.WriteLine();
            try
            {
                foreach (var gameName in AvailebleGames.GetGames())
                {
                    var serverName = gameName + " server";
                    var server = await dbManager.GetServer(gameName, serverName);
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
                      
                        ServerUp = serverStatLive.ServerUp,
                        Temperature = serverStatLive.Temperature,
                        MaxScore = serverStatLive.MaxScore,
                        PlayerTimeMin = serverStatLive.PlayerTimeMin
                    };
                    await dbManager.AddServer(gameSeverUpdate);
                    // TODO: enter gameSeverUpdate to data base
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


    }
}