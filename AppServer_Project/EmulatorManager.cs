namespace AppServer_Project
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

  

    public class EmulatorManager
    {
        static public async Task<string> GetServersData(List<string> gameServerNames)
        {
            // Create a new HttpClient instance
            using var httpClient = new HttpClient();

            // Define the request data as JSON
            var requestData = new Dictionary<string, List<string>> { { "game_server_names", gameServerNames } };
            var requestContent = new StringContent(JsonSerializer.Serialize(requestData), System.Text.Encoding.UTF8, "application/json");

            // Create the HTTP request message
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:5000/gameservers"),
                Content = requestContent
            };

            // Send the request and get the response
            var response = await httpClient.SendAsync(request);

            // Read the response as JSON
            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
}
