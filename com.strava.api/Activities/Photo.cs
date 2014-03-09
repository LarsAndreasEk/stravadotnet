using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    /// <summary>
    /// Represents a photo linked to an activity.
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// The photo's id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The id of the activity to which the photo is connected to.
        /// </summary>
        [JsonProperty("activity_id")]
        public long ActivityId { get; set; }

        /// <summary>
        /// The level of detail.
        /// </summary>
        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        /// <summary>
        /// Url to the picture. Use the ImageLoader class to download the picture.
        /// </summary>
        [JsonProperty("ref")]
        public String ImageUrl { get; set; }

        /// <summary>
        /// The photo's external id.
        /// </summary>
        [JsonProperty("uid")]
        public String ExternalUid { get; set; }

        /// <summary>
        /// The caption.
        /// </summary>
        [JsonProperty("caption")]
        public String Caption { get; set; }

        /// <summary>
        /// Image source. Currently only "InstagramPhoto"
        /// </summary>
        [JsonProperty("type")]
        public String Type { get; set; }

        /// <summary>
        /// The date when the image was uploaded.
        /// </summary>
        [JsonProperty("uploaded_at")]
        public String UploadedAt { get; set; }

        /// <summary>
        /// The date when the image was crated.
        /// </summary>
        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        /// <summary>
        /// The location where the picture was taken.
        /// </summary>
        [JsonProperty("location")]
        public List<double> Location { get; set; }
    }
}
