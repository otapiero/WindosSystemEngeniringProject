using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using global::AppServer_Project.BuisnesEntities;
using Microsoft.Extensions.Logging;

namespace AppServer_Project.Controllers;

[ApiController]
[Route("[controller]")]
    public class GameEntitieController : ControllerBase
{
    

    private readonly ILogger<GameEntitieController> _logger;

    public GameEntitieController(ILogger<GameEntitieController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetGameEntities")]
    public async Task<IActionResult> Get()
    {
        return Ok(await IGDBManager.QueryFromIGDBAPI());
    }
}


