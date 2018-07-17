using System;
using System.ComponentModel;
using Android.Content;
using Android.Views;
using Android.Widget;
using BuzzBandung.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedSearchBar), typeof(BuzzBandung.Droid.Renderers.ExtendedSearchBarRenderer))]
namespace BuzzBandung.Droid.Renderers
{
    public class ExtendedSearchBarRenderer : SearchBarRenderer
    {
        public ExtendedSearchBar ExtendedElement => Element as ExtendedSearchBar;

        public ExtendedSearchBarRenderer(Context context) : base(context) => AutoPackage = false;

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                #region Remove Underline
                var layout = Control.GetChildAt(0) as LinearLayout;
                layout = layout.GetChildAt(2) as LinearLayout;
                layout = layout.GetChildAt(1) as LinearLayout;

                layout.Background = null;
                #endregion

                UpdateIconDisplay();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(ExtendedSearchBar.IconDisplay):
                    UpdateIconDisplay();
                    break;
            }
        }

        void UpdateIconDisplay()
        {
            var searchIconId = Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
            var searchViewIcon = Control.FindViewById<ImageView>(searchIconId);

            var linearLayoutSearchView = (ViewGroup)searchViewIcon.Parent;

            //Remove the search icon from the view group
            linearLayoutSearchView.RemoveView(searchViewIcon);

            //add it once again to place it at the the view group elements according to the enum
            switch (ExtendedElement.IconDisplay)
            {
                case ExtendedSearchBarIconDisplay.None:
                    break;
                case ExtendedSearchBarIconDisplay.Right:
                    linearLayoutSearchView.AddView(searchViewIcon);
                    break;
                case ExtendedSearchBarIconDisplay.Left:
                default:
                    linearLayoutSearchView.AddView(searchViewIcon, 0);
                    break;
            }
        }
    }
}
