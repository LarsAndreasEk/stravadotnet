using System;

namespace com.strava.api.Common
{
    /// <summary>
    /// This class represents a lat/lng coordinate.
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// The latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Initializes a new instance of the Coordinate class.
        /// </summary>
        /// <param name="lat">The latitude.</param>
        /// <param name="lng">The longitude.</param>
        public Coordinate(double lat, double lng)
        {
            Latitude = lat;
            Longitude = lng;
        }

        /// <summary>
        /// Returns a string of the coordinate.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("({0}, {1})", Latitude, Longitude);
        }
    }
}
