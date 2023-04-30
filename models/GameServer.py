import datetime


class GameServer:
    def __init__(self, game_name: str, player_count: int, server_name: str, server_region: str,
                 date_time: str, cpu_usage: float, memory_usage: float, max_memory: float,
                 max_cpu: float, server_up: bool, temperature: int):
        self.GameName = game_name
        self.PlayerCount = player_count
        self.ServerName = server_name
        self.ServerRegion = server_region
        self.DateTime = date_time
        self.CpuUsage = cpu_usage
        self.MemoryUsage = memory_usage
        self.MaxMemory = max_memory
        self.MaxCpu = max_cpu
        self.ServerUp = server_up
        self.Temperature = temperature

    def to_dict(self) -> dict:
        return {
            'GameName': self.GameName,
            'PlayerCount': self.PlayerCount,
            'ServerName': self.ServerName,
            'ServerRegion': self.ServerRegion,
            'DateTime': self.DateTime,
            'CpuUsage': self.CpuUsage,
            'MemoryUsage': self.MemoryUsage,
            'MaxMemory': self.MaxMemory,
            'MaxCpu': self.MaxCpu,
            'ServerUp': self.ServerUp,
            'Temperature': self.Temperature
        }

    @classmethod
    def from_dict(cls, data: dict) -> 'GameServer':
        return cls(
            data['GameName'],
            data['PlayerCount'],
            data['ServerName'],
            data['ServerRegion'],
            data['DateTime'],
            data['CpuUsage'],
            data['MemoryUsage'],
            data['MaxMemory'],
            data['MaxCpu'],
            data['ServerUp'],
            data['Temperature']
        )
