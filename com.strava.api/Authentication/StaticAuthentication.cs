using System;

namespace com.strava.api.Authentication
{
    public class StaticAuthentication : IAuthentication
    {
        public String Token { get; set; }

        public StaticAuthentication(String token)
        {
            Token = token;
        }
    }
}
