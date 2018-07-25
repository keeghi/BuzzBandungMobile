using GeolocatorPosition = Plugin.Geolocator.Abstractions.Position;
using GoogleMapsPosition = Xamarin.Forms.GoogleMaps.Position;
using GoogleMapsMapSpan = Xamarin.Forms.GoogleMaps.MapSpan;

namespace BuzzBandung.Extensions
{
    public static class PluginPositionExtensions
    {
        public static GoogleMapsPosition ToGoogleMapsPosition(this GeolocatorPosition position)
        {
            if (position == null)
                return default(GoogleMapsPosition);

            return new GoogleMapsPosition(position.Latitude, position.Longitude);
        }

        public static GoogleMapsMapSpan ToGoogleMapsMapSpan(this GeolocatorPosition position,
                                                            double latitudeDegrees = 0,
                                                            double longitudeDegrees = 0)
        {
            if (position == null)
                return default(GoogleMapsMapSpan);

            return GoogleMapsMapSpan.FromCenterAndRadius(position.ToGoogleMapsPosition(),
                                                         Configuration.GoogleMaps.DefaultDistanceInKm);
        }
    }
}
