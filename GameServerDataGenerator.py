from datetime import datetime, timedelta
import random

from models.GameServer import GameServer
from models.GameServerDataStat import GameServerDataStat


class GameServerDataGenerator:
    @staticmethod
    def generate_game_server ( game_name: str, server_name: str ):
        player_count = random.randint(0, 100000)
        server_region = random.choice(['US East', 'US West', 'EU', 'Asia', 'Australia'])
        date_time = datetime.now().isoformat()
        cpu_usage = round(random.uniform(0, 100), 2)
        memory_usage = round(random.uniform(0, 100), 2)
        max_score = random.randint(0, 100)
        player_time_min = random.randint(0, 100)

        server_up = random.choice([True, False])
        temperature = random.randint(0, 100)
        if not server_up:
            player_count = 0

        game_server = GameServer(game_name=game_name,  player_count=player_count, server_name=server_name,
                                 server_region=server_region, date_time=date_time, cpu_usage=cpu_usage,
                                 memory_usage=memory_usage, server_up=server_up, temperature=temperature,
                                 max_score=max_score, player_time_min=player_time_min)

        return game_server

    @staticmethod
    def generate_game_server_stats ( server_name: str, date_time_start: str, date_time_end: str ):

        List = []
        date_time_start = datetime.strptime(date_time_start, '%Y-%m-%d %H:%M:%S')
        date_time_end = datetime.strptime(date_time_end, '%Y-%m-%d %H:%M:%S')
        delta = date_time_end - date_time_start
        for i in range(delta.days + 1):
            date = date_time_start + timedelta(days=i)
            for j in range(24):
                server_up = random.choice([True, False])
                hour = j if j >= 10 else f"0{j}"
                game_server_stat = GameServerDataStat(
                        server_name=server_name,
                        date_time=datetime.strptime(f"{date.date()} {hour}", '%Y-%m-%d %H').isoformat(),
                        cpu_usage=round(random.uniform(0, 100), 2),
                        memory_usage=round(random.uniform(0, 100), 2),
                        server_up=server_up,
                        temperature=random.randint(0, 100),
                        player_count= random.randint(0, 100000) if server_up else 0,
                        max_score=random.randint(0, 100),
                        player_time_min=random.randint(0, 100),
                )
                List.append(game_server_stat)
        return List

    @staticmethod
    def generate_game_server_stat_live(server_name: str):
        date_time = datetime.now().isoformat()
        cpu_usage = round(random.uniform(0, 100), 2)
        memory_usage = round(random.uniform(0, 100), 2)

        server_up = random.choice([True, False])
        temperature = random.randint(0, 100)
        player_count = random.randint(0, 1000) if server_up else 0
        game_server_stat = GameServerDataStat(
            server_name=server_name,
            date_time=date_time,
            cpu_usage=cpu_usage,
            memory_usage=memory_usage,
            server_up=server_up,
            temperature=temperature,
            player_count=player_count,
            max_score=random.randint(0, 100),
            player_time_min=random.randint(0, 100))
        return game_server_stat
