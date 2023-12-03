using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide_GameRater.Shared
{
    public class Game
    {
        public int gameID {  get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string publisher {  get; set; } = string.Empty;
        public string year { get; set; } = string.Empty;
        public int ratingCount { get; set; } = 0;
        public string icon {  get; set; } = string.Empty;
        public string iconUrl { get; set; } = string.Empty;
        public float rating { get; set; } = 0.0f;
        public string genreOne { get; set; } = string.Empty;
        public string genreTwo { get; set; } = string.Empty;
        public string genreThree { get; set;} = string.Empty;

    }
}
