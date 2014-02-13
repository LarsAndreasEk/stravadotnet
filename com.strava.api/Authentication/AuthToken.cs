using System;
using Newtonsoft.Json;

namespace com.strava.api.Authentication
{
    public class AuthToken
    {
        [JsonProperty("access_token")]
        public String AccessToken { get; set; }
    }
}
