using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using BuzzBandung.Controls;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(BuzzBandung.iOS.Renderers.ExtendedEntryRenderer))]
namespace BuzzBandung.iOS.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntry ExtendedElement => Element as ExtendedEntry;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.TextColor = Element.TextColor.ToUIColor();

                UpdateLineColor();
                UpdateCursorColor();
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            LineLayer lineLayer = GetOrAddLineLayer();
            lineLayer.Frame = new CGRect(0, Frame.Size.Height - LineLayer.LineHeight, Control.Frame.Size.Width, LineLayer.LineHeight);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(ExtendedEntry.LineColorToApply):
                    UpdateLineColor();
                    break;
                case nameof(Entry.TextColorProperty.PropertyName):
                    UpdateCursorColor();
                    break;
            }
        }

        void UpdateCursorColor()
        {
            Control.TintColor = Element.TextColor.ToUIColor();
        }

        void UpdateLineColor()
        {
            LineLayer lineLayer = GetOrAddLineLayer();
            lineLayer.BorderColor = ExtendedElement.LineColorToApply.ToCGColor();
        }

        LineLayer GetOrAddLineLayer()
        {
            var lineLayer = Control.Layer.Sublayers?.OfType<LineLayer>().FirstOrDefault();

            if (lineLayer == null)
            {
                lineLayer = new LineLayer();

                Control.Layer.AddSublayer(lineLayer);
                Control.Layer.MasksToBounds = true;
            }

            return lineLayer;
        }
    }

    public class LineLayer : CALayer
    {
        public static nfloat LineHeight = 2f;

        public LineLayer()
        {
            BorderWidth = LineHeight;
        }
    }
}
