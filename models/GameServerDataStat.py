import datetime


class GameServerDataStat:
    def __init__(self, date_time: str, cpu_usage: float, player_count: int, memory_usage: float,
                 max_memory: float, max_cpu: float, server_up: bool, temperature: int):
        self.DateTime = date_time
        self.CpuUsage = cpu_usage
        self.PlayerCount = player_count
        self.MemoryUsage = memory_usage
        self.MaxMemory = max_memory
        self.MaxCpu = max_cpu
        self.ServerUp = server_up
        self.Temperature = temperature

    def to_dict(self) -> dict:
        return {
            'DateTime': self.DateTime,
            'CpuUsage': self.CpuUsage,
            'PlayerCount': self.PlayerCount,
            'MemoryUsage': self.MemoryUsage,
            'MaxMemory': self.MaxMemory,
            'MaxCpu': self.MaxCpu,
            'ServerUp': self.ServerUp,
            'Temperature': self.Temperature
        }

    @classmethod
    def from_dict(cls, data: dict) -> 'GameServerDataStat':
        return cls(
            data['DateTime'],
            data['CpuUsage'],
            data['PlayerCount'],
            data['MemoryUsage'],
            data['MaxMemory'],
            data['MaxCpu'],
            data['ServerUp'],
            data['Temperature']
        )
