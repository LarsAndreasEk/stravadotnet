using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class ActivityMeta
    {
        /// <summary>
        /// The id of the activity. This id is provided by Strava at upload.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
