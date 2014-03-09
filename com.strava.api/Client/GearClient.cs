using System;
using System.Threading.Tasks;
using com.strava.api.Api;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Http;

namespace com.strava.api.Client
{
    /// <summary>
    /// Used to receive information about gear.
    /// </summary>
    public class GearClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the GearClient class.
        /// </summary>
        /// <param name="auth"></param>
        public GearClient(IAuthentication auth) : base(auth) { }

        #region Async

        /// <summary>
        /// Retrieves gear with the specified id asynchronously from the Strava servers.
        /// </summary>
        /// <param name="gearId">The Strava id of the gear.</param>
        /// <returns>The gear object.</returns>
        public async Task<Gear.Gear> GetGearAsync(String gearId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Gear, gearId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Gear.Gear>.Unmarshal(json);
        }

        #endregion

        #region Sync

        /// <summary>
        /// Retrieves gear with the specified id from the Strava servers.
        /// </summary>
        /// <param name="gearId">The Strava id of the gear.</param>
        /// <returns>The gear object.</returns>
        public Gear.Gear GetGear(String gearId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Gear, gearId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Gear.Gear>.Unmarshal(json);
        }

        #endregion
    }
}
