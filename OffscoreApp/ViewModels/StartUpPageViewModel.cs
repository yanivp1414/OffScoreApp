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

    public class StartUpPageViewModel : BaseViewModel
    {
        private OffscoreWebService proxy;
        public StartUpPageViewModel()
        {
            proxy = OffscoreWebService.CreateProxy();
            StartUp();
        }
        private async void StartUp()
        {
            List<Game> GameList = await proxy.GetActiveGames();
            List<League> LeagueList = await proxy.GetLeagues(); 
            List<Team> TeamList = await proxy.GetTeams();

            if(GameList != null && LeagueList != null && TeamList != null)
            {
                ((App)App.Current).DailyGames = GameList;
                ((App)App.Current).Leagues= LeagueList;
                ((App)App.Current).Teams = TeamList;

                App.Current.MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = Color.Black };

            }
        }
    }
}
