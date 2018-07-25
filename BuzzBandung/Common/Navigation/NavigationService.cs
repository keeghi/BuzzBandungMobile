using System;
using System.Threading.Tasks;
using BuzzBandung.Common.Base;
using BuzzBandung.Views.Main;
using Xamarin.Forms;

namespace BuzzBandung.Common.Navigation
{
    public partial class NavigationService : INavigationService
    {
        Application CurrentApplication => Application.Current;

        public async Task InitializeAsync()
        {
            var page = Locator.Instance.CreatePage<MainViewModel>();

            CurrentApplication.MainPage = page;

            await (page.BindingContext as ViewModelBase).InitializeAsync(null);
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return Task.CompletedTask;
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return Task.CompletedTask;
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return Task.CompletedTask;
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return Task.CompletedTask;
        }

        public Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is NavigationPage navigation)
                return navigation.PopAsync();

            return Task.CompletedTask;
        }

        internal Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            return Task.CompletedTask;
        }
    }
}