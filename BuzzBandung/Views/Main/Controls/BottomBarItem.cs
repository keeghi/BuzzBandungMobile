using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BuzzBandung.Common.Base;
using BuzzBandung.Views.Main.Popups;
using Xamarin.Forms;

namespace BuzzBandung.Views.Main.Controls
{
    public class BottomBarItem : BindableActionObject
    {
        public string ImageUrl { get; set; }
        public string Text { get; set; }

        public ICommand ClickCommand => new Command(async () => await ClickAsync());

        async Task ClickAsync() => await NavigationService.NavigateToPopupAsync<DetailPopupModel>(true);
    }
}
