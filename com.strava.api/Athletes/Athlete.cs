/*
id: 	integer
resource_state: 	integer
firstname: 	string
lastname: 	string
profile_medium: 	string
URL to a 62x62 pixel profile picture
profile: 	string
URL to a 124x124 pixel profile picture
city: 	string
state: 	string
country: 	string
sex: 	string
‘M’, ‘F’ or null
friend: 	string
‘pending’, ‘accepted’, ‘blocked’ or ‘null’
the authenticated athlete’s following status of this athlete
follower: 	string
‘pending’, ‘accepted’, ‘blocked’ or ‘null’
this athlete’s following status of the authenticated athlete
premium: 	boolean
created_at: 	time string
updated_at: 	time string
approve_followers: 	boolean
if has enhanced privacy enabled
follower_count: 	integer
friend_count: 	integer
mutual_friend_count: 	integer
date_preference: 	string
measurement_preference: 	string
‘feet’ or ‘meters’
email: 	string
ftp: 	integer
clubs: 	array of object
array of summary representations of the athlete’s clubs
bikes: 	array of object
array of summary representations of the athlete’s bikes
shoes: 	array of object
array of summary representations of the athlete’s shoes
*/

using System;
using System.Collections.Generic;
using com.strava.api.Gear;
using Newtonsoft.Json;

namespace com.strava.api.Athletes
{
    public class Athlete
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
        public String Premium { get; set; }

        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public String UpdatedAt { get; set; }

        [JsonProperty("approve_followers")]
        public Boolean ApproveFollowers { get; set; }

        [JsonProperty("follower_count")]
        public int FollowerCount { get; set; }

        [JsonProperty("friend_count")]
        public int FriendCount { get; set; }

        [JsonProperty("mutual_friend_count")]
        public int MutualFriendCount { get; set; }

        [JsonProperty("date_preference")]
        public String DatePreference { get; set; }

        [JsonProperty("measurement_preference")]
        public String MeasurementPreference { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("ftp")]
        public int? Ftp { get; set; }

        [JsonProperty("bikes")]
        public List<Bike> Bikes { get; set; }
    }
}
