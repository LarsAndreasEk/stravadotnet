using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace com.strava.api.Common
{
    /// <summary>
    /// Decode a polyline to a list of coordinates.
    /// </summary>
    public static class PolylineDecoder
    {
        /// <summary>
        /// Decodes a polyline to a list of coordinates.
        /// </summary>
        /// <param name="encodedPoints">The encoded polyline.</param>
        /// <returns>A list of coordinates.</returns>
        public static List<Coordinate> Decode(String encodedPoints)
        {
            {
                if (String.IsNullOrEmpty(encodedPoints))
                    return null;

                List<Coordinate> poly = new List<Coordinate>();
                char[] polylinechars = encodedPoints.ToCharArray();
                int index = 0;

                int currentLat = 0;
                int currentLng = 0;
                int next5bits;
                int sum;
                int shifter;

                try
                {
                    while (index < polylinechars.Length)
                    {
                        // calculate next latitude
                        sum = 0;
                        shifter = 0;
                        do
                        {
                            next5bits = (int) polylinechars[index++] - 63;
                            sum |= (next5bits & 31) << shifter;
                            shifter += 5;
                        } while (next5bits >= 32 && index < polylinechars.Length);

                        if (index >= polylinechars.Length)
                            break;

                        currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                        //calculate next longitude
                        sum = 0;
                        shifter = 0;
                        do
                        {
                            next5bits = (int) polylinechars[index++] - 63;
                            sum |= (next5bits & 31) << shifter;
                            shifter += 5;
                        } while (next5bits >= 32 && index < polylinechars.Length);

                        if (index >= polylinechars.Length && next5bits >= 32)
                            break;

                        currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                        poly.Add(new Coordinate(Convert.ToDouble(currentLat) / 100000.0, Convert.ToDouble(currentLng) / 100000.0));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(String.Format("Error: Decoding polyline: {0}", ex.Message));
                }

                return poly;
            }
        }
    }
}
