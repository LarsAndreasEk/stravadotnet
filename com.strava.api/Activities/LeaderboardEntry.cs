using System;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class LeaderboardEntry
    {
        [JsonProperty("athlete_name")]
        public String AthleteName { get; set; }

        [JsonProperty("athlete_id")]
        public long AthleteId { get; set; }

        [JsonProperty("athlete_gender")]
        public String AthleteGender { get; set; }

        [JsonProperty("average_hr")]
        public float? AverageHeartrate { get; set; }

        [JsonProperty("average_watts")]
        public float? AveragePower { get; set; }

        [JsonProperty("distance")]
        public float Distance { get; set; }

        [JsonProperty("elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonProperty("moving_time")]
        public int MovingTime { get; set; }

        [JsonProperty("start_date")]
        public String StartDate { get; set; }

        [JsonProperty("start_date_local")]
        public String StartDateLocal { get; set; }

        [JsonProperty("activity_id")]
        public long ActivityId { get; set; }

        [JsonProperty("effort_id")]
        public long EffortId { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("athlete_profile")]
        public String AthleteProfile { get; set; }
    }
}
