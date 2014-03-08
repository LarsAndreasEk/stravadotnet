using System;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    /// <summary>
    /// This class contains information about the route of an activity.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// The map id.
        /// </summary>
        [JsonProperty("id")]
        public String Id { get; set; }

        /// <summary>
        /// The map's polyline. This polyline can be converted to coordinates.
        /// </summary>
        [JsonProperty("polyline")]
        public String Polyline { get; set; }

        /// <summary>
        /// A summary of the polyline.
        /// </summary>
        [JsonProperty("summary_polyline")]
        public String SummaryPolyline { get; set; }

        /// <summary>
        /// The resource state gives information about the level of details of the map.
        /// </summary>
        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }
}
