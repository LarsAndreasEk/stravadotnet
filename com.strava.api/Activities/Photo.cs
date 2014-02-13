using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class Photo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("activity_id")]
        public long ActivityId { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("ref")]
        public String ImageUrl { get; set; }

        [JsonProperty("uid")]
        public String ExternalUid { get; set; }

        [JsonProperty("caption")]
        public String Caption { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("uploaded_at")]
        public String UploadedAt { get; set; }

        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        [JsonProperty("location")]
        public List<double> Location { get; set; }
    }
}
