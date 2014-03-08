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
    public class ClubClient : BaseClient
    {
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

        public async Task<List<ClubSummary>> GetClubsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Clubs, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ClubSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetClubMembersAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/members?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<ActivitySummary>> GetLatestClubActivitiesAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/activities?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

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

        public Club GetClub(String clubId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Club>.Unmarshal(json);
        }

        public List<ClubSummary> GetClubs()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Clubs, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ClubSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetClubMembers(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/members?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<ActivitySummary> GetLatestClubActivities(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/activities?access_token={2}", Endpoints.Club, clubId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

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
