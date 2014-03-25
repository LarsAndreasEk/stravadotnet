namespace com.strava.api.Upload
{
    /// <summary>
    /// Indicates the status of an upload.
    /// </summary>
    public enum CurrentUploadStatus
    {
        /// <summary>
        /// The upload is being processed.
        /// </summary>
        Processing,
        /// <summary>
        /// The file to upload was deleted.
        /// </summary>
        Deleted,
        /// <summary>
        /// There was an error uploading your file.
        /// </summary>
        Error,
        /// <summary>
        /// Your activity was uploaded and can be seen on Strava.
        /// </summary>
        Ready
    }
}
