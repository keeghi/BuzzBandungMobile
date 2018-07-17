using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CustomViewMainControlBottomBar = BuzzBandung.Views.Main.Controls.BottomBar;

[assembly: ExportRenderer(typeof(CustomViewMainControlBottomBar), typeof(BuzzBandung.Droid.Renderers.CustomViewMainControlBottomBarRenderer))]
namespace BuzzBandung.Droid.Renderers
{
    public class CustomViewMainControlBottomBarRenderer : ScrollViewRenderer
    {
        public CustomViewMainControlBottomBar CustomElement => Element as CustomViewMainControlBottomBar;

        public CustomViewMainControlBottomBarRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
        }
    }
}
