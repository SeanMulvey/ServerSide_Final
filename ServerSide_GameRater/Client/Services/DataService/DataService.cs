

using ServerSide_GameRater.Client.Services.GameService;
using ServerSide_GameRater.Shared;
using System.Net.Http.Json;

namespace ServerSide_GameRater.Client.Services.DataService
{
    public class DataService : IDataService
    {
        private readonly HttpClient _http;

        public DataService(HttpClient http)
        {
            _http = http;
        }
        public List<Game> Games { get; set; } = new List<Game>();
        public List<User> Users { get; set; } = new List<User>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();

        public async Task GetGames()
        {
            var result = await _http.GetFromJsonAsync<List<Game>>("/api/data/games");
            if (result != null)
            {
                Games = result;
            }
        }

        public Task GetRatings()
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetSingleGame(int id)
        {
            var result = await _http.GetFromJsonAsync<Game>($"/api/data/games/{id}");
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

        public Task GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
