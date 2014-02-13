using System;
using System.Collections.Generic;
using System.Linq;
using com.strava.api.Common;
using com.strava.api.Segments;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class Activity
    {
        [JsonProperty("id")]
        public String Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("external_id")]
        public String ExternalId { get; set; }
        [JsonProperty("distance")]
        public float Distance { get; set; }
        [JsonProperty("moving_time")]
        public int MovingTime { get; set; }
        [JsonProperty("elapsed_time")]
        public int ElapsedTime { get; set; }
        [JsonProperty("total_elevation_gain")]
        public float ElevationGain { get; set; }
        [JsonProperty("calories")]
        public float Calories { get; set; }
        [JsonProperty("has_kudoed")]
        public bool HasKudoed { get; set; }
        [JsonProperty("average_heartrate")]
        public float AverageHeartrate { get; set; }
        [JsonProperty("max_heartrate")]
        public float MaxHeartrate { get; set; }
        [JsonProperty("truncated")]
        public int? Truncated { get; set; }
        [JsonProperty("city")]
        public String City { get; set; }
        [JsonProperty("state")]
        public String State { get; set; }
        [JsonProperty("country")]
        public String Country { get; set; }
        [JsonProperty("gear_id")]
        public String GearId { get; set; }
        [JsonProperty("average_speed")]
        public float AverageSpeed { get; set; }
        [JsonProperty("max_speed")]
        public float MaxSpeed { get; set; }
        [JsonProperty("average_cadence")]
        public float AverageCadence { get; set; }
        [JsonProperty("average_temp")]
        public float AverageTemperature { get; set; }
        [JsonProperty("average_watts")]
        public float AveragePower { get; set; }
        [JsonProperty("kilojoules")]
        public float Kilojoules { get; set; }
        [JsonProperty("trainer")]
        public bool IsTrainer { get; set; }
        [JsonProperty("commute")]
        public bool IsCommute { get; set; }
        [JsonProperty("manual")]
        public bool IsManual { get; set; }
        [JsonProperty("private")]
        public bool IsPrivate { get; set; }
        [JsonProperty("flagged")]
        public bool IsFlagged { get; set; }
        [JsonProperty("achievement_count")]
        public int AchievementCount { get; set; }
        [JsonProperty("kudos_count")]
        public int KudosCount { get; set; }
        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }
        [JsonProperty("athelete_count")]
        public int AtheleteCount { get; set; }
        [JsonProperty("photo_count")]
        public int PhotoCount { get; set; }
        [JsonProperty("start_date")]
        public String StartDate { get; set; }
        [JsonProperty("start_date_local")]
        public String StartDateLocal { get; set; }
        [JsonProperty("timezone")]
        public String TimeZone { get; set; }

        #region Objects

        [JsonProperty("segment_efforts")]
        public List<SegmentEffort> SegmentEfforts { get; set; }

        [JsonProperty("start_latlng")]
        public List<double> StartPoint { get; set; }

        public double StartLatitude
        {
            get
            {
                return StartPoint.ElementAt(0);
            }
        }

        public double StartLongitude
        {
            get
            {
                return StartPoint.ElementAt(1);
            }
        }

        [JsonProperty("end_latlng")]
        public List<double> EndPoint { get; set; }

        public double EndLatitude
        {
            get
            {
                return EndPoint.ElementAt(0);
            }
        }

        public double EndLongitude
        {
            get
            {
                return EndPoint.ElementAt(1);
            }
        }

        [JsonProperty("map")]
        public Map Map { get; set; }
        #endregion
        
        //public Athlete Athlete { get; set; }
        //public IGear Gear { get; set; }
        //public ActivityType ActivityType { get; set; }
        //public ResourceState ResourceState { get; set; }

        /*
         * splits_metric: 	array of metric split summaries
         *  running activities only
         * splits_standard: 	array of standard split summaries
         *  running activities only
         * best_efforts: 	array of best effort summaries
         *  running activities only
        */
    }
}
