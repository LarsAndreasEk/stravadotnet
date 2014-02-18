using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class ActivityMeta
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
