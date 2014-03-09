using System;
using com.strava.api.Authentication;

namespace com.strava.api.Client
{
    /// <summary>
    /// Base class for all the clients except the StravaClient.
    /// </summary>
    public class BaseClient
    {
        /// <summary>
        /// IAuthentication object used for authentication.
        /// </summary>
        protected IAuthentication Authentication;

        /// <summary>
        /// Initializes a new instance of the BaseClient class.
        /// </summary>
        /// <param name="auth">A valid object that implements the IAuthentication interface.</param>
        public BaseClient(IAuthentication auth)
        {
            if (auth == null)
            {
                throw new ArgumentException("The IAuthentication object must not be null!");
            }

            Authentication = auth;
        }
    }
}
