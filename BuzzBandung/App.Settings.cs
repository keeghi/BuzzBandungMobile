using Plugin.Geolocator.Abstractions;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BuzzBandung
{
    public partial class App
    {
        public static class Settings
        {
            private static ISettings settings => CrossSettings.Current;

            public static Position CurrentPosition
            {
                get => settings.GetValueOrDefault(nameof(CurrentPosition), default(Position));
                set => settings.AddOrUpdateValue(nameof(CurrentPosition), value);
            }
        }
    }
}
