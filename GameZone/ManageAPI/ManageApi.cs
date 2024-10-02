using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace GameZone.Models
{
    public class ManageApi
    {
        private readonly HttpClient _client;
        private readonly string _connectionString;

        public ManageApi(HttpClient client, IConfiguration config)
        {
            _client = client;
            _connectionString = config.GetConnectionString("MyCon");
        }

        // GET all games
        public async Task<IEnumerable<Game>> GetAllGamesAsync(string baseUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/api/games/");
            request.Headers.Add("ConnectionString", _connectionString);  // Add connection string in header
            //var response = await _client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            try
            {
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content= await response.Content.ReadFromJsonAsync<IEnumerable<Game>>();
                return content;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
            }
            return null;
        }

        // GET game by ID
        public async Task<Game> GetGameByIdAsync(int id, string baseUrl)
        { 
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/api/games/{id}");
            request.Headers.Add("ConnectionString", _connectionString);
            try
            {
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadFromJsonAsync<Game>();
                return content;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
            }
            return null;
        }

        // POST create game
        public async Task<HttpResponseMessage> CreateGameAsync(Game game, string baseUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/api/games");
            request.Headers.Add("ConnectionString", _connectionString);
            request.Content = JsonContent.Create(game);
            return await _client.SendAsync(request);

        }

        // PUT edit game
        public async Task<bool> EditGameAsync(int id, Game game, string baseUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}/api/games/{id}")
            {
                Content = JsonContent.Create(game)  // Serialize game object to JSON
            };
            request.Headers.Add("ConnectionString", _connectionString);
            try
            {
                var response = await _client.SendAsync(request);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Log or handle non-success status code
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {response.StatusCode}. Message: {errorContent}");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                // Log request-related errors
                Console.WriteLine($"Request exception: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log any other unexpected errors
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return false;
            }
        }

        // DELETE game
        public async Task<bool> DeleteGameAsync(int id, string baseUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/api/games/{id}");
            request.Headers.Add("ConnectionString", _connectionString);
            try
            {
                var response = await _client.SendAsync(request);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Log or handle non-success status code
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {response.StatusCode}. Message: {errorContent}");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                // Log request-related errors
                Console.WriteLine($"Request exception: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log any other unexpected errors
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return false;
            }
        }
    }

}
//public class ManageApi
//{
//    private readonly HttpClient _httpClient;
//    private readonly string _connectionString;
//    private readonly string _baseUrl;
//    public ManageApi(HttpClient httpClient, string baseUrl,  string connectionString) 
//    {
//        _httpClient = httpClient;

//        _connectionString = connectionString;
//    }
//    public async Task<HttpResponseMessage> PostDataAsync(Game data,string baseUrl)
//    {
//        var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/api/game");

//        // Optionally send the connection string as a header
//        requestMessage.Headers.Add("ConnectionString", _connectionString);

//        var jsonContent = JsonConvert.SerializeObject(data);
//        requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

//        return await _httpClient.SendAsync(requestMessage);
//    }
//    public async Task<T> GetAsync<T>(string baseUrl)
//    {

//        HttpResponseMessage response = await _httpClient.GetAsync($"{baseUrl}/api/game");
//        if (response.IsSuccessStatusCode)
//        {
//            var jsonData = await response.Content.ReadAsStringAsync();
//            return JsonConvert.DeserializeObject<T>(jsonData);
//        }
//        return default;
//    }
//    public async Task<bool> PostAsync<T>(string baseUrl, T data)
//    {

//        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
//        HttpResponseMessage response = await _httpClient.PostAsync($"{baseUrl}/api/game", content);
//        return response.IsSuccessStatusCode;
//    }

//    public async Task<bool> PutAsync<T>(string baseUrl, T data)
//    {

//        var jsonContent = JsonConvert.SerializeObject(data);
//        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

//        HttpResponseMessage response = await _httpClient.PutAsync($"{baseUrl}/api/game", content);
//        return response.IsSuccessStatusCode;
//    }

//    public async Task<bool> DeleteAsync(string baseUrl)
//    {

//        HttpResponseMessage response = await _httpClient.DeleteAsync($"{baseUrl}/api/game");
//        return response.IsSuccessStatusCode;
//    }
//}
