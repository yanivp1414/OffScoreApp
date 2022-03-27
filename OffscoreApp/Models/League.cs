using System;
using System.Collections.Generic;

namespace OffscoreApp.Models
{
    public partial class League
    {
        public League()
        {
            TeamGlobalLeagues = new HashSet<Team>();
            TeamLocalLeagues = new HashSet<Team>();
        }

        public int LeagueId { get; set; }
        public string Country { get; set; }
        public string LeagueName { get; set; }
        public virtual ICollection<Team> TeamGlobalLeagues { get; set; }
        public virtual ICollection<Team> TeamLocalLeagues { get; set; }
    }
}
