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
    private static readonly string[] Summaries = new[]
    {
        "Adventure", "Action", "RPG", "Strategy", "Simulation", "Sports", "Horror", "Platformer", "Puzzle", "Fighting"
    };

    private readonly ILogger<GameEntitieController> _logger;

    public GameEntitieController(ILogger<GameEntitieController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetGameEntities")]
    public IEnumerable<GameEntitie> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new GameEntitie
        {
            Id = index,
            Name = "Example Game " + index,
            ArtworkUrl = "abc" + index,
            Summary = "This is an example game of the " + Summaries[(index - 1) % 10] + " genre."
        })
        .ToArray();
    }
}


