
using System.ComponentModel;
using BuzzBandung.Controls;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedSearchBar), typeof(BuzzBandung.iOS.Renderers.ExtendedSearchBarRenderer))]
namespace BuzzBandung.iOS.Renderers
{
    public class ExtendedSearchBarRenderer : SearchBarRenderer
    {
        public ExtendedSearchBar ExtendedElement => Element as ExtendedSearchBar;

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                UpdateIconDisplay();
                Control.Layer.BorderWidth = 1;
                Control.Layer.BorderColor = Element.BackgroundColor.ToCGColor();
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
            //add it once again to place it at the the view group elements according to the enum
            switch (ExtendedElement.IconDisplay)
            {
                case ExtendedSearchBarIconDisplay.None:
                    break;
                case ExtendedSearchBarIconDisplay.Right:
                    break;
                case ExtendedSearchBarIconDisplay.Left:
                default:
                    break;
            }
        }
    }
}
