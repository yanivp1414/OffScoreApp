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
    public partial class PreviousGamesPage : ContentView
    {
        public PreviousGamesPage()
        {
            this.BindingContext = new PreviousGamesViewModel();
            InitializeComponent();
        }
    }
}