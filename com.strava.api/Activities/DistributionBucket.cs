using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    /// <summary>
    /// This class represents a distribution bucket. It holds information about the max and min value and the time 
    /// spent in this zone.
    /// </summary>
    public class DistributionBucket
    {
        /// <summary>
        /// Maxvalue of the bucket.
        /// </summary>
        [JsonProperty("max")]
        public int Maximum { get; set; }

        /// <summary>
        /// Min value of the bucket.
        /// </summary>
        [JsonProperty("min")]
        public int Minimum { get; set; }

        /// <summary>
        /// Time spent in this zone.
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }
    }
}
