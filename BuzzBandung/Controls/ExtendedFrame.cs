using System;
using Xamarin.Forms;

namespace BuzzBandung.Controls
{
    public class ExtendedFrame : Frame
    {
        public static readonly BindableProperty ShadowRadiusProperty =
            BindableProperty.Create("ShadowRadius", typeof(int), typeof(ExtendedFrame), 10);

        public int ShadowRadius
        {
            get => (int)GetValue(ShadowRadiusProperty);
            set => SetValue(ShadowRadiusProperty, value);
        }

        public static readonly BindableProperty ShadowOpacityProperty =
            BindableProperty.Create("ShadowOpacity", typeof(float), typeof(ExtendedFrame), .5f);

        public float ShadowOpacity
        {
            get => (float)GetValue(ShadowOpacityProperty);
            set => SetValue(ShadowOpacityProperty, value);
        }

        public static readonly BindableProperty ShadowOffsetXProperty =
            BindableProperty.Create("ShadowOffsetX", typeof(int), typeof(ExtendedFrame), 0);

        public int ShadowOffsetX
        {
            get => (int)GetValue(ShadowOffsetXProperty);
            set => SetValue(ShadowOffsetXProperty, value);
        }

        public static readonly BindableProperty ShadowOffsetYProperty =
            BindableProperty.Create("ShadowOffsetY", typeof(int), typeof(ExtendedFrame), 0);

        public int ShadowOffsetY
        {
            get => (int)GetValue(ShadowOffsetYProperty);
            set => SetValue(ShadowOffsetYProperty, value);
        }
    }
}
