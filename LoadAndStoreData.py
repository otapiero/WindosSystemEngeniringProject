'''
define functions that will load and store data from json files. from "GameServerData" directory
 load all json files and create a list of GameServer objects.
'''
import json
import os
from GameServer import GameServer
from GameServerDataGenerator import generate_data
def load_data(GameNames):
    # get a list of all files in the GameServerData directory
    files = os.listdir("GameServerData")

    # create an empty list to hold GameServer objects
    game_servers = []
    # iterate over the list of files
    for file in files:
        # check if the game name appears in a file name withouth the .json extension
       if file.replace(".json", "") in GameNames:
            GameNames.remove(file.replace(".json", ""))
            # open the file
            with open(f"GameServerData/{file}", "r") as json_file:
                # load the data from the file
                data = json.load(json_file)
                # create a GameServer object from the data
                game_server = GameServer.from_dict(data)
                # add the GameServer object to the list of GameServers
                game_servers.append(game_server)
    # if there are any games that do not have a json file, create a new GameServer object for each game
    new_game_servers = generate_data(GameNames)
    # store the new GameServer objects to json files
    for game_server in new_game_servers:
        store_data(game_server)
    # add the new GameServer objects to the list of GameServers
    game_servers.extend(new_game_servers)
    return game_servers

'''
define a function that will store data to a json file.
 the function should take a GameServer object as a parameter.
'''
def store_data(game_server):
    # create a dictionary from the GameServer object
    data = {"game_name": game_server.get_game_name(), "server_name": game_server.get_server_name(),
            "server_region": game_server.get_server_region(), "number_of_players": game_server.get_number_of_players(),
            "server_up_down": game_server.get_server_up_down(), "results": game_server.get_results()}
    # open a file to write the data to
    with open(f"GameServerData/{game_server.get_game_name()}.json", "w") as json_file:
        # write the data to the file
        json.dump(data, json_file)
