using System;

namespace com.strava.api.Streams
{
    /// <summary>
    /// Specifies which information about a segment is being received.
    /// </summary>
    [Flags]
    public enum SegmentStreamType
    {
        /// <summary>
        /// Segment coordinate information is received.
        /// </summary>
        LatLng = 1,
        /// <summary>
        /// Segment distance information is received.
        /// </summary>
        Distance = 2,
        /// <summary>
        /// Segment altitude information is received.
        /// </summary>
        Altitude = 4,
    }
}