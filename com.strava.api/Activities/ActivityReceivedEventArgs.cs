namespace com.strava.api.Activities
{
    /// <summary>
    /// This class holds information about the received activity.
    /// </summary>
    public class ActivityReceivedEventArgs
    {
        /// <summary>
        /// The activity object that was received and unmarshalled.
        /// </summary>
        public ActivitySummary Activity { get; set; }

        /// <summary>
        /// Initializes a new instance of the ActivityReceivedEventArgs class.
        /// </summary>
        /// <param name="summary">The ActivitySummary object that was received.</param>
        public ActivityReceivedEventArgs(ActivitySummary summary)
        {
            Activity = summary;
        }
    }
}
