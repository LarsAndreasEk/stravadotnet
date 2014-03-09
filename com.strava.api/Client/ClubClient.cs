using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.strava.api.Activities;
using com.strava.api.Api;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Clubs;
using com.strava.api.Common;
using com.strava.api.Http;

namespace com.strava.api.Client
{
    /// <summary>
    /// Used to receive information about clubs from Strava.
    /// </summary>
    public class ClubClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the ClubClient class.
        /// </summary>
        /// <param name="auth">IAuthentication object that contains a valid access token.</param>
        public ClubClient(IAuthentication auth) : base(auth) { }

        #region Async

        /// <summary>
        /// Gets the club which the specified id.
        /// </summary>
        /// <param name="clubId">The id of the club.</param>
        /// <returns>The Club object containing detailed information about the club.</returns>
        public async Task<Club> GetClubAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Club>.Unmarshal(json);
        }

        /// <summary>
        /// Gets a list of clubs in which the currently authenticated athlete is a member of.
        /// </summary>
        /// <returns>The list of clubs in which the currently authenticated user is a member of.</returns>
        public async Task<List<ClubSummary>> GetClubsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Clubs, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ClubSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the members of the specified club.
        /// </summary>
        /// <param name="clubId">The club's id.</param>
        /// <returns>The club's members.</returns>
        public async Task<List<AthleteSummary>> GetClubMembersAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/members?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets a list of the latest club activities.
        /// </summary>
        /// <param name="clubId">Id of the club you want to get the activities of.</param>
        /// <returns></returns>
        public async Task<List<ActivitySummary>> GetLatestClubActivitiesAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/activities?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets a list of the latest club activities.
        /// </summary>
        /// <param name="clubId">Id of the club you want to get the activities of.</param>
        /// <param name="page">The page of the activities list.</param>
        /// <param name="perPage">Specifies how many activities shpuld be shown per page.</param>
        /// <returns></returns>
        public async Task<List<ActivitySummary>> GetLatestClubActivitiesAsync(String clubId, int page, int perPage)
        {
            String getUrl = String.Format("{0}/{1}/activities?page={2}&per_page={3}&access_token={4}",
                Endpoints.Club,
                clubId,
                page,
                perPage,
                Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        #endregion

        #region Sync

        /// <summary>
        /// Gets the club which the specified id.
        /// </summary>
        /// <param name="clubId">The id of the club.</param>
        /// <returns>The Club object containing detailed information about the club.</returns>
        public Club GetClub(String clubId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Club>.Unmarshal(json);
        }

        /// <summary>
        /// Gets a list of clubs in which the currently authenticated athlete is a member of.
        /// </summary>
        /// <returns>The list of clubs in which the currently authenticated user is a member of.</returns>
        public List<ClubSummary> GetClubs()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Clubs, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ClubSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the members of the specified club.
        /// </summary>
        /// <param name="clubId">The club's id.</param>
        /// <returns>The club's members.</returns>
        public List<AthleteSummary> GetClubMembers(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/members?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets a list of the latest club activities.
        /// </summary>
        /// <param name="clubId">Id of the club you want to get the activities of.</param>
        /// <returns></returns>
        public List<ActivitySummary> GetLatestClubActivities(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/activities?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets a list of the latest club activities.
        /// </summary>
        /// <param name="clubId">Id of the club you want to get the activities of.</param>
        /// <param name="page">The page of the activities list.</param>
        /// <param name="perPage">Specifies how many activities shpuld be shown per page.</param>
        /// <returns></returns>
        public List<ActivitySummary> GetLatestClubActivities(String clubId, int page, int perPage)
        {
            String getUrl = String.Format("{0}/{1}/activities?page={2}&per_page={3}&access_token={4}",
                Endpoints.Club,
                clubId,
                page,
                perPage,
                Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        #endregion
    }
}
