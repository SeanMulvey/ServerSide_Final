using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide_GameRater.Shared
{
    public class Rating
    {
        public int ratingID {  get; set; } = 0;
        public int gameID { get; set; } = 0;
        public int userID { get; set; } = 0;
        public double rating { get; set; } = 0.0f;
    }
}
