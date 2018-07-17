using BuzzBandung.Common.Dialog;
using BuzzBandung.Common.Navigation;
using Xamarin.Forms;

namespace BuzzBandung.Common.Base
{
    public abstract class BindableActionObject : BindableObject
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        public BindableActionObject()
        {
            DialogService = Locator.Instance.Resolve<IDialogService>();
            NavigationService = Locator.Instance.Resolve<INavigationService>();
        }
    }
}

