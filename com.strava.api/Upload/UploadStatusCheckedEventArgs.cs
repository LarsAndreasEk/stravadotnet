using System;

namespace com.strava.api.Upload
{
    /// <summary>
    /// Contains information about the current status of an upload.
    /// </summary>
    public class UploadStatusCheckedEventArgs : EventArgs
    {
        /// <summary>
        /// The status of an upload.
        /// </summary>
        public CurrentUploadStatus Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the UploadStatusCheckedEventArgs class.
        /// </summary>
        /// <param name="status">The current status.</param>
        public UploadStatusCheckedEventArgs(CurrentUploadStatus status)
        {
            Status = status;
        }
    }
}
