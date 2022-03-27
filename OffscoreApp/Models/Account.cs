using System;
using System.Collections.Generic;


namespace OffscoreApp.Models
{
    public partial class Account
    {
        public Account()
        {
            Guesses = new HashSet<Guess>();
        }


        public int AccountId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Pass { get; set; }
        public DateTime Birthday { get; set; }
        public int Points { get; set; }
        public bool IsAdmin { get; set; }
        public int ActivitySatus { get; set; }
        public virtual ActivityStatus ActivitySatusNavigation { get; set; }
        public virtual ICollection<Guess> Guesses { get; set; }
    }
}
