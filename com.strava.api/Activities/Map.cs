using System;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class Map
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("polyline")]
        public String Polyline { get; set; }

        [JsonProperty("summary_polyline")]
        public String SummaryPolyline { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }
}
