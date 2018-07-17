using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;

namespace BuzzBandung.Views.Main.Popups
{
    public partial class DetailPopup : PopupPage
    {
        public DetailPopup()
        {
            InitializeComponent();
            carousel.ItemsSource = new List<string>
            {
                "a",
                "b",
                "c"
            };
        }

        void CloseButton_Clicked(object sender, System.EventArgs e)
        {
            this.Navigation.PopPopupAsync();
        }
    }
}
