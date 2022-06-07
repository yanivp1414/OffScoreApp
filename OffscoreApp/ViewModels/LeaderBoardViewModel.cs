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
    class LeaderBoardViewModel : BaseViewModel
    {
        private OffscoreWebService proxy;
        public ObservableCollection<Account> Leaderboard { get; set; }
        private async void LoadLeaderboard()
        {
            Leaderboard.Clear();
            List<Account> result = await proxy.GetLeaderboard();
            result = result.OrderByDescending(x => x.Points).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                Account a = result[i];
                a.Rank = i + 1;
                Leaderboard.Add(a);
            }
        }
        public LeaderBoardViewModel()
        {
            proxy = OffscoreWebService.CreateProxy();
            Leaderboard = new ObservableCollection<Account>();
            LoadLeaderboard();
        }
    }
}
