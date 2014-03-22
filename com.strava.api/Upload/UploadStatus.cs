using System;
using Newtonsoft.Json;

namespace com.strava.api.Upload
{
    /// <summary>
    /// Contains information about the status of your upload.
    /// </summary>
    public class UploadStatus
    {
        /// <summary>
        /// The upload id of the activity. Provided by Strava upon upload.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The external id. Can not be changed.
        /// </summary>
        [JsonProperty("external_id")]
        public String ExternalId { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        [JsonProperty("error")]
        public String Error { get; set; }

        /// <summary>
        /// Status message.
        /// </summary>
        [JsonProperty("status")]
        public String Status { get; set; }

        /// <summary>
        /// The Strava activity id.
        /// </summary>
        [JsonProperty("activity_id")]
        public String ActivityId { get; set; }
    }
}