using System;
using System.Windows.Input;
using BuzzBandung.Common.Base;
using Xamarin.Forms;

namespace BuzzBandung.Views.Main.Popups
{
    public class DetailPopupModel : ViewModelBase
    {
        public DetailPopupModel()
        {
        }

        public ICommand CloseCommand => new Command(async () => await NavigationService.PopPopupAsync());
    }
}
