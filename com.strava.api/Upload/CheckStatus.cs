namespace com.strava.api.Upload
{
    /// <summary>
    /// The status of the UploadStatusCheck object.
    /// </summary>
    public enum CheckStatus
    {
        /// <summary>
        /// The checker is in idle mode.
        /// </summary>
        Idle,
        /// <summary>
        /// The checker is busy.
        /// </summary>
        Busy,
        /// <summary>
        /// The checker has finished.
        /// </summary>
        Finished
    }
}