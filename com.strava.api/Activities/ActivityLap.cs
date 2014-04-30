using System;
using com.strava.api.Athletes;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    /// <summary>
    /// Laps are triggered by athletes using their respective devices, such as Garmin watches.
    /// </summary>
    public class ActivityLap
    {
        /// <summary>
        /// The Strava id of the lap.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Indicates the level of detail.
        /// </summary>
        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        /// <summary>
        /// The name of the lap.
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary>
        /// Contains basic information about the activity.
        /// </summary>
        [JsonProperty("activity")]
        public ActivityMeta Activity { get; set; }

        /// <summary>
        /// Contains basic information about the athlete.
        /// </summary>
        [JsonProperty("athlete")]
        public AthleteMeta Athlete { get; set; }

        /// <summary>
        /// The elapsed time of the lap in seconds.
        /// </summary>
        [JsonProperty("elapsed_time")]
        public int ElapsedTime { get; set; }

        /// <summary>
        /// The moving the of the lap in seconds.
        /// </summary>
        [JsonProperty("moving_time")]
        public int MovingTime { get; set; }

        [JsonProperty("start_date")]
        private String _start;

        /// <summary>
        /// The date and time when the lap was started.
        /// </summary>
        public DateTime Start
        {
            get
            {
                if (!String.IsNullOrEmpty(_start))
                    return DateTime.Parse(_start);

                return DateTime.MinValue;
            }
        }

        private String _startLocal;

        /// <summary>
        /// The local date and time when the lap was started.
        /// </summary>
        [JsonProperty("start_date_local")]
        public DateTime StartLocal
        {
            get
            {
                if (!String.IsNullOrEmpty(_startLocal))
                    return DateTime.Parse(_startLocal);

                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// The distance of the lap measured in meters.
        /// </summary>
        [JsonProperty("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// The start index point of the file.
        /// </summary>
        [JsonProperty("start_index")]
        public int StartIndex { get; set; }

        /// <summary>
        /// The end index point of the file.
        /// </summary>
        [JsonProperty("end_index")]
        public int EndIndex { get; set; }

        /// <summary>
        /// Gained meters in the lap.
        /// </summary>
        [JsonProperty("total_elevation_gain")]
        public float TotalElevationGain { get; set; }

        /// <summary>
        /// The average speed measured in meters per second.
        /// </summary>
        [JsonProperty("average_speed")]
        public float AverageSpeed { get; set; }

        /// <summary>
        /// The max speed measured in meters per second.
        /// </summary>
        [JsonProperty("max_speed")]
        public float MaxSpeed { get; set; }

        /// <summary>
        /// The average cadence.
        /// </summary>
        [JsonProperty("average_cadence")]
        public float AverageCadence { get; set; }

        /// <summary>
        /// The average power measured in watts.
        /// </summary>
        [JsonProperty("average_watts")]
        public float AveragePower { get; set; }

        /// <summary>
        /// The average heartrate in beats per minute.
        /// </summary>
        [JsonProperty("average_heartrate")]
        public float AverageHeartrate { get; set; }

        /// <summary>
        /// The max heartrate in beats per minute.
        /// </summary>
        [JsonProperty("max_heartrate")]
        public float MaxHeartrate { get; set; }

        /// <summary>
        /// The index of the lap.
        /// </summary>
        [JsonProperty("lap_index")]
        public int LapIndex { get; set; }
    }
}
