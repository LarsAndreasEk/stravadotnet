namespace com.strava.api.Api
{
    /// <summary>
    /// Class that holds information about the API usage.
    /// </summary>
    public class UsageChangedEventArgs
    {
        /// <summary>
        /// The Usage.
        /// </summary>
        public Usage Usage { get; set; }

        /// <summary>
        /// Initializes a new instance of the UsageChangedEventArgs class.
        /// </summary>
        /// <param name="shortTerm">Short term limit.</param>
        /// <param name="longTerm">Long term limit.</param>
        public UsageChangedEventArgs(int shortTerm, int longTerm)
        {
            Usage = new Usage(shortTerm, longTerm);
        }
    }
}
