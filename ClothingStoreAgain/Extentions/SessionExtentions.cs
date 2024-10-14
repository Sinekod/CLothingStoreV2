using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
namespace ClothingStoreAgain.Extentions
{
    public static class SessionExtentions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            // Serialize the object to a JSON string
            var jsonString = JsonConvert.SerializeObject(value);

            // Store the serialized object in the session as a string
            session.SetString(key, jsonString);
        }

        // Retrieve a complex object from the session
        public static T Get<T>(this ISession session, string key)
        {
            // Get the serialized object from the session
            var jsonString = session.GetString(key);

            // If the key doesn't exist in the session, return the default value (null for reference types)
            if (jsonString == null)
            {
                return default(T);
            }

            // Deserialize the JSON string back into an object of type T
            return JsonConvert.DeserializeObject<T>(jsonString);
        }


    }
}
