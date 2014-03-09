using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.strava.api.Streams
{
    /// <summary>
    /// Represents a Strava segment stream.
    /// </summary>
    public class SegmentStream
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        private String Type { get; set; }


        public StreamType StreamType
        {
            get
            {
                if (Type.Equals("altitude"))
                {
                    return StreamType.Altitude;
                }
                if (Type.Equals("cadence"))
                {
                    return StreamType.Cadence;
                }
                if (Type.Equals("latlng"))
                {
                    return StreamType.LatLng;
                }
                if (Type.Equals("distance"))
                {
                    return StreamType.Distance;
                }
                if (Type.Equals("grade_smooth"))
                {
                    return StreamType.GradeSmooth;
                }
                if (Type.Equals("heartrate"))
                {
                    return StreamType.Heartrate;
                }
                if (Type.Equals("moving"))
                {
                    return StreamType.Moving;
                }
                if (Type.Equals("temp"))
                {
                    return StreamType.Temperature;
                }
                if (Type.Equals("time"))
                {
                    return StreamType.Time;
                }
                if (Type.Equals("velocity_smooth"))
                {
                    return StreamType.VelocitySmooth;
                }

                return StreamType.Watts;
            }
        }

        [JsonProperty("data")]
        public List<object> Data { get; set; }

        [JsonProperty("series_type")]
        public String SeriesType { get; set; }

        [JsonProperty("original_size")]
        public int OriginalSize { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }
    }
}
