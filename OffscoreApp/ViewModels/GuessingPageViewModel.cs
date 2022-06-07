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
    class GuessingPageViewModel : BaseViewModel
    {
        private Team team1;
        private Team team2;
        private int team1Guess;
        private int team2Guess;
        private Game currentGame;
        private OffscoreWebService proxy;

        public Team Team1
        {
            get => team1;
            set => SetValue(ref team1, value);
        }
        public Team Team2
        {
            get => team2;
            set => SetValue(ref team2, value);
        }
        public int Team1Guess
        {
            get => team1Guess;
            set => SetValue(ref team1Guess, value);
        }
        public int Team2Guess
        {
            get => team2Guess;
            set => SetValue(ref team2Guess, value);
        }

        public Command PlaceGuessCommand => new Command(PlaceGuess);
        private async void PlaceGuess()
        {
            Guess g = new Guess()
            {
                AccountId = ((App)App.Current).User.AccountId,
                Team1Guess = Team1Guess,
                Team2Guess = Team2Guess,
                GameId = currentGame.GameId,
                ActivityStatus = 1
            };
            bool result = await proxy.AddGuess(g);
            if (result)
            {
                await ((App)App.Current).MainPage.Navigation.PopAsync();
            }
        }

        private async void LoadValues(int gameId)
        {
            Game g = await proxy.GetGamesById(gameId);
            this.currentGame = g;
            this.Team1 = g.Team1;
            this.Team2 = g.Team2;
        }
        public GuessingPageViewModel(int gameId)
        {
            proxy = OffscoreWebService.CreateProxy();
            LoadValues(gameId);

        }

    }
}
