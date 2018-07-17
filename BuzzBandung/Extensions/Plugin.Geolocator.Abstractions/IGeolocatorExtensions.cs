using System;
using System.Threading.Tasks;
using BuzzBandung;

namespace Plugin.Geolocator.Abstractions
{
    public static class IGeolocatorExtensions
    {
        public static async Task StartListeningAsync(this IGeolocator geolocator)
        {
            if (geolocator.IsListening)
                return;

            await geolocator.StartListeningAsync(Configuration.Geolocator.MinimumTime,
                                                 Configuration.Geolocator.MinimumDistance,
                                                 Configuration.Geolocator.IncludeHeading,
                                                 Configuration.Geolocator.ListenerSettings);
        }
    }
}
