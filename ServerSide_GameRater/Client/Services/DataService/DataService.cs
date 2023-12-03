

using ServerSide_GameRater.Client.Pages;
using ServerSide_GameRater.Client.Services.GameService;
using ServerSide_GameRater.Shared;
using System.Net.Http.Json;
using System.Reflection.Metadata;

namespace ServerSide_GameRater.Client.Services.DataService
{
    public class DataService : IDataService
    {
        private readonly HttpClient _http;

        public DataService(HttpClient http)
        {
            _http = http;
        }
        public List<ServerSide_GameRater.Shared.Game> Games { get; set; } = new List<ServerSide_GameRater.Shared.Game>();
        public List<User> Users { get; set; } = new List<User>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();

        public async Task CreateGame(ServerSide_GameRater.Shared.Game game)
        {
            var result = await _http.PostAsJsonAsync("api/Data/games", game);
            var response = await result.Content.ReadFromJsonAsync<List<ServerSide_GameRater.Shared.Game>>();
            Games = response;
        }

        public async Task CreateRating(Rating rating)
        {
            var result = await _http.PostAsJsonAsync("api/Data/ratings", rating);
            var response = await result.Content.ReadFromJsonAsync<List<Rating>>();
            Ratings = response;
        }

        public async Task CreateUser(User user)
        {
            var result = await _http.PostAsJsonAsync("api/Data/users", user);
            var response = await result.Content.ReadFromJsonAsync<List<User>>();
            Users = response;
        }

        public async Task GetGames()
        {
            var result = await _http.GetFromJsonAsync<List<ServerSide_GameRater.Shared.Game>>("/api/data/games");
            if (result != null)
            {
                Games = result;
            }
        }

        public async Task<List<Rating>> GetRatings()
        {
            var result = await _http.GetFromJsonAsync<List<Rating>>($"/api/data/ratings");
            if (result != null) 
            {
                return result;
            }
            throw new Exception("Rating Not Found");
            
        }

        public async Task<ServerSide_GameRater.Shared.Game> GetSingleGame(int id)
        {
            var result = await _http.GetFromJsonAsync<ServerSide_GameRater.Shared.Game>($"/api/data/games/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Game Not Found");
        }

        public Task<Rating> GetSingleRating(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetSingleUser(int id)
        {
            var result = await _http.GetFromJsonAsync<User>($"/api/data/users/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("User Not Found");
        }

        public Task<List<Rating>> GetUserRatings(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<User>>("/api/data/users");
            if (result != null)
            {
                Users = result;
            }

        }
    }
}
