﻿namespace AppServer_Project.Models;

// a class that contains the data of a game
public class GameData
{
    // the url of the images server by the api
    static private string imagesUrl = "https://images.igdb.com/igdb/image/upload/t_1080p/{hash}.jpg";

    public string Name { get; set; }
    private string artworkUrl { get; set;}
    public string ArtworkUrl
    {
        get => artworkUrl;
        init => artworkUrl = imagesUrl.Replace("{hash}", value);
    }
    public int Id { get; set; }
    public string Summary { get; set; }
}
