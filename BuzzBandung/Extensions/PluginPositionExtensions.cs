using System;
using GeolocatorPosition = Plugin.Geolocator.Abstractions.Position;
using GoogleMapsPosition = Xamarin.Forms.GoogleMaps.Position;

namespace BuzzBandung.Extensions
{
    public static class PluginPositionExtensions
    {
        public static GoogleMapsPosition ToGoogleMaps(this GeolocatorPosition position)
        {
            if (position == null)
                return default(GoogleMapsPosition);

            return new GoogleMapsPosition(position.Latitude, position.Longitude);
        }
    }
}
