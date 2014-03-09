using System;
using com.strava.api.Activities;
using Newtonsoft.Json;

namespace com.strava.api.Segments
{
    /// <summary>
    /// Represents a Strava segment.
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// The segment's id. Use this id to get the segment's leaderboard.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Resource state / level of details.
        /// </summary>
        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        /// <summary>
        /// The segment's name.
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary>
        /// The segment's activity type.
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
        /// The climb category of the segment. Values are HC, 1, 2, 3 or 4.
        /// </summary>
        [JsonProperty("climb_category")]
        public int Category { get; set; }

        /// <summary>
        /// The city where the segment is located in.
        /// </summary>
        [JsonProperty("city")]
        public String City { get; set; }

        /// <summary>
        /// The state where the segment is located in.
        /// </summary>
        [JsonProperty("state")]
        public String State { get; set; }

        /// <summary>
        /// The country where the segment is located in.
        /// </summary>
        [JsonProperty("country")]
        public String Country { get; set; }

        /// <summary>
        /// True, if the segment is private.
        /// </summary>
        [JsonProperty("private")]
        public Boolean IsPrivate { get; set; }

        /// <summary>
        /// The date when the segment was created.
        /// </summary>
        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        /// <summary>
        /// The date when the segment was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public String UpdatedAt { get; set; }

        /// <summary>
        /// The total elevation gain of the segment.
        /// </summary>
        [JsonProperty("total_elevation_gain")]
        public String TotalElevationGain { get; set; }

        /// <summary>
        /// A map with the segment's route.
        /// </summary>
        [JsonProperty("map")]
        public Map Map { get; set; }

        /// <summary>
        /// The effort count.
        /// </summary>
        [JsonProperty("effort_count")]
        public int EffortCount { get; set; }

        /// <summary>
        /// The number of athletes that run or rode this segment.
        /// </summary>
        [JsonProperty("athlete_count")]
        public int AthleteCount { get; set; }

        /// <summary>
        /// True if the segment was marked as hazardous.
        /// </summary>
        [JsonProperty("hazardous")]
        public Boolean IsHazardous { get; set; }

        /// <summary>
        /// The personal record time.
        /// </summary>
        [JsonProperty("pr_time")]
        public int PersonalRecordTime { get; set; }

        /// <summary>
        /// The personal record distance.
        /// </summary>
        [JsonProperty("pr_distance")]
        public float PersonalRecordDistance { get; set; }

        /// <summary>
        /// True if the segment is starred by the currently authenticated athlete.
        /// </summary>
        [JsonProperty("starred")]
        public Boolean IsStarred { get; set; }
    }
}
