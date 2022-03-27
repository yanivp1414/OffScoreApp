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
    class HomePageViewModel : BaseViewModel
    {
        private OffscoreWebService proxy;
        public ObservableCollection<GameObject> ActiveGames { get; set; }
        private List<Game> dailyGames;
        public HomePageViewModel()
        {
            proxy = OffscoreWebService.CreateProxy();
            this.dailyGames = ((App)App.Current).DailyGames;
            ActiveGames = new ObservableCollection<GameObject>();
            BuildGameObjects();
        }
        private async void BuildGameObjects()
        {

            List<GameGuesses> guesses = await proxy.GetGuesses(dailyGames, ((App)App.Current).User.AccountId);
            foreach(Game g in dailyGames)
            {
                GameGuesses currentGame = guesses.FirstOrDefault(x => x.GameId == g.GameId);
                GameObject gO = new GameObject()
                {
                    Team1 = g.Team1.TeamName,
                    Team1Guess = "-",
                    Team2 = g.Team2.TeamName,
                    Team2Guess = "-"
                };

                if (g.FinalScore != "")
                {
                    List<string> scores = g.FinalScore.Split('-').ToList();
                    gO.Team1Score = scores[0];
                    gO.Team2Score = scores[1];
                }
                else
                {
                        gO.Team1Score = "-";
                        gO.Team2Score = "-";
                }
                if (currentGame != null)
                {
                    gO.Team1Guess = currentGame.Team1Guess.ToString();
                    gO.Team2Guess = currentGame.Team2Guess.ToString();
                }
                ActiveGames.Add(gO);

            }
        }
                       
    }
    class GameObject
    {
        public string Team1{ get; set;}
        public string Team2 { get; set; }
        public string Team1Guess { get; set; }
        public string Team2Guess { get; set; }
        public string Team1Score { get; set; }
        public string Team2Score { get; set; }

    }
}