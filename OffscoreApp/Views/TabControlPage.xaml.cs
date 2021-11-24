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
    public partial class TabControlPage : ContentPage
    {
        public TabControlPage()
        {
            TabControlViewModel context = new TabControlViewModel();
            context.Push += (p) => Navigation.PushAsync(p);
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}