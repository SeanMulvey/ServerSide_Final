using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerSide_GameRater.Shared;

namespace ServerSide_GameRater.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public static List<User> users = new List<User>
        {
            new User { userID = 3, username = "gamePlayer420", email = "iplaygames@gmail.com", password = "wordpass" },
            new User { userID = 4, username = "xXNoScoperXx", email = "codkid@gamil.com", password = "cod" },
            new User { userID = 5, username = "WOWisBis", email = "nolife@gmail.com", password = "windfury" },
            new User { userID = 6, username = "dave", email = "dave@gmail.com", password = "davespass" }

        };
        public static List<Game> games = new List<Game>
        {
            new Game { gameID = 5, title = "World of Warcraft", publisher = "Blizzard", year = "2004", ratingCount = 1, genreOne = "MMORPG", genreTwo = "Fantasy" },
            new Game { gameID = 6, title = "Dave's Game", publisher = "Dave", year = "1998", ratingCount = 1, genreOne = "Puzzle", genreTwo = "Adventure", genreThree = "Platformer"}
        };

        public static List<Rating> ratings = new List<Rating>
        {
            new Rating { ratingID = 1, userID = 5, gameID = 5, rating = 10.0f },
            new Rating { ratingID = 2, userID = 6, gameID = 6, rating = 7.5f },
            new Rating { ratingID = 3, userID = 5, gameID = 6, rating = 4.0f }
        };


        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(users);
        }
        [HttpGet("users/{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var user = users.FirstOrDefault(u => u.userID == id);
            if(user == null)
            {
                return NotFound("User Does Not Exist");
            }
            return Ok(user);
        }
        [HttpGet("games")]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            return Ok(games);
        }
        [HttpGet("games/{id}")]
        public async Task<ActionResult<Game>> GetSingleGame(int id)
        {
            var game = games.FirstOrDefault(g => g.gameID == id);
            if (game == null)
            {
                return NotFound("Game Does Not Exist");
            }
            return Ok(game);
        }
        [HttpGet("ratings")]
        public async Task<ActionResult<List<Rating>>> GetRatings()
        {
            return Ok(ratings);
        }
        [HttpGet("ratings/{id}")]
        public async Task<ActionResult<Rating>> GetSingleRating(int id)
        {
            var rating = ratings.FirstOrDefault(r => r.ratingID == id);
            if (rating == null)
            {
                return NotFound("Rating Does Not Exist");
            }
            return Ok(rating);
        }

        [HttpGet("ratings/user/{id}")]
        public async Task<ActionResult<List<Rating>>> GetUserRatings(int id)
        {
            var rating = ratings.Where(r => r.userID == id);
            if (rating == null)
            {
                return NotFound("User Rating Does Not Exist");
            }
            return Ok(rating);
        }

    }
}
