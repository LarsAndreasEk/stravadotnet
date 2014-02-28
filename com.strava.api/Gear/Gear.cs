using System;
using Newtonsoft.Json;

namespace com.strava.api.Gear
{
    public class Gear
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
        private string _frameType;

        public BikeType FrameType
        {
            get
            {
                if (_frameType.Equals("1"))
                {
                    return BikeType.Mountain;
                }
                if (_frameType.Equals("2"))
                {
                    return BikeType.Cross;
                }
                if (_frameType.Equals("3"))
                {
                    return BikeType.Road;
                }
                if (_frameType.Equals("4"))
                {
                    return BikeType.Timetrial;
                }

                return BikeType.Road;
            }
        }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }
}
