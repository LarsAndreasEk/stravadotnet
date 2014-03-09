using System;
using com.strava.api.Activities;
using com.strava.api.Athletes;
using Newtonsoft.Json;

namespace com.strava.api.Segments
{
    /// <summary>
    /// Represents a Strava segment effort.
    /// </summary>
    public class SegmentEffort
    {
        /// <summary>
        /// The segment effort's id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("segment")]
        public Segment Segment { get; set; }

        [JsonProperty("activity")]
        public ActivityMeta Activity { get; set; }

        [JsonProperty("athlete")]
        public AthleteMeta Athlete { get; set; }

        [JsonProperty("kom_rank")]
        public int? KingOfMountainRank { get; set; }

        [JsonProperty("pr_rank")]
        public int? PersonalRecordRank { get; set; }

        [JsonProperty("moving_time")]
        public int MovingTime { get; set; }

        [JsonProperty("elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonProperty("start_date")]
        public String StartDate { get; set; }

        [JsonProperty("start_date_local")]
        public String StartDateLocal { get; set; }

        [JsonProperty("distance")]
        public float Distance { get; set; }

        [JsonProperty("start_index")]
        public int StartIndex { get; set; }

        [JsonProperty("end_index")]
        public int EndIndex { get; set; }
    }
}
