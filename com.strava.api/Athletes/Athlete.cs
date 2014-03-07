using System;
using System.Collections.Generic;
using com.strava.api.Clubs;
using Newtonsoft.Json;

namespace com.strava.api.Athletes
{
    public class Athlete : AthleteSummary
    {
        /// <summary>
        /// The count of the athlete's followers.
        /// </summary>
        [JsonProperty("follower_count")]
        public int FollowerCount { get; set; }

        /// <summary>
        /// The count of the athlete's friends.
        /// </summary>
        [JsonProperty("friend_count")]
        public int FriendCount { get; set; }

        /// <summary>
        /// The count of the athlete's friends that both this athlete and the currently authenticated athlete are following.
        /// </summary>
        [JsonProperty("mutual_friend_count")]
        public int MutualFriendCount { get; set; }

        /// <summary>
        /// The date preference. ISO 8601 time string.
        /// </summary>
        [JsonProperty("date_preference")]
        public String DatePreference { get; set; }

        /// <summary>
        /// Either 'feet' or 'meters'
        /// </summary>
        [JsonProperty("measurement_preference")]
        public String MeasurementPreference { get; set; }

        /// <summary>
        /// The email address.
        /// </summary>
        [JsonProperty("email")]
        public String Email { get; set; }

        /// <summary>
        /// The functional threshold power.
        /// </summary>
        [JsonProperty("ftp")]
        public int? Ftp { get; set; }

        /// <summary>
        /// A list of the athlete's bikes.
        /// </summary>
        [JsonProperty("bikes")]
        public List<Gear.Gear> Bikes { get; set; }

        /// <summary>
        /// A list of the athlete's clubs.
        /// </summary>
        [JsonProperty("clubs")]
        public List<Club> Clubs { get; set; }
    }
}
