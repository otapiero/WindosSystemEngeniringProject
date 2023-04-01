'''
define a class that represents a game server for an emulator of a server for a game.
the class should have the following attributes:
    - game_name (string)
    - server_name (string)
    - server_region (string)
    - number_of_players (int)
    - server_up_down (boolean)

'''
class GameServer:
    def __init__(self, game_name, server_name, server_region, number_of_players, server_up_down):
        self.game_name = game_name
        self.server_name = server_name
        self.server_region = server_region
        self.number_of_players = number_of_players
        self.server_up_down = server_up_down
        self.results = []
    # define a function that will return the game name
    def get_game_name(self):
        return self.game_name
    # define a function that will return the server name
    def get_server_name(self):
        return self.server_name
    # define a function that will return the server region
    def get_server_region(self):
        return self.server_region
    # define a function that will return the number of players
    def get_number_of_players(self):
        return self.number_of_players
    # define a function that will return the server up down status
    def get_server_up_down(self):
        return self.server_up_down
    # define a function that will return the results
    def get_results(self):
        return self.results
    # define a function that will add a result to the results list
    def add_result(self, result):
        self.results.append(result)
    # define a function that will return a string representation of the GameServer object
    def __str__(self):
        return f"Game Name: {self.game_name}\nServer Name: {self.server_name}\nServer Region: {self.server_region}" \
               f"\nNumber of Players: {self.number_of_players}\nServer Up Down: {self.server_up_down}\nResults: {self.results}"

    # define a function that will set the game number of players
    def set_number_of_players(self, param):
        self.number_of_players = param
    # define a function that will set the server up down status
    def set_server_up_down(self, param):
        self.server_up_down = param
    # define a function that will set the results
    def set_results(self, param):
        self.results = param

    def to_dict(self):
        return {
            'game_name': self.game_name,
            'server_name': self.server_name,
            'server_region': self.server_region,
            'number_of_players': self.number_of_players,
            'server_up_down': self.server_up_down,
            'results': self.results,
        }

    @classmethod
    def from_dict(cls, dict_data):
        return cls(
            dict_data['game_name'],
            dict_data['server_name'],
            dict_data['server_region'],
            dict_data['number_of_players'],
            dict_data['server_up_down'],
          )

