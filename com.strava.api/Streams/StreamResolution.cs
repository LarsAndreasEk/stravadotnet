namespace com.strava.api.Streams
{
    /// <summary>
    /// Indicates desired number of data points, streams will only be down sampled.
    /// </summary>
    public enum StreamResolution
    {
        /// <summary>
        /// Returns 100 data points (maximum).
        /// </summary>
        Low,
        /// <summary>
        /// Returs 1000 data points (maximum).
        /// </summary>
        Medium,
        /// <summary>
        /// Returns 10000 data points (maximum).
        /// </summary>
        High,
        /// <summary>
        /// Returns all the data points.
        /// </summary>
        All
    }
}