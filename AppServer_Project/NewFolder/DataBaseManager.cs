namespace AppServer_Project.NewFolder;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServer_Project.Data;
using AppServer_Project.Models;
using Microsoft.EntityFrameworkCore;


public class DataBaseManager
{
    static ServersContext _context =new ServersContext();

  

    public async Task<bool> AddServer(GameServer server)
    {
        if (_context.Servers.Any(s => s.ServerName == server.ServerName))
        {
            return false;
        }
        while (_context.Database.CurrentTransaction != null)
        {
            await Task.Delay(100);
        }
        _context.Servers.Add(server);
        while (_context.Database.CurrentTransaction != null)
        {
            await Task.Delay(100);
        }
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<int> AddServers(List<GameServer> servers)
    {
        var count = 0;
        foreach (var server in servers)
        {
            if (_context.Servers.Any(s => s.ServerName == server.ServerName && s.DateTime == server.DateTime))
            {
                continue;
            }
            while (_context.Database.CurrentTransaction != null)
            {
                await Task.Delay(100); 
            }
            _context.Servers.Add(server);
            count++;
        }
        while (_context.Database.CurrentTransaction != null)
        {
            await Task.Delay(100); 
        }
        await _context.SaveChangesAsync();
        return count;
    }
    public async Task<List<GameServer>> GetServersList()
    {
        while (_context.Database.CurrentTransaction != null)
        {
            await Task.Delay(100);
        }
        // return one server from each server name
        var servers = await _context.Servers
            .GroupBy(s => s.ServerName)
            .Select(s => s.FirstOrDefault())
            .ToListAsync();
        return servers;

    }

    public async Task<GameServer?> GetServer(string gameName, string serverName)
    {
        var server = await _context.Servers.FirstOrDefaultAsync(s => s.ServerName == serverName);

        if (server == null)
        {
            var newGameServer = await EmulatorManager.CreateGameServer(gameName, serverName);
            server = new GameServer
            {
                GameName = newGameServer?.GameName ?? "",
                PlayerCount = newGameServer?.PlayerCount ?? 0,
                ServerName = serverName,
                ServerRegion = newGameServer?.ServerRegion ?? "",
                DateTime = newGameServer?.DateTime ?? DateTime.Now,
                CpuUsage = newGameServer?.CpuUsage ?? 0,
                MemoryUsage = newGameServer?.MemoryUsage ?? 0,
                MaxMemory = newGameServer?.MaxMemory ?? 0,
                MaxCpu = newGameServer?.MaxCpu ?? 0,
                ServerUp = newGameServer?.ServerUp ?? false,
                Temperature = newGameServer?.Temperature ?? 0
            };
            await AddServer(server);
        }

        return server;
    }

    public async Task<List<GameServerDataStat>> GetServersByDate(string serverName, DateTime? from = null, DateTime? until = null)
    {
        try
        {

            while (_context.Database.CurrentTransaction != null)
            {
                await Task.Delay(100);
            }
            while (_context.Database.CurrentTransaction != null)
            {
                await Task.Delay(100);
            }
            var servers = await _context.Servers
                .Where(s => s.ServerName == serverName && s.DateTime >= from && s.DateTime <= until)
                .ToListAsync();
            List<GameServerDataStat> serverStats = new();

            // Check if there are any missing servers
            var hours = (int)(until - from)?.TotalHours;
            if (servers.Count != hours+1)
            {
                // add to database the missing servers
                serverStats.AddRange(await EmulatorManager.CreateGameServerStats(serverName,
                   from?.ToString("yyyy-MM-dd HH:mm:ss"), until?.ToString("yyyy-MM-dd HH:mm:ss")));
                var listOfServers = new List<GameServer>();
                while (_context.Database.CurrentTransaction != null)
                {
                    await Task.Delay(100);
                }
                var defaultServer = _context.Servers.FirstOrDefault(s => s.ServerName == serverName);
                if (defaultServer != null)
                {
                    foreach (var server in serverStats)
                    {
                        while (_context.Database.CurrentTransaction != null)
                        {
                            await Task.Delay(100);
                        }
                        if (!_context.Servers.Any(s => s.ServerName == serverName && s.DateTime == server.DateTime))
                            listOfServers.Add(new GameServer
                            {
                                GameName = defaultServer.GameName,
                                PlayerCount = server.PlayerCount,
                                ServerName = serverName,
                                ServerRegion = defaultServer.ServerRegion,
                                DateTime = server.DateTime,
                                CpuUsage = server.CpuUsage,
                                MemoryUsage = server.MemoryUsage,
                                MaxMemory = server.MaxMemory,
                                MaxCpu = server.MaxCpu,
                                ServerUp = server.ServerUp,
                                Temperature = server.Temperature
                            });
                    }
                    await AddServers(listOfServers);
                    while (_context.Database.CurrentTransaction != null)
                    {
                        await Task.Delay(100); 
                    }
                    servers = await _context.Servers
                        .Where(s => s.ServerName == serverName && s.DateTime >= from && s.DateTime <= until)
                        .ToListAsync();
                }
                else
                    throw new ArgumentException("no such Server Name in the data base");
            }
            serverStats = servers.Select(x => new GameServerDataStat
            {
                PlayerCount = x.PlayerCount,
                ServerName = x.ServerName,
                DateTime = x.DateTime,
                CpuUsage = x.CpuUsage,
                MemoryUsage = x.MemoryUsage,
                MaxMemory = x.MaxMemory,
                MaxCpu = x.MaxCpu,
                ServerUp = x.ServerUp,
                Temperature = x.Temperature
            }).ToList();
            return serverStats;
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error at DataBaseManager.GetServersByDate: " + e.Message);
            Console.ResetColor();
            Console.WriteLine();
            return new List<GameServerDataStat>();
        }
    }

}





