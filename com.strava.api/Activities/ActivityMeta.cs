using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    /// <summary>
    /// Represents an athlete. Only holds basic information.
    /// </summary>
    public class ActivityMeta
    {
        /// <summary>
        /// The id of the activity. This id is provided by Strava at upload.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
