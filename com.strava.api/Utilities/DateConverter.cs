using System;

namespace com.strava.api.Utilities
{
    /// <summary>
    /// This class is used to convert dates.
    /// </summary>
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

        /// <summary>
        /// Converts an ISO 8601 time string to a DateTime object.
        /// </summary>
        /// <param name="isoDate">The ISO 8601 string.</param>
        /// <returns>The DateTime object</returns>
        public static DateTime ConvertIsoTimeToDateTime(String isoDate)
        {
            try
            {
                DateTime time = DateTime.Parse(isoDate);
                return time;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error converting time: {0}", ex.Message);
            }

            return new DateTime();
        }
    }
}
