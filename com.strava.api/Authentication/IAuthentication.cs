using System;


namespace com.strava.api.Authentication
{
    /// <summary>
    /// The IAuthentication is used for classes that contain methods to receive an access token from Strava.
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// The access token received from Strava.
        /// </summary>
        String AccessToken { get; set; }
    }
}
