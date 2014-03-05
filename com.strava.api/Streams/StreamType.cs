using System;

namespace com.strava.api.Streams
{
    [Flags]
    public enum StreamType
    {
        Time = 1,
        LatLng = 2,
        Distance = 4,
        Altitude = 8,
        VelocitySmooth = 16,
        Heartrate = 32,
        Cadence = 64,
        Watts = 128,
        Temperature = 256,
        Moving = 512,
        GradeSmooth = 1024
    }
}