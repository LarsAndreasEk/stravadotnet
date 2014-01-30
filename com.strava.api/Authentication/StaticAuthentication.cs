using System;

namespace com.strava.api.Authentication
{
    public class StaticAuthentication : IAuthentication
    {
        public string AuthToken { get; set; }

        public StaticAuthentication(String authToken)
        {
            AuthToken = authToken;
        }
    }
}
