namespace com.strava.api.Upload
{
    /// <summary>
    /// This enum is used to specify the file extension when uploading a file to Strava.
    /// </summary>
    public enum FileExtension
    {
        /// <summary>
        /// The file to upload is a *.fit file.
        /// </summary>
        Fit,
        /// <summary>
        /// The file to upload is a *.gpx file.
        /// </summary>
        Gpx,
        /// <summary>
        /// The file to upload is a *.tcx file.
        /// </summary>
        Tcx
    }
}