using System;
using System.Threading.Tasks;
using BuzzBandung.Common.Dialog;
using BuzzBandung.Common.Navigation;
using BuzzBandung.Views.Main;
using BuzzBandung.Views.Main.Popups;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BuzzBandung
{
    public partial class App : Application
    {
        public static IGeolocator Geolocator => CrossGeolocator.Current;

        static App() => InitializeDependency();

        static void InitializeDependency()
        {
            Locator.Instance.RegisterService<IDialogService, DialogService>();
            Locator.Instance.RegisterService<INavigationService, NavigationService>();
            Locator.Instance.RegisterView<MainView, MainViewModel>();
            Locator.Instance.RegisterView<DetailPopup, DetailPopupModel>();

            Locator.Instance.Build();
        }

        void InitializeGeolocator() => Geolocator.PositionChanged += OnPositionChanged;
        Task InitializeNavigation() => Locator.Instance.Resolve<INavigationService>().InitializeAsync();

        public App()
        {
            InitializeComponent();
            InitializeGeolocator();
            InitializeNavigation();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            await Geolocator.StartListeningAsync();
        }

        protected override async void OnResume()
        {
            base.OnResume();

            await Geolocator.StartListeningAsync();
        }

        protected override async void OnSleep()
        {
            base.OnSleep();

            await Geolocator.StopListeningAsync();
        }

        void OnPositionChanged(object sender, PositionEventArgs e) => Settings.CurrentPosition = e.Position;
    }
}
