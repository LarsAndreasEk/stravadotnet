using System;

namespace com.strava.api.Streams
{
    [Flags]
    public enum SegmentStreamType
    {
        LatLng = 1,
        Distance = 2,
        Altitude = 4,
    }
}