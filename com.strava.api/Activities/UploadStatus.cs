using System;
using Newtonsoft.Json;


namespace com.strava.api.Activities
{
    public class UploadStatus
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("external_id")]
        public String ExternalId { get; set; }

        [JsonProperty("error")]
        public String Error { get; set; }

        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("activity_id")]
        public long ActivityId { get; set; }

        public bool HasError
        {
            get { return !String.IsNullOrEmpty(Error); }
        }
    }
}
