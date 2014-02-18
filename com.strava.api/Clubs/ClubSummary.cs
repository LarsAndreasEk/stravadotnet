using System;
using Newtonsoft.Json;

namespace com.strava.api.Clubs
{
    public class ClubSummary
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("profile_medium")]
        public String ProfileMedium { get; set; }

        [JsonProperty("profile")]
        public String Profile { get; set; }
    }
}
