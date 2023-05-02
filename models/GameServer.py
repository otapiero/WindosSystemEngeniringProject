class GameServer:
    def __init__ ( self, game_name: str, player_count: int, server_name: str, server_region: str,
                   date_time: str, cpu_usage: float, memory_usage: float, server_up: bool, temperature: int,
                   max_score: int, player_time_min: int ):
        self.GameName = game_name
        self.PlayerCount = player_count
        self.ServerName = server_name
        self.ServerRegion = server_region
        self.DateTime = date_time
        self.CpuUsage = cpu_usage
        self.MemoryUsage = memory_usage
        self.ServerUp = server_up
        self.Temperature = temperature
        self.MaxScore = max_score
        self.PlayerTimeMin = player_time_min

    def to_dict ( self ) -> dict:
        return {
            'GameName': self.GameName,
            'PlayerCount': self.PlayerCount,
            'ServerName': self.ServerName,
            'ServerRegion': self.ServerRegion,
            'DateTime': self.DateTime,
            'CpuUsage': self.CpuUsage,
            'MemoryUsage': self.MemoryUsage,
            'ServerUp': self.ServerUp,
            'Temperature': self.Temperature,
            'MaxScore': self.MaxScore,
            'PlayerTimeMin': self.PlayerTimeMin
        }

    @classmethod
    def from_dict ( cls, data: dict ) -> 'GameServer':
        return cls(
            data['GameName'],
            data['PlayerCount'],
            data['ServerName'],
            data['ServerRegion'],
            data['DateTime'],
            data['CpuUsage'],
            data['MemoryUsage'],
            data['ServerUp'],
            data['Temperature'],
            data['MaxScore'],
            data['PlayerTimeMin']
        )
