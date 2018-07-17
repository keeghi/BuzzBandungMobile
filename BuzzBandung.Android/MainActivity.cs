
using System.Reflection;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using FFImageLoading.Forms.Platform;
using Plugin.Permissions;
using Rg.Plugins.Popup;
using Xamarin;
using Xamarin.Forms;

namespace BuzzBandung.Droid
{
    [Activity(Label = "BuzzBandung", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            CachedImageRenderer.Init(true);
            Forms.Init(this, savedInstanceState);
            FormsGoogleMaps.Init(this, savedInstanceState);
            Popup.Init(this, savedInstanceState);
            UserDialogs.Init(this);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

