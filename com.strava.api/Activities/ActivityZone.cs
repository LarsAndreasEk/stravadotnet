using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class ActivityZone
    {
        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("distribution_buckets")]
        public List<DistributionBucket> Buckets { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("sensor_based")]
        public bool IsSensorBased { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("custom_zones")]
        public bool IsCustomZones { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("bike_weight")]
        public float BikeWeight { get; set; }

        [JsonProperty("athlete_weight")]
        public float AthleteWeight { get; set; }
    }
}
