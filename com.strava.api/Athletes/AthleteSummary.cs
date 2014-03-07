using System;
using Newtonsoft.Json;

namespace com.strava.api.Athletes
{
    public class AthleteSummary : AthleteMeta
    {
        /// <summary>
        /// The athletes first name.
        /// </summary>
        [JsonProperty("firstname")]
        public String FirstName { get; set; }

        /// <summary>
        /// The athletes last name.
        /// </summary>
        [JsonProperty("lastname")]
        public String LastName { get; set; }

        /// <summary>
        /// Url to a 62x62 pixel profile picture. You can use the ImageLoader class to load this picture.
        /// </summary>
        [JsonProperty("profile_medium")]
        public String ProfileMedium { get; set; }

        /// <summary>
        /// Url to a 124x124 pixel profile picture. You can use the ImageLoader class to load this picture.
        /// </summary>
        [JsonProperty("profile")]
        public String Profile { get; set; }

        /// <summary>
        /// The city where the athlete lives.
        /// </summary>
        [JsonProperty("city")]
        public String City { get; set; }

        /// <summary>
        /// The state where the athlete lives.
        /// </summary>
        [JsonProperty("state")]
        public String State { get; set; }

        /// <summary>
        /// The state where the athlete lives.
        /// </summary>
        [JsonProperty("country")]
        public String Country { get; set; }

        /// <summary>
        /// The athlete's sex.
        /// </summary>
        [JsonProperty("sex")]
        public String Sex { get; set; }

        /// <summary>
        /// The authenticated athlete’s friend status of this athlete.
        /// Values are 'pending', 'accepted', 'blocked' or 'null'.
        /// </summary>
        [JsonProperty("friend")]
        public String Friend { get; set; }

        /// <summary>
        /// The authenticated athlete’s following status of this athlete.
        /// Values are 'pending', 'accepted', 'blocked' or 'null'.
        /// </summary>
        [JsonProperty("follower")]
        public String Follower { get; set; }

        /// <summary>
        /// True, if the athlete is a Strava premium member. In some cases this attribute is important, for example when leaderboards are filtered
        /// by either weight class or age group.
        /// </summary>
        [JsonProperty("premium")]
        public Boolean IsPremium { get; set; }

        /// <summary>
        /// The date when this athlete was created. ISO 8601 time string.
        /// </summary>
        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        /// <summary>
        /// The date when this athlete was updated. ISO 8601 time string.
        /// </summary>
        [JsonProperty("updated_at")]
        public String UpdatedAt { get; set; }

        /// <summary>
        /// True, if enhanced privacy is enabled.
        /// </summary>
        [JsonProperty("approve_followers")]
        public Boolean ApproveFollowers { get; set; }
    }
}
