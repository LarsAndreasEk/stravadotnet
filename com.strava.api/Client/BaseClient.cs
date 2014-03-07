using com.strava.api.Authentication;

namespace com.strava.api.Client
{
    public class BaseClient
    {
        protected IAuthentication Authentication;

        public BaseClient(IAuthentication auth)
        {
            Authentication = auth;
        }
    }
}
