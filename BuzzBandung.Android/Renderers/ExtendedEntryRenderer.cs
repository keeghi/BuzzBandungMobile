using System.ComponentModel;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using BuzzBandung.Controls;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(BuzzBandung.Droid.Renderers.ExtendedEntryRenderer))]
namespace BuzzBandung.Droid.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntry ExtendedElement => Element as ExtendedEntry;

        public ExtendedEntryRenderer(Context context) : base(context) => AutoPackage = false;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.InputType |= Android.Text.InputTypes.TextFlagNoSuggestions;
                Control.SetTextColor(Element.TextColor.ToAndroid());

                UpdateLineColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(ExtendedEntry.LineColorToApply):
                    UpdateLineColor();
                    break;
                case nameof(ExtendedEntry.InvalidColor):
                case nameof(ExtendedEntry.InvalidIcon):
                case nameof(ExtendedEntry.IsValidProperty):
                    UpdateValidity();
                    break;
            }
        }

        void UpdateValidity()
        {
            if (!ExtendedElement.IsValid)
            {
                var invalidIcon = Context.GetDrawable(ExtendedElement.InvalidIcon);

                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, invalidIcon, null);
            }
            else
            {
                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, null, null);
            }
        }

        void UpdateLineColor()
        {
            Control?.Background?.SetColorFilter(ExtendedElement.LineColorToApply.ToAndroid(),
                                                Android.Graphics.PorterDuff.Mode.SrcAtop);
        }
    }
}

