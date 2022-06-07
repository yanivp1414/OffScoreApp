using System;
using System.Collections.Generic;
using System.Text;

namespace OffscoreApp.Models
{
    public class GameObject
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Team1Guess { get; set; }
        public string Team2Guess { get; set; }
        public string Team1Score { get; set; }
        public string Team2Score { get; set; }
        public string GuessDate { get; set; }
        public int GameId { get; set; }
        public int PointsEarned { get; set; }

    }
}
