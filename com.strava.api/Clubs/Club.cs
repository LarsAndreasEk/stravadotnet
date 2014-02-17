using System;
using Newtonsoft.Json;

namespace com.strava.api.Clubs
{
    public class Club
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("profile_medium")]
        public String ProfileMedium { get; set; }

        [JsonProperty("profile")]
        public String Profile { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("club_type")]
        private String _clubType { get; set; }

        public ClubType ClubType
        {
            get
            {
                if (_clubType.Equals("casual_club"))
                    return ClubType.Casual;
                if (_clubType.Equals("racing_team"))
                    return ClubType.RacingTeam;
                if (_clubType.Equals("shop"))
                    return ClubType.Shop;
                if (_clubType.Equals("company"))
                    return ClubType.Company;

                return ClubType.Other;
            }
        }

        [JsonProperty("sport_type")]
        private String _sportType { get; set; }

        public SportType SportType
        {
            get
            {
                if (_sportType.Equals("cycling"))
                    return SportType.Cycling;
                if (_sportType.Equals("running"))
                    return SportType.Running;
                if (_sportType.Equals("triathlon"))
                    return SportType.Triathlon;

                return SportType.Other;
            }
        }

        [JsonProperty("city")]
        public String City { get; set; }

        [JsonProperty("state")]
        public String State { get; set; }

        [JsonProperty("country")]
        public String Country { get; set; }

        [JsonProperty("private")]
        public Boolean IsPrivate { get; set; }

        [JsonProperty("member_count")]
        public int MemberCount { get; set; }
    }
}
