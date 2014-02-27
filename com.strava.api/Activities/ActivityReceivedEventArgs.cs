namespace com.strava.api.Activities
{
    public class ActivityReceivedEventArgs
    {
        public ActivitySummary Activity { get; set; }

        public ActivityReceivedEventArgs(ActivitySummary summary)
        {
            Activity = summary;
        }
    }
}
