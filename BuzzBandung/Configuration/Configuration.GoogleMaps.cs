using System;
using Xamarin.Forms.GoogleMaps;

namespace BuzzBandung
{
    public partial class Configuration
    {
        public static class GoogleMaps
        {
            public const double DefaultZoomLevel = 13d;
            public static Distance DefaultDistanceInKm => Distance.FromMeters(3000);
        }
    }
}
