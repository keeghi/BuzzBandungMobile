using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BuzzBandung.Common.Base;
using BuzzBandung.Extensions;
using BuzzBandung.Views.Main.Controls;
using Xamarin.Forms.GoogleMaps;

namespace BuzzBandung.Views.Main
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }

        private CameraUpdate _initialCameraUpdate;
        public CameraUpdate InitialCameraUpdate
        {
            get => _initialCameraUpdate;
            set
            {
                _initialCameraUpdate = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BottomBarItem> _stories = new ObservableCollection<BottomBarItem>();
        public ObservableCollection<BottomBarItem> Stories
        {
            get => _stories;
            set
            {
                _stories = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(App.Settings.CurrentPosition.ToGoogleMaps(), Configuration.GoogleMaps.DefaultZoomLevel);

            Stories = new ObservableCollection<BottomBarItem>
            {
                new BottomBarItem { ImageUrl = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Text = "Test" },
                new BottomBarItem { ImageUrl = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Text = "Test" },
                new BottomBarItem { ImageUrl = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Text = "Test" },
                new BottomBarItem { ImageUrl = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Text = "Test" },
                new BottomBarItem { ImageUrl = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Text = "Test" },
                new BottomBarItem { ImageUrl = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Text = "Test" },
                new BottomBarItem { ImageUrl = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Text = "Test" },
                new BottomBarItem { ImageUrl = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Text = "Test" },
                new BottomBarItem { ImageUrl = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Text = "Test" }
            };

            return base.InitializeAsync(navigationData);
        }
    }
}
