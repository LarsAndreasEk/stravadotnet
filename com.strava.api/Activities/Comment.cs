using System;
using com.strava.api.Athletes;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class Comment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("activity_id")]
        public long ActivityId { get; set; }

        [JsonProperty("text")]
        public String Text { get; set; }

        [JsonProperty("athlete")]
        public Athlete Athlete { get; set; }

        [JsonProperty("created_at")]
        public String TimeCreated { get; set; }
    }
}
