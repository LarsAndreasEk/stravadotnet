namespace com.strava.api.Activities
{
    /// <summary>
    /// Specifies the parameter whereby the leaderboard will be sorted by.
    /// </summary>
    public enum LeaderboardParameter
    {
        /// <summary>
        /// Sorts the leaderboard by the athlete's name.
        /// </summary>
        AthleteName,
        /// <summary>
        /// Sorts the leaderboard by date.
        /// </summary>
        Date,
        /// <summary>
        /// Sorts the leaderboard by the average heartrate.
        /// </summary>
        AverageHeartrate,
        /// <summary>
        /// Sorts the leaderboard by moving time.
        /// </summary>
        MovingTime,
        /// <summary>
        /// Sorts the leaderboard by the elapsed time.
        /// </summary>
        ElapsedTime,
        /// <summary>
        /// Sorts the leaderboard by the average power.
        /// </summary>
        AveragePower
    }
}