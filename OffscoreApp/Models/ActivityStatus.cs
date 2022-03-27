using System;
using System.Collections.Generic;



namespace OffscoreApp.Models
{
    public partial class ActivityStatus
    {
        public ActivityStatus()
        {
            Accounts = new HashSet<Account>();
            Games = new HashSet<Game>();
            Guesses = new HashSet<Guess>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Guess> Guesses { get; set; }
    }
}
