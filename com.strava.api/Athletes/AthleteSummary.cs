using System;
using Newtonsoft.Json;

namespace com.strava.api.Athletes
{
    public class AthleteSummary
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("firstname")]
        public String FirstName { get; set; }

        [JsonProperty("lastname")]
        public String LastName { get; set; }

        [JsonProperty("profile_medium")]
        public String ProfileMedium { get; set; }

        [JsonProperty("profile")]
        public String Profile { get; set; }

        [JsonProperty("city")]
        public String City { get; set; }

        [JsonProperty("state")]
        public String State { get; set; }

        [JsonProperty("country")]
        public String Country { get; set; }

        [JsonProperty("sex")]
        public String Sex { get; set; }

        [JsonProperty("friend")]
        public String Friend { get; set; }

        [JsonProperty("follower")]
        public String Follower { get; set; }

        [JsonProperty("premium")]
        public Boolean IsPremium { get; set; }

        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public String UpdatedAt { get; set; }

        [JsonProperty("approve_followers")]
        public Boolean ApproveFollowers { get; set; }
    }
}
