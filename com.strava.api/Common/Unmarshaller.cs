using System;
using Newtonsoft.Json;

namespace com.strava.api.Common
{
    public class Unmarshaller<T>
    {
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
