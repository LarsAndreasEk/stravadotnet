using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    /// <summary>
    /// Represents a Strava activity zone.
    /// </summary>
    public class ActivityZone
    {
        /// <summary>
        /// The score of the activity zone.
        /// </summary>
        [JsonProperty("score")]
        public int Score { get; set; }

        /// <summary>
        /// The list of distribution buckets of the activity zone.
        /// </summary>
        [JsonProperty("distribution_buckets")]
        public List<DistributionBucket> Buckets { get; set; }

        /// <summary>
        /// The type of the zone.
        /// </summary>
        [JsonProperty("type")]
        public String Type { get; set; }

        /// <summary>
        /// Resource state.
        /// </summary>
        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        /// <summary>
        /// True if the data is sensor based.
        /// </summary>
        [JsonProperty("sensor_based")]
        public bool IsSensorBased { get; set; }

        /// <summary>
        /// Points in this zone.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; set; }

        /// <summary>
        /// Custom zones.
        /// </summary>
        [JsonProperty("custom_zones")]
        public bool IsCustomZones { get; set; }

        /// <summary>
        /// The max value of the activity zone.
        /// </summary>
        [JsonProperty("max")]
        public int Max { get; set; }

        /// <summary>
        /// The bike weight.
        /// </summary>
        [JsonProperty("bike_weight")]
        public float BikeWeight { get; set; }

        /// <summary>
        /// The athlete's weight.
        /// </summary>
        [JsonProperty("athlete_weight")]
        public float AthleteWeight { get; set; }
    }
}
