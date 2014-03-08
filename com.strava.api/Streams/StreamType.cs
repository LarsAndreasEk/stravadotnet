using System;

namespace com.strava.api.Streams
{
    /// <summary>
    /// Used to specify which stream should be received from the server.
    /// </summary>
    [Flags]
    public enum StreamType
    {
        /// <summary>
        /// Time information is received.
        /// </summary>
        Time = 1,
        /// <summary>
        /// Coordinate information is received.
        /// </summary>
        LatLng = 2,
        /// <summary>
        /// Distance information is received.
        /// </summary>
        Distance = 4,
        /// <summary>
        /// Altitude information is received.
        /// </summary>
        Altitude = 8,
        /// <summary>
        /// Velocity information is received.
        /// </summary>
        VelocitySmooth = 16,
        /// <summary>
        /// Heartrate information is received.
        /// </summary>
        Heartrate = 32,
        /// <summary>
        /// Cadence information is received.
        /// </summary>
        Cadence = 64,
        /// <summary>
        /// Power information is received.
        /// </summary>
        Watts = 128,
        /// <summary>
        /// Temperature information is received.
        /// </summary>
        Temperature = 256,
        /// <summary>
        /// Information about the time moved is received.
        /// </summary>
        Moving = 512,
        /// <summary>
        /// Information about the grade is received.
        /// </summary>
        GradeSmooth = 1024
    }
}