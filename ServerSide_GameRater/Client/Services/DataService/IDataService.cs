using ServerSide_GameRater.Shared;

namespace ServerSide_GameRater.Client.Services.GameService
{
    public interface IDataService
    {
        List<Game> Games { get; set; }
        List<User> Users { get; set; }
        List<Rating> Ratings { get; set; }


        Task GetGames();
        Task GetUsers();
        Task<List<Rating>> GetRatings();
        Task<ServerSide_GameRater.Shared.Game> GetSingleGame(int id);
        Task<User> GetSingleUser(int id);
        Task<Rating> GetSingleRating(int id);
        Task<List<Rating>> GetUserRatings(int id);

        Task CreateUser(User user);
        Task CreateGame(Game game);
        Task CreateRating(Rating rating);
       

    }
}
