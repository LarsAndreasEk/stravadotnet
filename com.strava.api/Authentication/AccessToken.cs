using System;
using Newtonsoft.Json;

namespace com.strava.api.Authentication
{
    /// <summary>
    /// This class holds an access token.
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// The access token.
        /// </summary>
        [JsonProperty("access_token")]
        public String Token { get; set; }
    }
}
