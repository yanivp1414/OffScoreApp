using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OffscoreApp.Views;
using OffscoreApp.Models;

[assembly: ExportFont("Righteous-Regular.ttf", Alias = "CustomFont")]
namespace OffscoreApp
{
    public partial class App : Application
    {
        public Account User { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
