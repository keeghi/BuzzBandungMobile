using System;
using Xamarin.Forms;

namespace BuzzBandung.Controls
{
    public class ExtendedSearchBar : SearchBar
    {
        public static readonly BindableProperty IconDisplayProperty =
            BindableProperty.Create("IconDisplay", typeof(ExtendedSearchBarIconDisplay), typeof(ExtendedSearchBar), ExtendedSearchBarIconDisplay.Left);

        public ExtendedSearchBarIconDisplay IconDisplay
        {
            get => (ExtendedSearchBarIconDisplay)GetValue(IconDisplayProperty);
            set => SetValue(IconDisplayProperty, value);
        }
    }

    public enum ExtendedSearchBarIconDisplay : short
    {
        None,
        Left,
        Right
    }
}
