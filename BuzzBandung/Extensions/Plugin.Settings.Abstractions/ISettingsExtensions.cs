using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Plugin.Settings.Abstractions
{
    public static class ISettingsExtensions
    {
        public static T GetValueOrDefault<T>(this ISettings settings, string key, T @default) where T : class
        {
            string serialized = settings.GetValueOrDefault(key, string.Empty);
            T result = @default;

            try
            {
                JsonSerializerSettings serializeSettings = GetSerializerSettings();
                result = JsonConvert.DeserializeObject<T>(serialized);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deserializing settings value: {ex}");
            }

            return result;
        }


        public static bool AddOrUpdateValue<T>(this ISettings settings, string key, T obj) where T : class
        {
            try
            {
                JsonSerializerSettings serializeSettings = GetSerializerSettings();
                string serialized = JsonConvert.SerializeObject(obj, serializeSettings);

                return settings.AddOrUpdateValue(key, serialized);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error serializing settings value: {ex}");
            }

            return false;
        }

        static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}
