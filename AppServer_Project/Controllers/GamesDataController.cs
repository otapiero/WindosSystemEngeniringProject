using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using global::AppServer_Project.Models;
using Microsoft.Extensions.Logging;

namespace AppServer_Project.Controllers;

[ApiController]
[Route("[controller]")]
    public class GamesDataController : ControllerBase
{
    

    private readonly ILogger<GamesDataController> _logger;

    public GamesDataController(ILogger<GamesDataController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetGameData")]
    public async Task<IActionResult> GetGamesData()
    {
        var gamesData = await IGDBManager.GetGamesFromApi();
        return Ok(gamesData);
    }
}


