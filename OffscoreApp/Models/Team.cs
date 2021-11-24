using System;
using System.Collections.Generic;


namespace OffscoreApp.Models
{
    
    public partial class Team
    {
        public Team()
        {
            GameTeam1s = new HashSet<Game>();
            GameTeam2s = new HashSet<Game>();
        }

      
        public int TeamId { get; set; }
        public int LeagueId { get; set; }
     
        public string TeamName { get; set; }
        public int TeamRank { get; set; }
        public int TeamPoints { get; set; }

       
        public virtual League League { get; set; }
       
        public virtual ICollection<Game> GameTeam1s { get; set; }
        public virtual ICollection<Game> GameTeam2s { get; set; }
    }
}
