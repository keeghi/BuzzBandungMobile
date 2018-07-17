using System.ComponentModel;
using BuzzBandung.Controls;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedFrame), typeof(BuzzBandung.iOS.Renderers.ExtendedFrameRenderer))]
namespace BuzzBandung.iOS.Renderers
{
    public class ExtendedFrameRenderer : VisualElementRenderer<Frame>
    {
        public ExtendedFrame ExtendedElement => Element as ExtendedFrame;

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
                SetupLayer();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName ||
                e.PropertyName == Xamarin.Forms.Frame.BorderColorProperty.PropertyName ||
                e.PropertyName == Xamarin.Forms.Frame.HasShadowProperty.PropertyName ||
                e.PropertyName == Xamarin.Forms.Frame.CornerRadiusProperty.PropertyName ||
                e.PropertyName == ExtendedFrame.ShadowRadiusProperty.PropertyName ||
                e.PropertyName == ExtendedFrame.ShadowOpacityProperty.PropertyName ||
                e.PropertyName == ExtendedFrame.ShadowOffsetXProperty.PropertyName ||
                e.PropertyName == ExtendedFrame.ShadowOffsetYProperty.PropertyName)
                SetupLayer();
        }

        void SetupLayer()
        {
            Layer.CornerRadius = Element.CornerRadius;

            if (Element.BackgroundColor == Color.Default)
                Layer.BackgroundColor = UIColor.White.CGColor;
            else
                Layer.BackgroundColor = Element.BackgroundColor.ToCGColor();

            if (Element.HasShadow)
            {
                Layer.ShadowRadius = ExtendedElement.ShadowRadius;
                Layer.ShadowColor = UIColor.Black.CGColor;
                Layer.ShadowOpacity = ExtendedElement.ShadowOpacity;
                Layer.ShadowOffset = new CGSize(ExtendedElement.ShadowOffsetX, ExtendedElement.ShadowOffsetY);
            }
            else
                Layer.ShadowOpacity = 0;

            if (Element.BorderColor == Color.Default)
                Layer.BorderColor = UIColor.Clear.CGColor;
            else
            {
                Layer.BorderColor = Element.BorderColor.ToCGColor();
                Layer.BorderWidth = 1;
            }

            Layer.RasterizationScale = UIScreen.MainScreen.Scale;
            Layer.ShouldRasterize = true;

        }
    }
}
