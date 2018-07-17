using System;
using Plugin.Geolocator.Abstractions;

namespace BuzzBandung
{
    public partial class Configuration
    {
        public static class Geolocator
        {
            public static TimeSpan MinimumTime => TimeSpan.FromSeconds(30);
            public static double MinimumDistance => 10;
            public static bool IncludeHeading => false;

            public static ListenerSettings ListenerSettings =>
                new ListenerSettings
                {
                    ActivityType = ActivityType.AutomotiveNavigation,
                    AllowBackgroundUpdates = true,
                    DeferLocationUpdates = true,
                    DeferralDistanceMeters = MinimumDistance,
                    DeferralTime = MinimumTime,
                    ListenForSignificantChanges = false,
                    PauseLocationUpdatesAutomatically = true
                };
        }
    }
}
