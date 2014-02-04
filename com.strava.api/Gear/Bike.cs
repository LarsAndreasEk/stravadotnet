using System;
using Newtonsoft.Json;

namespace com.strava.api.Gear
{
    public class Bike
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("primary")]
        public bool IsPrimary { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("distance")]
        public float Distance { get; set; }

        [JsonProperty("brand_name")]
        public String Brand { get; set;}

        [JsonProperty("model_name")]
        public String Model { get; set; }

        [JsonProperty("frame_type")]
        public String FrameType { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }
}
