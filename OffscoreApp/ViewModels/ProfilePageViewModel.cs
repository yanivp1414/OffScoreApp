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
        #region UserImgSrc
        private string userImgSrc;
        public string UserFullName;
        public string Email;
        public string Password;
        FileResult imageFileResult;

        public string UserImgSrc
        {
            get => userImgSrc;
            set => SetValue(ref userImgSrc, value);
            
        }
        private const string DEFAULT_PHOTO_SRC = "user.png";
        #endregion

        #region ServerStatus
        private string serverStatus;
        public string ServerStatus
        {
            get { return serverStatus; }
            set => SetValue(ref serverStatus, value);
            
        }
        #endregion

        public ProfilePageViewModel()
        {
            // Setup default image photo
            this.UserImgSrc = DEFAULT_PHOTO_SRC;
            this.imageFileResult = null; //mark that no picture was chosen
            UserFullName = "";
            Email = "";
            Password = "";

        }

    }
}
