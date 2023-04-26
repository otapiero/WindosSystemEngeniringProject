from flask import Flask, request, jsonify
from GameServerDataGenerator import GameServerDataGenerator
# create an instance of the GameServerDataGenerator class
app = Flask(__name__)
port = 5098  # specify the port number to use


@app.route("/gameservers", methods=["POST"])
def create_game_server():
    # get the request body
    request_body = request.get_json(force=True)
    # extract game_name and server_name from the request body
    game_name = request_body["game_name"]
    server_name = request_body["server_name"]
    # create a new GameServer object
    game_server = GameServerDataGenerator.generate_game_server(game_name, server_name)
    # return the GameServer object as JSON data
    return jsonify(game_server.to_dict())

@app.route("/gameserverdatastats", methods=["POST"])
def create_game_server_stats():
    # get the request body
    request_body = request.get_json()
    # extract server_name, date_time_start, and date_time_end from the request body
    server_name = request_body["server_name"]
    date_time_start = request_body["date_time_start"]
    date_time_end = request_body["date_time_end"]
    # get the GameServerDataStats for the given server and time range
    game_server_data_stats = GameServerDataGenerator.generate_game_server_stats(server_name, date_time_start, date_time_end)
    # create a list of dictionaries from the GameServerDataStats
    game_server_data_stats_dicts = [data_stat.to_dict() for data_stat in game_server_data_stats]
    # create a dictionary to hold the list of dictionaries
    data = {"game_server_data_stats": game_server_data_stats_dicts}
    # return the dictionary as JSON data
    return jsonify(data)

# run the application
if __name__ == "__main__":
    app.run(debug=True, port=port)
'''
request example:
curl -X GET -H 'accept: text/plain'  http://localhost:5098/GameEntitie 
'''

'''
curl -X POST -H  "Content-Type: application/json" -d "{\"game_name\":\"call of duty\",\"server_name\":\"cod server 1\"}"  http://localhost:5098/gameservers



curl -X POST -H "Content-Type: application/json" -d "{\"server_name\":\"cod server 1\", \"date_time_start\":\"2023-04-25 00\", \"date_time_end\":\"2023-04-26 00\"}" http://localhost:5098/gameserverdatastats

'''
