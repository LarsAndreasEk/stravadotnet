using System;
using Newtonsoft.Json;

namespace com.strava.api.Segments
{
    /// <summary>
    /// Represents a less detailed version of a segment.
    /// </summary>
    public class SegmentSummary
    {
        /// <summary>
        /// The id provided by Strava.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The resource state.
        /// </summary>
        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        /// <summary>
        /// The name of the segment.
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary>
        /// The type of activity.
        /// </summary>
        [JsonProperty("activity_type")]
        public String ActivityType { get; set; }

        /// <summary>
        /// The segment's distance.
        /// </summary>
        [JsonProperty("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// The average grade of the segment.
        /// </summary>
        [JsonProperty("average_grade")]
        public float AverageGrade { get; set; }

        /// <summary>
        /// The max grade of the segment.
        /// </summary>
        [JsonProperty("maximum_grade")]
        public float MaxGrade { get; set; }

        /// <summary>
        /// The segment's highest elevation.
        /// </summary>
        [JsonProperty("elevation_high")]
        public float MaxElevation { get; set; }

        /// <summary>
        /// The segment's lowest elevation.
        /// </summary>
        [JsonProperty("elevation_low")]
        public float MinElevation { get; set; }

        /// <summary>
        /// the climb category of the segment.
        /// </summary>
        [JsonProperty("climb_category")]
        public int Category { get; set; }

        /// <summary>
        /// The city where this segment is located in.
        /// </summary>
        [JsonProperty("city")]
        public String City { get; set; }

        /// <summary>
        /// The state where this segment is located in.
        /// </summary>
        [JsonProperty("state")]
        public String State { get; set; }

        /// <summary>
        /// The country where this segment is located in.
        /// </summary>
        [JsonProperty("country")]
        public String Country { get; set; }

        /// <summary>
        /// True if this segment is private.
        /// </summary>
        [JsonProperty("private")]
        public Boolean IsPrivate { get; set; }

        /// <summary>
        /// The personal record time in seconds.
        /// </summary>
        [JsonProperty("pr_time")]
        public int PersonalRecordTime { get; set; }

        /// <summary>
        /// The personal record distance in meters.
        /// </summary>
        [JsonProperty("pr_distance")]
        public float PersonalRecordDistance { get; set; }
    }
}
