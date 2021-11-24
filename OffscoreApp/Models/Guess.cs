using System;
using System.Collections.Generic;


namespace OffscoreApp.Models
{

    public partial class Guess
    {

        public int GuessId { get; set; }
        public int AccountId { get; set; }

        public DateTime GuessingTime { get; set; }
        public int Team1Guess { get; set; }
        public int Team2Guess { get; set; }
        public int GameId { get; set; }
        public int ActivityStatus { get; set; }


        public virtual Account Account { get; set; }

        public virtual ActivityStatus ActivityStatusNavigation { get; set; }

        public virtual Game Game { get; set; }
    }
}
