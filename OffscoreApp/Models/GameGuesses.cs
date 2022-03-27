using System;
using System.Collections.Generic;
using System.Text;

namespace OffscoreApp.Models
{
    class GameGuesses
    {
        public int GameId{ get; set; }
        public int Team1Guess { get; set; }
        public int Team2Guess { get; set; }
        public int UserId { get; set; }
    }
}
