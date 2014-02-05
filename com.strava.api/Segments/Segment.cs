using System;
using com.strava.api.Activities;
using Newtonsoft.Json;

namespace com.strava.api.Segments
{
    public class Segment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("activity_type")]
        public String ActivityType { get; set; }

        [JsonProperty("distance")]
        public float Distance { get; set; }

        [JsonProperty("average_grade")]
        public float AverageGrade { get; set; }

        [JsonProperty("maximum_grade")]
        public float MaxGrade { get; set; }

        [JsonProperty("elevation_high")]
        public float MaxElevation { get; set; }

        [JsonProperty("elevation_low")]
        public float MinElevation { get; set; }

        [JsonProperty("climb_category")]
        public int Category { get; set; }

        [JsonProperty("city")]
        public String City { get; set; }

        [JsonProperty("state")]
        public String State { get; set; }

        [JsonProperty("country")]
        public String Country { get; set; }

        [JsonProperty("private")]
        public Boolean IsPrivate { get; set; }

        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public String UpdatedAt { get; set; }

        [JsonProperty("total_elevation_gain")]
        public String TotalElevationGain { get; set; }

        //[JsonProperty("map")]
        //public Map Map { get; set; }

        [JsonProperty("effort_count")]
        public int EffortCount { get; set; }

        [JsonProperty("athlete_count")]
        public int AthleteCount { get; set; }

        [JsonProperty("hazardous")]
        public Boolean IsHazardous { get; set; }

        [JsonProperty("pr_time")]
        public int PersonalRecordTime { get; set; }

        [JsonProperty("pr_distance")]
        public float PersonalRecordDistance { get; set; }

        [JsonProperty("starred")]
        public Boolean IsStarred { get; set; }
    }
}
