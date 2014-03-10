using System;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    /// <summary>
    /// This class contains information about a single leaderboard entry.
    /// </summary>
    public class LeaderboardEntry
    {
        /// <summary>
        /// The full name of the athlete.
        /// </summary>
        [JsonProperty("athlete_name")]
        public String AthleteName { get; set; }

        /// <summary>
        /// The athlete id. Use this id to load additional information about the athlete.
        /// </summary>
        [JsonProperty("athlete_id")]
        public long AthleteId { get; set; }

        /// <summary>
        /// The athlete's gender.
        /// </summary>
        [JsonProperty("athlete_gender")]
        public String AthleteGender { get; set; }

        /// <summary>
        /// The average heartrate.
        /// </summary>
        [JsonProperty("average_hr")]
        public float? AverageHeartrate { get; set; }

        /// <summary>
        /// The average power.
        /// </summary>
        [JsonProperty("average_watts")]
        public float? AveragePower { get; set; }

        /// <summary>
        /// The distance ridden on this single attempt.
        /// </summary>
        [JsonProperty("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// The elapsed time.
        /// </summary>
        [JsonProperty("elapsed_time")]
        public int ElapsedTime { get; set; }

        /// <summary>
        /// The moving time.
        /// </summary>
        [JsonProperty("moving_time")]
        public int MovingTime { get; set; }

        /// <summary>
        /// The start date.
        /// </summary>
        [JsonProperty("start_date")]
        public String StartDate { get; set; }

        /// <summary>
        /// Local start date.
        /// </summary>
        [JsonProperty("start_date_local")]
        public String StartDateLocal { get; set; }

        /// <summary>
        /// The activity id. use this id to load additional information about the activity.
        /// </summary>
        [JsonProperty("activity_id")]
        public long ActivityId { get; set; }

        /// <summary>
        /// The effort id. Use this id to load additional information about the segment effort.
        /// </summary>
        [JsonProperty("effort_id")]
        public long EffortId { get; set; }

        /// <summary>
        /// The rank of athlete.
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Url to a picture of the athlete. If not null or empty, you can use the ImageLoader to load the picture from the Url.
        /// </summary>
        [JsonProperty("athlete_profile")]
        public String AthleteProfile { get; set; }

        /// <summary>
        /// Returns the total seconds in a more convenient TimeSpan object.
        /// </summary>
        public TimeSpan Time
        {
            get
            {
                return TimeSpan.FromSeconds(ElapsedTime);
            }
        }

        public override string ToString()
        {
            return String.Format("{0}:\t{1}:{2}:{3}\t{4}",
                Rank,
                Time.Hours.ToString("D2"),
                Time.Minutes.ToString("D2"),
                Time.Seconds.ToString("D2"),
                AthleteName
                );
        }
    }
}
