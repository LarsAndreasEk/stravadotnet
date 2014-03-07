namespace com.strava.api.Authentication
{
    /// <summary>
    /// Used to specify what data from Strava can be received by your application.
    /// </summary>
    public enum Scope
    {
        /// <summary>
        /// Only public data can be received.
        /// </summary>
        Public,
        /// <summary>
        /// Data can be written. This scope is needed if you want to upload activities.
        /// </summary>
        Write,
        /// <summary>
        /// Only private data can be received.
        /// </summary>
        ViewPrivate,
        /// <summary>
        /// Private and public data can be received and write permissions are granted.
        /// </summary>
        Full
    }
}