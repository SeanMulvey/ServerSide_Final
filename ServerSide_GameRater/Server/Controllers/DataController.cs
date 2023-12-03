using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerSide_GameRater.Server.Data;
using ServerSide_GameRater.Shared;

namespace ServerSide_GameRater.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataContext _context;

        public DataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet("users/{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.userID == id);
            if(user == null)
            {
                return NotFound("User Does Not Exist");
            }
            return Ok(user);
        }
        [HttpGet("games")]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            var games = await _context.Games.ToListAsync();
            return Ok(games);
        }
        [HttpGet("games/{id}")]
        public async Task<ActionResult<Game>> GetSingleGame(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.gameID == id);
            if (game == null)
            {
                return NotFound("Game Does Not Exist");
            }
            return Ok(game);
        }
        [HttpGet("ratings")]
        public async Task<ActionResult<List<Rating>>> GetRatings()
        {
            var ratings = await _context.Ratings.ToListAsync();
            return Ok(ratings);
        }
        [HttpGet("ratings/{id}")]
        public async Task<ActionResult<Rating>> GetSingleRating(int id)
        {
            var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.ratingID == id);
            if (rating == null)
            {
                return NotFound("Rating Does Not Exist");
            }
            return Ok(rating);
        }

        [HttpGet("ratings/user/{id}")]
        public async Task<ActionResult<List<Rating>>> GetUserRatings(int id)
        {
            var rating = await _context.Ratings.Where(r => r.userID == id).ToListAsync();
            if (rating == null)
            {
                return NotFound("User Rating Does Not Exist");
            }
            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return Ok(game);
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<Rating>> CreateRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return Ok(rating);
        }
        private async Task<List<Game>> GetDbGames()
        {
            return await _context.Games.ToListAsync(); 
        }
        private async Task<List<User>> GetDbUsers()
        {
            return await _context.Users.ToListAsync();
        }
        private async Task<List<Rating>> GetDbRatings()
        {
            return await _context.Ratings.ToListAsync();
        }


    }
}
