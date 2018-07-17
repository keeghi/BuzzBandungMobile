using System;
using Android.Content;
using Android.Graphics;
using BuzzBandung.Controls;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(ExtendedFrame), typeof(BuzzBandung.Droid.Renderers.ExtendedFrameRenderer))]
namespace BuzzBandung.Droid.Renderers
{
    public class ExtendedFrameRenderer : FrameRenderer
    {
        public ExtendedFrame ExtendedElement => Element as ExtendedFrame;

        public ExtendedFrameRenderer(Context context) : base(context)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            DrawShadow(canvas);
            base.OnDraw(canvas);
        }

        void DrawShadow(Canvas canvas)
        {
            using (var paint = new Paint() { AntiAlias = true })
            using (var path = new Path())
            using (Path.Direction direction = Path.Direction.Cw)
            using (var rect = new RectF(ExtendedElement.ShadowOffsetX,
                                        ExtendedElement.ShadowOffsetY,
                                        this.Width + ExtendedElement.ShadowOffsetX,
                                        this.Height + ExtendedElement.ShadowOffsetY))
            {
                float rx = Context.ToPixels(ExtendedElement.CornerRadius);
                float ry = Context.ToPixels(ExtendedElement.CornerRadius);
                path.AddRoundRect(rect, rx, ry, direction);

                int shadowOpacity = (int)(255 * ExtendedElement.ShadowOpacity);
                paint.Color = Android.Graphics.Color.Argb(shadowOpacity, 0, 0, 0);
                paint.SetMaskFilter(new BlurMaskFilter(ExtendedElement.ShadowRadius, BlurMaskFilter.Blur.Normal));

                canvas.DrawPath(path, paint);
                //canvas.DrawOval(rect, paint);
            }
        }
    }
}
