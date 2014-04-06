using System.Collections.Generic;
using com.strava.api.Common;
using Newtonsoft.Json;

namespace com.strava.api.Segments
{
    /// <summary>
    /// A single segment returned from the segment explorer.
    /// </summary>
    public class ExplorerSegment
    {
        /// <summary>
        /// The id of the segment.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the segment.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The climb category of the segment.
        /// </summary>
        [JsonProperty("climb_category")]
        public int ClimbCategory { get; set; }

        /// <summary>
        /// The climb category (descent) of the segment.
        /// </summary>
        [JsonProperty("climb_category_desc")]
        public string ClimbCategoryDesc { get; set; }

        /// <summary>
        /// The average grade of the segment.
        /// </summary>
        [JsonProperty("avg_grade")]
        public double AverageGrade { get; set; }

        /// <summary>
        /// Start coordinate.
        /// </summary>
        [JsonProperty("start_latlng")]
        private List<double> _start { get; set; }

        /// <summary>
        /// The start coordinate of the segment.
        /// </summary>
        public Coordinate Start
        {
            get
            {
                return new Coordinate(_start[0], _start[1]);
            }
        }

        /// <summary>
        /// End coordinate.
        /// </summary>
        [JsonProperty("end_latlng")]
        public List<double> _end { get; set; }

        /// <summary>
        /// The end coordinate of the segment.
        /// </summary>
        public Coordinate End
        {
            get
            {
                return new Coordinate(_end[0], _end[1]);
            }
        }

        /// <summary>
        /// The elevation difference of the segment.
        /// </summary>
        [JsonProperty("elev_difference")]
        public double ElevationDifference { get; set; }

        /// <summary>
        /// The distance of the segment.
        /// </summary>
        [JsonProperty("distance")]
        public double Distance { get; set; }

        /// <summary>
        /// The polyline of the segment. Use the PolylineDecoder to get a list of coordinates.
        /// </summary>
        [JsonProperty("points")]
        public string Polyline { get; set; }
    }
}
