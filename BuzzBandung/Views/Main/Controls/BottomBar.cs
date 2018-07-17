using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BuzzBandung.Views.Main.Controls
{
    public class BottomBar : ScrollView
    {
        public static readonly BindableProperty SpacingProperty = BindableProperty.Create("Spacing", typeof(int), typeof(BottomBar), 0, propertyChanged: OnSpacingChanged);
        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create("ItemSource", typeof(IEnumerable), typeof(BottomBar), null, propertyChanged: GetEnumerator);

        private StackLayout content;

        public BottomBar()
        {
            InitializeComponent();
        }

        public int Spacing
        {
            get => (int)GetValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }

        public IEnumerable ItemSource
        {
            get => (IEnumerable)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }

        private void InitializeComponent()
        {
            BackgroundColor = Color.White;
            Orientation = ScrollOrientation.Horizontal;

            content = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.White
            };

            Content = content;
        }

        private static void OnSpacingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((BottomBar)bindable).content.Spacing = (int)newValue;
        }

        private static void GetEnumerator(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is BottomBar layout)
            {
                foreach (object child in (newValue as IEnumerable))
                {
                    var view = (View)new DataTemplate(typeof(BottomBarItemTemplate)).CreateContent();
                    view.BindingContext = child;

                    if (layout.Content is StackLayout stackLayout)
                        stackLayout.Children.Add(view);
                }
            }
        }
    }
}
