namespace com.strava.api.Activities
{
    /// <summary>
    /// Used to filter a segment leaderboard.
    /// </summary>
    public enum TimeFilter
    {
        // ‘this_year’, ‘this_month’, ‘this_week’, ‘today’
        /// <summary>
        /// Show efforts from this year.
        /// </summary>
        ThisYear,
        /// <summary>
        /// Show efforts from this month.
        /// </summary>
        ThisMonth,
        /// <summary>
        /// Show efforts from this week.
        /// </summary>
        ThisWeek,
        /// <summary>
        /// Show efforts from today.
        /// </summary>
        Today
    }
}