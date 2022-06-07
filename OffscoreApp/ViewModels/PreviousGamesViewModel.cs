using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using OffscoreApp.Services;
using OffscoreApp.Models;
using Xamarin.Essentials;
using System.Linq;
using OffscoreApp.Views;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace OffscoreApp.ViewModels
{
    public class PreviousGamesViewModel : BaseViewModel
    {
        public ObservableCollection<GameObject> Guesses { get; set; }
        private OffscoreWebService proxy;
        public PreviousGamesViewModel()
        {
            proxy = OffscoreWebService.CreateProxy();
            Guesses = new ObservableCollection<GameObject>();
            LoadGuesses();
            
            
        }

        private async void LoadGuesses()
        {
            List<Guess> last3Days = await proxy.GetPreviousDays(100, ((App)App.Current).User.AccountId);
            List<int> gameIds = new List<int>();
            foreach (Guess a in last3Days)
            {
                gameIds.Add(a.GameId);
            }

            List<Game> games = await proxy.GetGamesByIds(gameIds);
            foreach (Guess g in last3Days)
            {
                Game game = games.FirstOrDefault(x => x.GameId == g.GameId);
                List<string> scores = new List<string>();
                if (game.FinalScore != "")
                   scores = game.FinalScore.Split('-').ToList();
                else
                {
                    scores.Add("-");
                    scores.Add("-");
                }

                int score0 = int.Parse(scores[0]);
                int score1 = int.Parse(scores[1]);
                int points = 0;
                if((score0 == score1) && (g.Team2Guess == g.Team1Guess))
                    points++;
                else if(((score0 - score0) > 0) == ((g.Team1Guess - g.Team2Guess) > 0))
                    points++;

                if (score1 == g.Team2Guess && score0 == g.Team1Guess)
                    points++;


                GameObject go = new GameObject
                {
                    Team1 = game.Team1.TeamName,
                    Team2 = game.Team2.TeamName,
                    Team1Guess = g.Team1Guess.ToString(),
                    Team2Guess = g.Team2Guess.ToString(),
                    Team1Score = scores[0],
                    Team2Score = scores[1],
                    GuessDate = g.GuessingTime.Date.ToShortDateString(),
                    GameId = g.GameId,
                    PointsEarned = points
                } ;
                Guesses.Add(go);
            }
        }
    }
}