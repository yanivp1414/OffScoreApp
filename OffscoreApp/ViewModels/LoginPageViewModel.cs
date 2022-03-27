using System;
using System.Collections.Generic;
using System.Text;
using OffscoreApp.Services;
using OffscoreApp.Views;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using OffscoreApp.Models;

namespace OffscoreApp.ViewModels
{
    class LoginPageViewModel : BaseViewModel
    {
        private OffscoreWebService proxy;
        private string email;
        private string password;
        public string Email 
        {
            get => email;
            set => SetValue(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetValue(ref password, value);
        }

        public Command LoginCommand => new Command(Login);
        private async void Login()
        {
            Account user = await proxy.LoginAsync(email, password);
            if(user != null)
            {
                ((App)App.Current).User = user;
                push?.Invoke(new TabControlPage());
                return;
            }
            await App.Current.MainPage.DisplayAlert("Login Failed", "Email or password are incorrect!\nPlease try again.", "OK");

        }
            
        public LoginPageViewModel()
        {
            this.proxy = OffscoreWebService.CreateProxy();

        }

        public Command PushToSignup => new Command(() => push?.Invoke(new SignupPage()));
        public event Action<Page> push;
    }
}
