using System;
using Newtonsoft.Json;

namespace com.strava.api.Authentication
{
    public class AccessToken
    {
        [JsonProperty("access_token")]
        public String Token { get; set; }
    }
}
