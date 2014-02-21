using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class DistributionBucket
    {
        [JsonProperty("max")]
        public int Maximum { get; set; }

        [JsonProperty("min")]
        public int Minimum { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }
}
