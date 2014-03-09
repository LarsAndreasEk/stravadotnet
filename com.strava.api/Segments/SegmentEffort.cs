using System;
using com.strava.api.Activities;
using com.strava.api.Athletes;
using Newtonsoft.Json;

namespace com.strava.api.Segments
{
    /// <summary>
    /// A segment effort represents an athlete’s attempt at a segment. It can also be 
    /// thought of as a portion of a ride that covers a segment. The object is returned in 
    /// summary or detailed representations. They are currently the same.
    /// </summary>
    public class SegmentEffort
    {
        /// <summary>
        /// The segment effort's id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Indicates level of detail
        /// </summary>
        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        /// <summary>
        /// The name of the segment.
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary>
        /// Detailed segment object.
        /// </summary>
        [JsonProperty("segment")]
        public Segment Segment { get; set; }

        /// <summary>
        /// Meta information about the activity.
        /// </summary>
        [JsonProperty("activity")]
        public ActivityMeta Activity { get; set; }

        /// <summary>
        /// Meta information about the athlete.
        /// </summary>
        [JsonProperty("athlete")]
        public AthleteMeta Athlete { get; set; }

        /// <summary>
        /// 1-10 rank on segment at time of upload
        /// </summary>
        [JsonProperty("kom_rank")]
        public int? KingOfMountainRank { get; set; }

        /// <summary>
        /// 1-3 personal record on segment at time of upload
        /// </summary>
        [JsonProperty("pr_rank")]
        public int? PersonalRecordRank { get; set; }

        /// <summary>
        /// Moving time in seconds.
        /// </summary>
        [JsonProperty("moving_time")]
        public int MovingTime { get; set; }

        /// <summary>
        /// Elapsed time in seconds.
        /// </summary>
        [JsonProperty("elapsed_time")]
        public int ElapsedTime { get; set; }

        /// <summary>
        /// Start date and time.
        /// </summary>
        [JsonProperty("start_date")]
        public String StartDate { get; set; }

        /// <summary>
        /// Local start date and time.
        /// </summary>
        [JsonProperty("start_date_local")]
        public String StartDateLocal { get; set; }

        /// <summary>
        /// Distance in meters.
        /// </summary>
        [JsonProperty("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// The activity stream index of the start of this effort
        /// </summary>
        [JsonProperty("start_index")]
        public int StartIndex { get; set; }

        /// <summary>
        /// The activity stream index of the end of this effort
        /// </summary>
        [JsonProperty("end_index")]
        public int EndIndex { get; set; }
    }
}
