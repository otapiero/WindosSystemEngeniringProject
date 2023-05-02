class GameServerDataStat:
    def __init__(self, server_name: str , date_time: str, cpu_usage: float, player_count: int, memory_usage: float,
                 server_up: bool, temperature: int , max_score: int, player_time_min: int):
        self.ServerName = server_name
        self.DateTime = date_time
        self.CpuUsage = cpu_usage
        self.PlayerCount = player_count
        self.MemoryUsage = memory_usage
        self.ServerUp = server_up
        self.Temperature = temperature
        self.MaxScore = max_score
        self.PlayerTimeMin = player_time_min

    def to_dict(self) -> dict:
        return {
            'ServerName': self.ServerName,
            'DateTime': self.DateTime,
            'CpuUsage': self.CpuUsage,
            'PlayerCount': self.PlayerCount,
            'MemoryUsage': self.MemoryUsage,
            'ServerUp': self.ServerUp,
            'Temperature': self.Temperature,
            'MaxScore': self.MaxScore,
            'PlayerTimeMin': self.PlayerTimeMin

        }

    @classmethod
    def from_dict(cls, data: dict) -> 'GameServerDataStat':
        return cls(
            data['ServerName'],
            data['DateTime'],
            data['CpuUsage'],
            data['PlayerCount'],
            data['MemoryUsage'],
            data['ServerUp'],
            data['Temperature'],
            data['MaxScore'],
            data['PlayerTimeMin']
        )
