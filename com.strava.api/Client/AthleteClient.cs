using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.strava.api.Api;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Http;

namespace com.strava.api.Client
{
    public class AthleteClient : BaseClient
    {
        public AthleteClient(IAuthentication auth) : base(auth) { }

        #region Async

        public async Task<Athlete> GetAthleteAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Athlete, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        public async Task<AthleteSummary> GetAthleteAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Athlete, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<AthleteSummary>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFriendsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Friends, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFriendsAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", Endpoints.Friends, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFollowersAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Follower, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFollowersAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", Endpoints.Followers, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetBothFollowingAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", Endpoints.Followers, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<Athlete> UpdateAthleteAsync(AthleteParameter parameter, String value)
        {
            String putUrl = String.Empty;

            switch (parameter)
            {
                case AthleteParameter.City:
                    putUrl = String.Format("{0}?city={1}&access_token={2}", Endpoints.Athlete, value, Authentication.AccessToken);
                    break;
                case AthleteParameter.Country:
                    putUrl = String.Format("{0}?country={1}&access_token={2}", Endpoints.Athlete, value, Authentication.AccessToken);
                    break;
                case AthleteParameter.State:
                    putUrl = String.Format("{0}?state={1}&access_token={2}", Endpoints.Athlete, value, Authentication.AccessToken);
                    break;
                case AthleteParameter.Weight:
                    putUrl = String.Format("{0}?weight={1}&access_token={2}", Endpoints.Athlete, value, Authentication.AccessToken);
                    break;
            }

            String json = await WebRequest.SendPutAsync(new Uri(putUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        public async Task<Athlete> UpdateAthleteSex(Gender gender)
        {
            String putUrl = String.Format("{0}?sex={1}&access_token={2}", Endpoints.Athlete, gender.ToString().Substring(0, 1), Authentication.AccessToken);
            String json = await WebRequest.SendPutAsync(new Uri(putUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        #endregion

        #region Sync

        public Athlete GetAthlete()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Athlete, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        public AthleteSummary GetAthlete(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Athlete, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<AthleteSummary>.Unmarshal(json);
        }

        public List<AthleteSummary> GetFriends()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Friends, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetFriends(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", Endpoints.Friends, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetFollowers()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Follower, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetFollowers(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", Endpoints.Followers, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetBothFollowing(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", Endpoints.Followers, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public Athlete UpdateAthlete(AthleteParameter parameter, String value)
        {
            String putUrl = String.Empty;

            switch (parameter)
            {
                case AthleteParameter.City:
                    putUrl = String.Format("{0}?city={1}&access_token={2}", Endpoints.Athlete, value, Authentication.AccessToken);
                    break;
                case AthleteParameter.Country:
                    putUrl = String.Format("{0}?country={1}&access_token={2}", Endpoints.Athlete, value, Authentication.AccessToken);
                    break;
                case AthleteParameter.State:
                    putUrl = String.Format("{0}?state={1}&access_token={2}", Endpoints.Athlete, value, Authentication.AccessToken);
                    break;
                case AthleteParameter.Weight:
                    putUrl = String.Format("{0}?weight={1}&access_token={2}", Endpoints.Athlete, value, Authentication.AccessToken);
                    break;
            }

            String json = WebRequest.SendPut(new Uri(putUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        #endregion
    }
}
