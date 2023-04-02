'''
create a flask application that will return GameServer objects as json data for the list of GameServers
in the request body. the request body should be a json file that contains a list of GameServer names.
the response should be a json file that contains a list of GameServer objects.
the application should be able to handle multiple GameServer names in the request body.
the application should be able to handle a single GameServer name in the request body.
the application will call the load_data function from the LoadAndStoreData.py file and return the GameServer objects
in the response body. as list of GameServer objects in json format.
'''
import json
from flask import Flask, request, jsonify
from LoadAndStoreData import load_data
app = Flask(__name__)
@app.route("/gameservers", methods=["POST"])
def get_game_servers():
    # get the request body
    request_body = request.get_json()
    # get the list of game server names from the request body
    game_server_names = request_body["game_server_names"]
    # load the data for the game servers
    game_servers = load_data(game_server_names)

    # create a list of dictionaries from the list of GameServer objects
    game_servers_dicts = [game_server.to_dict() for game_server in game_servers]
    # create a dictionary to hold the list of dictionaries
    data = {"game_servers": game_servers_dicts}
    # return the dictionary as json data
    return jsonify(data)


# run the application
if __name__ == "__main__":
    app.run(debug=True)
'''
request example:
>curl -X POST -H "Content-Type: application/json" -d "{\"game_server_names\": [\"Overwatch\", \"Starcraft\"]}" http://localhost:5000/gameservers
'''