using AppServer_Project.Models;
using AppServer_Project.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppServer_Project;

public class EmulatorManager
{
    static private readonly HttpClient _httpClient = new();

    static public async Task<List<GameServerDataStat>> CreateGameServerStats(string serverName, string dateTimeStart, string dateTimeEnd)
    {
        var requestData = new { server_name = serverName, date_time_start = dateTimeStart, date_time_end = dateTimeEnd };
        var requestContent = new StringContent(JsonSerializer.Serialize(requestData), System.Text.Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("http://localhost:5098/gameserverdatastats"),
            Content = requestContent
        };

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to retrieve game server data stats for server {serverName}.");
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        var gameServerDataStats = JsonSerializer.Deserialize<ServersStatInList>(responseContent)?.GameServerDataStat;
        return gameServerDataStats;
    }
    static public async Task<GameServerDataStat> CreateGameServerLive(string serverName)
    {
        var requestData = new { server_name = serverName };
        var requestContent = new StringContent(JsonSerializer.Serialize(requestData), System.Text.Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("http://localhost:5098/gameserverdatastatlive"),
            Content = requestContent
        };
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to retrieve game server data stats for server {serverName}.");
        }
        var responseContent = await response.Content.ReadAsStringAsync();
        var gameServerDataStats = JsonSerializer.Deserialize<GameServerDataStat>(responseContent);
        return gameServerDataStats;

    }


    static public async Task<GameServer> CreateGameServer(string gameName, string serverName)
    {
        var requestData = new { game_name = gameName, server_name = serverName };
        var requestContent = new StringContent(JsonSerializer.Serialize(requestData), System.Text.Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("http://localhost:5098/gameservers"),
            Content = requestContent
        };

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to create game server {serverName} for game {gameName}.");
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var gameServer = JsonSerializer.Deserialize<GameServer>(responseContent);
        return gameServer;
    }
}