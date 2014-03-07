using System;

namespace com.strava.api.Api
{
    /// <summary>
    /// This static class contains the Strava API endpoint Urls.
    /// </summary>
    public static class Endpoints
    {
        /// <summary>
        /// Url to the Activity Endpoint used for the currently authenticated athlete.
        /// </summary>
        public const String Activity = "https://www.strava.com/api/v3/activities";
        /// <summary>
        /// Url to the Activity endpoint used for other athletes than the currently authenticated one.
        /// </summary>
        public const String Activities = "https://www.strava.com/api/v3/athlete/activities";
        public const String ActivitiesFollowers = "https://www.strava.com/api/v3/activities/following";
        /// <summary>
        /// Url to the Athlete Endpoint used for the currently authenticated athlete.
        /// </summary>
        public const String Athlete = "https://www.strava.com/api/v3/athlete";
        /// <summary>
        /// Url to the Athlete Endpoint used for other athletes than the currently authenticated one.
        /// </summary>
        public const String Athletes = "https://www.strava.com/api/v3/athletes";
        /// <summary>
        /// Url to the Club Endpoint used for other athletes than the currently authenticated one.
        /// </summary>
        public const String Club = "https://www.strava.com/api/v3/clubs";
        /// <summary>
        /// Url to the Club Endpoint used for the currently authenticated athlete.
        /// </summary>
        public const String Clubs = "https://www.strava.com/api/v3/athlete/clubs";
        public const String Friends = "https://www.strava.com/api/v3/athlete/friends";
        public const String Follower = "https://www.strava.com/api/v3/athlete/followers";
        public const String Followers = "https://www.strava.com/api/v3/athletes";
        public const String Gear = "https://www.strava.com/api/v3/gear";
        public const String Leaderboard = "https://www.strava.com/api/v3/segments";
        public const String Segments = "https://www.strava.com/api/v3/segments";
        public const String Starred = "https://www.strava.com/api/v3/segments/starred";
    }
}
