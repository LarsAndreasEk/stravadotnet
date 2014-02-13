using System;

namespace com.strava.api.Authentication
{
    public class TokenReceivedEventArgs
    {
        public String Token { get; set; }

        public TokenReceivedEventArgs(String token)
        {
            Token = token;
        }
    }
}
