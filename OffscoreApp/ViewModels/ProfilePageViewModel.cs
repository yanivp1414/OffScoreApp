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
    class ProfilePageViewModel : BaseViewModel
    {
        public event Action<Page> push;
        private OffscoreWebService proxy;
        private string fullName;
        private DateTime birthday;
        private string email;
        private string password;
        private int points;
        private int rank;



        #region ServerStatus
        private string serverStatus;
        public string ServerStatus
        {
            get { return serverStatus; }
            set => SetValue(ref serverStatus, value);
            
        }
        #endregion

        #region Is Refreshing
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set => SetValue(ref isRefreshing, value);
        }
        #endregion

        public int Points
        {
            get => points;
            set => SetValue(ref points, value);
        }

        public int Rank
        {
            get => rank;
            set => SetValue(ref rank, value);
        }

        public string Password
        {
            get => password;
            set => SetValue(ref password, value);
        }

        public DateTime Birthday
        {
            get => birthday.Date;
            set => SetValue(ref birthday, value);
        }


        public string FullName
        {
            get => fullName;
            set => SetValue(ref fullName, value);
        }

        public string Email
        {
            get => email;
            set => SetValue(ref email, value);
        }
        public ProfilePageViewModel()
        {
            if (((App)App.Current).User != null)
            {
                proxy = OffscoreWebService.CreateProxy();
                FullName = ((App)App.Current).User.FullName;
                Birthday = ((App)App.Current).User.Birthday;
                Email = ((App)App.Current).User.Email;
                Points = ((App)App.Current).User.Points;
            }
            ((App)App.Current).UserChanged += Refresh;
        }

        public Command LoadProfileCommand => new Command(() => LoadProfile());
        public void LoadProfile()
        {
            IsRefreshing = false;
        }

        
        public Command UpdateInfoPageCommand => new Command(() => UpdateInfoPage());
        public void UpdateInfoPage()
        {
            push?.Invoke(new Views.UpdateInfoPage());
        }

        public Command Logout => new Command(LogoutMethod);
        private void LogoutMethod()
        {
            proxy.Logout();
            ((App)App.Current).User = null;
            App.Current.MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = Color.Black };
        }
        
        public void Refresh()
        {
            if(((App)App.Current).User != null)
            {
                FullName = ((App)App.Current).User.FullName;
                Birthday = ((App)App.Current).User.Birthday;
                Email = ((App)App.Current).User.Email;
                Points = ((App)App.Current).User.Points;
            }
        }


    }
}
