using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using com.strava.api.Activities;
using com.strava.api.Api;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Clubs;
using com.strava.api.Common;
using com.strava.api.Segments;
using com.strava.api.Streams;
using com.strava.api.Utilities;
using WebRequest = com.strava.api.Http.WebRequest;

namespace com.strava.api.Client
{
    /// <summary>
    /// The StravaClient is used to receive data from Strava. The client offers various subclients, which you can use to
    /// receive the data. 
    /// <list type="bullet">
    /// <listheader>
    ///    <term>Currently the following Strava API resources are supported:</term>
    /// </listheader>
    /// <item>
    ///     <term>Activities</term>
    /// </item>
    /// <item>
    ///     <term>Athletes</term>
    /// </item>
    /// <item>
    ///     <term>Clubs</term>
    /// </item>
    /// <item>
    ///     <term>Gear</term>
    /// </item>
    /// <item>
    ///     <term>Segments</term>
    /// </item>
    /// <item>
    ///     <term>Segment Efforts</term>
    /// </item>
    /// <item>
    ///     <term>Streams</term>
    /// </item>
    /// </list>
    /// </summary>
    public class StravaClient
    {
        private readonly IAuthentication _authenticator;

        /// <summary>
        /// Initializes a new instance of the StravaClient class.
        /// </summary>
        /// <param name="authenticator">The IAuthentication object that holds a valid Access Token.</param>
        /// <seealso cref="WebAuthentication"/>
        /// <seealso cref="StaticAuthentication"/>
        public StravaClient(IAuthentication authenticator)
        {
            if (authenticator != null)
            {
                _authenticator = authenticator;

                Activities = new ActivityClient(authenticator);
                Athletes = new AthleteClient(authenticator);
                Clubs = new ClubClient(authenticator);
                Gear = new GearClient(authenticator);
                Segments = new SegmentClient(authenticator);
                Streams = new StreamClient(authenticator);
            }
            else
            {
                throw new ArgumentException("The IAuthentication object must not be null.");
            }
        }

        #region Clients

        /// <summary>
        /// Predefined ActivityClient.
        /// </summary>
        public ActivityClient Activities { get; set; }

        /// <summary>
        /// Predefined AthleteClient.
        /// </summary>
        public AthleteClient Athletes { get; set; }

        /// <summary>
        /// Predefined ClubClient.
        /// </summary>
        public ClubClient Clubs { get; set; }

        /// <summary>
        /// Predefined GearClient.
        /// </summary>
        public GearClient Gear { get; set; }

        /// <summary>
        /// Predefined SegmentClient.
        /// </summary>
        public SegmentClient Segments { get; set; }

        /// <summary>
        /// Predefined StreamClient.
        /// </summary>
        public StreamClient Streams { get; set; }

        #endregion

        /// <summary>
        /// Returns the framework version of the StravaClient.
        /// </summary>
        /// <returns>The version number of the StravaClient.</returns>
        public override string ToString()
        {
            return String.Format("StravaClient Version {0}", Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}
