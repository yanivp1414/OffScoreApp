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
    public partial class UpdateInfoPage : ContentPage
    {
        public UpdateInfoPage()
        {
            InitializeComponent();
            UpdateInfoViewModel uIVM = new UpdateInfoViewModel();
            uIVM.push += (p) => Navigation.PushAsync(p);
            this.BindingContext = uIVM;
        }
    }
}