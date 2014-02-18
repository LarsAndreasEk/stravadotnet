using System;

namespace com.strava.api.Authentication
{
    public class StaticAuthentication : IAuthentication
    {
        public string AccessToken { get; set; }

        public StaticAuthentication(String authToken)
        {
            AccessToken = authToken;
        }
    }
}
