using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OffscoreApp.Views;
using OffscoreApp.Models;
using System.Collections.Generic;

[assembly: ExportFont("Righteous-Regular.ttf", Alias = "CustomFont")]
namespace OffscoreApp
{
    public partial class App : Application
    {
        public Account User { get; set; }
        public List<Game> DailyGames { get; set; }
        public List<League> Leagues   { get; set; }
        public List<Team> Teams { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new StartUpPage();

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
