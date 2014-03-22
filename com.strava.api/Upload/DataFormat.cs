namespace com.strava.api.Upload
{
    /// <summary>
    /// Use this enum to specify the data format.
    /// </summary>
    public enum DataFormat
    {
        /// <summary>
        /// The file is a *.fit file.
        /// </summary>
        Fit,
        /// <summary>
        /// The file is a gzipped *.fit file.
        /// </summary>
        FitGZipped,
        /// <summary>
        /// The file is a *.tcx file.
        /// </summary>
        Tcx,
        /// <summary>
        /// The file is a gzipped *.txc file.
        /// </summary>
        TcxGZipped,
        /// <summary>
        /// The file is a *.gpx file.
        /// </summary>
        Gpx,
        /// <summary>
        /// The file is a gzipped *.gpx file.
        /// </summary>
        GpxGZipped
    }
}