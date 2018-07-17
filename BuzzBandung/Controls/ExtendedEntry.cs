﻿using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BuzzBandung.Controls
{
    public class ExtendedEntry : Entry
    {
        public ExtendedEntry()
        {
            Focused += OnFocused;
            Unfocused += OnUnfocused;

            LineColorToApply = GetNormalStateLineColor();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsValidProperty.PropertyName)
            {
                CheckValidity();
            }
        }

        #region Validatable Extensions

        Color _lineColorToApply;
        public Color LineColorToApply
        {
            get { return _lineColorToApply; }
            private set
            {
                _lineColorToApply = value;
                OnPropertyChanged(nameof(LineColorToApply));
            }
        }

        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create("LineColor", typeof(Color), typeof(ExtendedEntry), Color.Default);

        public Color LineColor
        {
            get => (Color)GetValue(LineColorProperty);
            set => SetValue(LineColorProperty, value);
        }

        public static readonly BindableProperty FocusLineColorProperty =
            BindableProperty.Create("FocusLineColor", typeof(Color), typeof(ExtendedEntry), Color.Default);

        public Color FocusLineColor
        {
            get => (Color)GetValue(FocusLineColorProperty);
            set => SetValue(FocusLineColorProperty, value);
        }

        public static readonly BindableProperty InvalidColorProperty =
            BindableProperty.Create("InvalidColor", typeof(Color), typeof(ExtendedEntry), Color.Default);

        public Color InvalidColor
        {
            get => (Color)GetValue(InvalidColorProperty);
            set => SetValue(InvalidColorProperty, value);
        }

        public static readonly BindableProperty InvalidIconProperty =
            BindableProperty.Create("InvalidIcon", typeof(FileImageSource), typeof(ExtendedEntry), null);

        public FileImageSource InvalidIcon
        {
            get => (FileImageSource)GetValue(InvalidIconProperty);
            set => SetValue(InvalidIconProperty, value);
        }

        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create("IsValid", typeof(bool), typeof(ExtendedEntry), true);

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        void OnFocused(object sender, FocusEventArgs e)
        {
            IsValid = true;
            LineColorToApply = GetFocusStateLineColor();
        }

        void OnUnfocused(object sender, FocusEventArgs e) => LineColorToApply = GetNormalStateLineColor();

        void CheckValidity()
        {
            if (!IsValid) LineColorToApply = InvalidColor;
        }

        Color GetNormalStateLineColor() => LineColor != Color.Default ? LineColor : TextColor;
        Color GetFocusStateLineColor() => FocusLineColor != Color.Default ? FocusLineColor : GetNormalStateLineColor();
        Color GetInvalidStateLineColor() => InvalidColor != Color.Default ? InvalidColor : GetNormalStateLineColor();

        #endregion
    }
}
