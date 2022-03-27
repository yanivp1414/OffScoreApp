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
    class SignupPageViewModel : BaseViewModel
    {
        private OffscoreWebService proxy;
        private string fullName;
        private string email;
        private string password;
        private string confirmPassword;
        private DateTime birthday;

        public DateTime Birthday
        {
            get => birthday.Date;
            set => SetValue(ref birthday, value);
        }
        public string Email
        {
            get => email;
            set => SetValue(ref email, value);
        }

        public string FullName
        {
            get => fullName;
            set => SetValue(ref fullName, value);
        }

        public string Password
        {
            get => password;
            set => SetValue(ref password, value);
        }

        public string ConfirmPassword
        {
            get => confirmPassword;
            set => SetValue(ref confirmPassword, value);
        }

        public Command SignupCommand => new Command(Signup);

        public event Action Pop;

        private async void Signup()
        {
            
            bool validAccount = true;
            if (!Validation.IsEmail(Email))
            {
                await App.Current.MainPage.DisplayAlert("Invalid Email", "Check email and try again", "OK");
                validAccount = false;
            }
            if (!Validation.Ispassword(Password))
            {
                await App.Current.MainPage.DisplayAlert("Invalid Password", $"Password must contain at least one uppercase & one lowercase letter, one number and cannot contain the following characters: {Validation.INVALID_PASSWORD_CHARS}", "OK");
                validAccount = false;
            }
            if (!Validation.IsOfAge(birthday))
            {
                await App.Current.MainPage.DisplayAlert("You are not old enough", $"You must be 16 years old or over...", "OK");
                validAccount = false;
            }
            if(FullName == null || FullName == "")
            {
                await App.Current.MainPage.DisplayAlert("Name not entered", $"You must enter a name to sign up.", "OK");
                validAccount = false;
            }
            if (validAccount)
            {
                //Creates an Account object to send to the API
                Account acc = new Account() { Birthday = this.Birthday, Email = this.Email, FullName = this.FullName, Pass = this.Password };

                bool result = await proxy.SignupAsync(acc); // Signs up server side
                if (result) // Checks if the sign up was successful
                {
                    await App.Current.MainPage.DisplayAlert("Signup Completed Successfully!", "Your account has been created and saved on our servers.", "Login");
                    Pop?.Invoke();
                    return;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("A User Already Exists", "A user with these credentials already exists.", "OK");
                }
            }
        }
        public SignupPageViewModel() { proxy = OffscoreWebService.CreateProxy(); }

        public event Action<Page> push;
    }
}
