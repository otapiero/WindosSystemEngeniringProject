using AppServer_Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerGameController : ControllerBase
    {
        private readonly ServerContext _context;
        private readonly Timer _timer;
        private readonly ILogger<ServerGameController> _logger;

        public ServerGameController(ServerContext context, ILogger<ServerGameController> logger)
        {
            _context = context;
            _timer = new Timer(UpdateServers, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetServers()
        {
            var servers = _context.Servers.ToList();
            return Ok(servers);
        }


        // Method to update servers in the local database
        private void UpdateServers(object state)
        {
            // Retrieve servers from the local database
            var servers = _context.Servers.ToList();
            // Update server properties (e.g. status) as needed
            foreach (var server in servers)
            {
                // Update server properties as needed
                server.date = DateTime.Now.ToString();
            }
            // Save changes to the local database
            _context.SaveChanges();
        }


    }
}

