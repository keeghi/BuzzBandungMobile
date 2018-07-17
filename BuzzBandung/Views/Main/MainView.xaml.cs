using Xamarin.Forms;

namespace BuzzBandung.Views.Main
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            map.UiSettings.CompassEnabled = false;
            map.UiSettings.ZoomControlsEnabled = false;
            map.UiSettings.ZoomGesturesEnabled = false;
            //map.UiSettings.MyLocationButtonEnabled = true;
            map.MyLocationEnabled = true;
        }
    }
}
