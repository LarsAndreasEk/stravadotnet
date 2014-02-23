using System;
using Newtonsoft.Json;

namespace com.strava.api.Gear
{
    public class GearSummary
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("primary")]
        public Boolean IsPrimary { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("distance")]
        public float Distance { get; set; }

        [JsonProperty("rsource_state")]
        public int ResourceState { get; set; }
    }
}
