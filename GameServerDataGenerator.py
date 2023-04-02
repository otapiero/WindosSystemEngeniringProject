'''
define functions that will generate data for a game server.
the function should create GameServer objects and store them to json files in the GameServerData directory.
'''
import json
import os

from GameServer import GameServer
import random

default_list_of_games = ["League of Legends", "World of Warcraft", "Minecraft", "Fortnite", "Call of Duty",
                         "Counter Strike", "Grand Theft Auto", "Overwatch", "Halo", "Starcraft"]
DATA_DIRECTORY = "GameServerData"


# define a function that will generate a GameServer object with random data for each game in the list_of_games list
def generate_data(list_of_games: list):
    # create an empty list to hold GameServer objects
    game_servers = []
    # iterate over the list of games
    for game in list_of_games:
        # create a GameServer object with random data
        game_server = GameServer(game, f"{game} Server", random.choice(["North America", "Europe", "Asia"]),
                                 random.randint(100, 100000), random.choice(["up", "down"]))
        # add the GameServer object to the list of GameServers
        game_servers.append(game_server)
    # return the list of GameServers
    return game_servers


# define a function that will store data to a json file.
#  the function should take a GameServer object as a parameter.



# define a function that will update the data in a game server json file with new data
# the function should take a GameName  as a parameter and change the number of players and server up/down status
# the function should generate new data for the GameServer using the old data as a starting point.
def update_data(GameName: str):
    # search if the game server exists in the directory
    if os.path.exists(f"{DATA_DIRECTORY}/{GameName}.json"):
        # if it exists, open the file
        with open(f"{DATA_DIRECTORY}/{GameName}.json") as json_file:
            # load the file into a dictionary
            data = json.load(json_file)
            # create a GameServer object from the dictionary
            game_server = GameServer(data["game_name"], data["server_name"], data["server_region"],
                                     data["number_of_players"], data["server_up_down"])
            # change the number of players using the old number of players as a starting point
            number = game_server.get_number_of_players() + random.randint(-1000, 1000)
            number = 0 if number < 0 else number
            game_server.set_number_of_players(number)
            # change the server up/down status
            game_server.set_server_up_down(random.choice(["up", "down"]))
            # return the GameServer object
            return game_server
    else:
        # if the game server does not exist, create a new GameServer object
        # using the generate_data function
        game_server = generate_data([GameName])[0]
        # return the GameServer object
        return game_server


'''# initialize game servers data
lst = generate_data(default_list_of_games)
for i in lst:
    store_data(i)'''
