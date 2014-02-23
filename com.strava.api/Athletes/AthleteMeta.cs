using Newtonsoft.Json;

namespace com.strava.api.Athletes
{
    public class AthleteMeta
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }
}
