namespace com.strava.api.Activities
{
    /// <summary>
    /// Indicates the levels of detail of a object returned by Strava.
    /// </summary>
    public enum ResourceState
    {
        /// <summary>
        /// Only meta information are contained.
        /// </summary>
        Meta,
        /// <summary>
        /// Summary information are contained.
        /// </summary>
        Summary,
        /// <summary>
        /// All information are contained.
        /// </summary>
        Detailed
    }
}