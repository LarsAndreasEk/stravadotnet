using System;

namespace com.strava.api.Utilities
{
    public static class DateConverter
    {
        /// <summary>
        /// Converts a DateTime object to unix epoch seconds.
        /// </summary>
        /// <param name="date">The Date you want to convert.</param>
        /// <returns>The amount of seconds since 1/1/1970 0:00:00 AM</returns>
        public static long GetSecondsSinceUnixEpoch(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }
    }
}
