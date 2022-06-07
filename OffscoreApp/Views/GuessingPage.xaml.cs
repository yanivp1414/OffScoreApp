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
    public partial class GuessingPage : ContentPage
    {
        public GuessingPage(int id)
        {
            GuessingPageViewModel context = new GuessingPageViewModel(id);
            this.BindingContext = context;
            InitializeComponent();
        }

    }
    
    
}