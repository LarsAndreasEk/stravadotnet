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
        public int FirstName { get; set; }

        [JsonProperty("lastname")]
        public int LastName { get; set; }

        [JsonProperty("profile_medium")]
        public int ProfileMedium { get; set; }

        [JsonProperty("profile")]
        public int Profile { get; set; }

        [JsonProperty("city")]
        public int City { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("country")]
        public int Country { get; set; }
    }
}
