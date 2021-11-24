using System;
using System.Collections.Generic;


namespace OffscoreApp.Models
{
  
    public partial class League
    {
        public League()
        {
            Teams = new HashSet<Team>();
        }

   
        public int LeagueId { get; set; }
       
        public string Country { get; set; }
 
        public string LegueName { get; set; }

      
        public virtual ICollection<Team> Teams { get; set; }
    }
}
