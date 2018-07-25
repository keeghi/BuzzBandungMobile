using Xamarin.Forms;
using BuzzBandung.Extensions;

namespace BuzzBandung.Views.Main
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            map.UiSettings.CompassEnabled = false;
            map.UiSettings.ZoomControlsEnabled = false;
            map.UiSettings.ZoomGesturesEnabled = true;
            //map.UiSettings.MyLocationButtonEnabled = true;
            map.MyLocationEnabled = true;
        }

        void MyLocationButton_Clicked(object sender, System.EventArgs e)
        {
            map.MoveToRegion(App.Settings.CurrentPosition.ToGoogleMapsMapSpan());
        }
    }
}
