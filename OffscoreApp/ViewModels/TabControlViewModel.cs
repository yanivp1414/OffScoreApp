using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OffscoreApp.ViewModels
{
    class TabControlViewModel : BaseViewModel
    {
        public TabControlViewModel()
        {
            SelectedViewModelIndex = 0;
        }


        #region Selected Tab Index
        private int selectedViewModelIndex;
        public int SelectedViewModelIndex
        {
            get => selectedViewModelIndex;
            set => SetValue(ref selectedViewModelIndex, value);
        }
        #endregion

        public event Action<Page> Push;
    }
}
