using System;
using System.Collections.Generic;


namespace OffscoreApp.Models
{

    public partial class Game
    {
        public Game()
        {
            Guesses = new HashSet<Guess>();
        }


        public int GameId { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }

        public string FinalScore { get; set; }
        public int ActivityStatus { get; set; }

 
        public virtual ActivityStatus ActivityStatusNavigation { get; set; }

        public virtual Team Team1 { get; set; }

        public virtual Team Team2 { get; set; }
  
        public virtual ICollection<Guess> Guesses { get; set; }
    }
}
