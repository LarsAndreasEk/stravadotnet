using System;
using Newtonsoft.Json;

namespace com.strava.api.Gear
{
    /// <summary>
    /// This class represents gear.
    /// </summary>
    public class Gear
    {
        /// <summary>
        /// Id of the gear item.
        /// </summary>
        [JsonProperty("id")]
        public String Id { get; set; }

        /// <summary>
        /// Is the gear the athlete's primary gear?
        /// </summary>
        [JsonProperty("primary")]
        public bool IsPrimary { get; set; }

        /// <summary>
        /// The gear's name.
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary>
        /// The gear's distance.
        /// </summary>
        [JsonProperty("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// The gear's brand name.
        /// </summary>
        [JsonProperty("brand_name")]
        public String Brand { get; set;}

        /// <summary>
        /// The gear's model.
        /// </summary>
        [JsonProperty("model_name")]
        public String Model { get; set; }

        /// <summary>
        /// The type of bike.
        /// </summary>
        [JsonProperty("frame_type")] 
        private string _frameType;

        /// <summary>
        /// The type of bike.
        /// </summary>
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

        /// <summary>
        /// The gear's description.
        /// </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary>
        /// The gear's resource state.
        /// </summary>
        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }
}
