using OffscoreApp.Models;
using OffscoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OffscoreApp.ViewModels
{
     class UpdateInfoViewModel : BaseViewModel
    {
        private OffscoreWebService proxy;
        private string fullName;
        private DateTime birthday;
        private string password;

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

        public string Password
        {
            get => password;
            set => SetValue(ref password, value);
        }


        public Command UpdateCommand => new Command(Update);

        public event Action Pop;

        private async void Update()
        {

            bool validAccount = true;
            
            if (!Validation.IsOfAge(birthday))
            {
                await App.Current.MainPage.DisplayAlert("You are not old enough", $"You must be 16 years old or over...", "OK");
                validAccount = false;
            }
            if (!Validation.Ispassword(password))
            {
                await App.Current.MainPage.DisplayAlert("Invalid Password", $"Password must contain at least one uppercase & one lowercase letter, one number and cannot contain the following characters: {Validation.INVALID_PASSWORD_CHARS}", "OK");
                validAccount = false;
            }
            if (validAccount)
            {
                //Creates an Account object to send to the API
                

                Account result = await proxy.UpdateAsync(this.FullName,this.Birthday,this.Password,((App)App.Current).User.AccountId.ToString()); // Signs up server side
                if (result != null) // Checks if the sign up was successful
                {
                    ((App)App.Current).User = result;
                    await App.Current.MainPage.DisplayAlert("Update Completed Successfully!", "Your account has been created and saved on our servers.", "ok");
                    
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Update Failed!", "Something went wrong...", "ok");
                }
            }
        }
        public UpdateInfoViewModel()
        {
            if(((App)App.Current).User != null)
            {
                proxy = OffscoreWebService.CreateProxy();
                FullName = ((App)App.Current).User.FullName;
                Birthday = ((App)App.Current).User.Birthday;
                Password = ((App)App.Current).User.Pass;
            }
            
        }

        public event Action<Page> push;
    }
}