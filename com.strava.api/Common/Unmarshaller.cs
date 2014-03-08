using System;
using Newtonsoft.Json;

namespace com.strava.api.Common
{
    /// <summary>
    /// COnverts a Json string to an object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Unmarshaller<T>
    {
        /// <summary>
        /// Converts a Json string to an object.
        /// </summary>
        /// <param name="json">The json string.</param>
        /// <returns>The converted object of type T.</returns>
        public static T Unmarshal(String json)
        {
            if (String.IsNullOrEmpty(json))
            {
                throw new ArgumentException("The json string is null or empty.");
            }

            T deserializedObject = JsonConvert.DeserializeObject<T>(json);
            return deserializedObject;
        }
    }
}
