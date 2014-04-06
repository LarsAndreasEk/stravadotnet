using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.strava.api.Segments
{
    /// <summary>
    /// Class that stores the results of the segment explorer.
    /// </summary>
    public class ExplorerResult
    {
        /// <summary>
        /// The results of the segment explorer.
        /// </summary>
        [JsonProperty("segments")]
        public List<ExplorerSegment> Results { get; set; } 
    }
}
