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
    class TeamListViewModel : BaseViewModel
    {
        public ObservableCollection<Team> Teams { get; set; } 
        public TeamListViewModel()
        {
            Teams = new ObservableCollection<Team>();
            foreach (Team t in ((App)App.Current).Teams)
                Teams.Add(t);
        }
    }
}
