using System;

namespace com.strava.api.Authentication
{
    /// <summary>
    /// This class is used to authenticate with Strava.
    /// </summary>
    public class StaticAuthentication : IAuthentication
    {
        /// <summary>
        /// The access token used to authenticate with Strava.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the StaticAuthentication class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public StaticAuthentication(String accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
