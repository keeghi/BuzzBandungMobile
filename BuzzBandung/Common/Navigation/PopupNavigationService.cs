using System;
using System.Threading.Tasks;
using BuzzBandung.Common.Base;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

namespace BuzzBandung.Common.Navigation
{
    public partial class NavigationService : INavigationService
    {
        public Task PopPopupAsync()
        {
            if (PopupNavigation.Instance.PopupStack.Count > 0)
                return CurrentApplication.MainPage.Navigation.PopPopupAsync();

            return Task.CompletedTask;
        }

        public Task NavigateToPopupAsync<TViewModel>(bool animate) where TViewModel : ViewModelBase
        {
            return NavigateToPopupAsync<TViewModel>(null, animate);
        }

        public async Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate) where TViewModel : ViewModelBase
        {
            var page = Locator.Instance.CreatePage<TViewModel>();

            if (page is PopupPage popupPage)
                await CurrentApplication.MainPage.Navigation.PushPopupAsync(popupPage, animate);
            else
                throw new InvalidCastException($"{nameof(page)} is not a popup page");

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }
    }
}
