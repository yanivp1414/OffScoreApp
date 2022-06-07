using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OffscoreApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OffscoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderboardPage : ContentView
    {
        public LeaderboardPage()
        {
            LeaderBoardViewModel context = new LeaderBoardViewModel();
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}