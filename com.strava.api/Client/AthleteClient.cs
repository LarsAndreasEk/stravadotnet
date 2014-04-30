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
    /// <summary>
    /// Used to receive information about an athlete from Strava.
    /// </summary>
    public class AthleteClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the AthleteClient class.
        /// </summary>
        /// <param name="auth">The IAuthentication object containing a valid access token.</param>
        public AthleteClient(IAuthentication auth) : base(auth) { }

        #region Async

        /// <summary>
        /// Asynchronously receives the currently authenticated athlete.
        /// </summary>
        /// <returns>The currently authenticated athlete.</returns>
        public async Task<Athlete> GetAthleteAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Athlete, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        /// <summary>
        /// Asynchronously receives the currently authenticated athlete.
        /// </summary>
        /// <param name="athleteId">The Strava Id of the athlete.</param>
        /// <returns>The AthleteSummary object of the athlete.</returns>
        public async Task<AthleteSummary> GetAthleteAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Athletes, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<AthleteSummary>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the friends of the currently authenticated athlete.
        /// </summary>
        /// <returns>A list of the friends of the currently authenticated athlete.</returns>
        public async Task<List<AthleteSummary>> GetFriendsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Friends, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets a list of friends of an athlete.
        /// </summary>
        /// <param name="athleteId">The Strava athlete id.</param>
        /// <returns>The list of friends of the athlete.</returns>
        public async Task<List<AthleteSummary>> GetFriendsAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", Endpoints.Friends, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets all the followers of the currently authenticated athlete.
        /// </summary>
        /// <returns>A list of athletes that follow the currently authenticated athlete.</returns>
        public async Task<List<AthleteSummary>> GetFollowersAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Follower, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Get a list of athletes that follow an athlete.
        /// </summary>
        /// <param name="athleteId">The Strava athlete id.</param>
        /// <returns>A list of athletes that follow the specified athlete.</returns>
        public async Task<List<AthleteSummary>> GetFollowersAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", Endpoints.Followers, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Get a list of athletes that both you and the specified athlete are following.
        /// </summary>
        /// <param name="athleteId">The Strava athlete id.</param>
        /// <returns>A list of athletes that both you and the specified athlete are following.</returns>
        public async Task<List<AthleteSummary>> GetBothFollowingAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", Endpoints.Followers, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Updates the specified parameter of an athlete.
        /// </summary>
        /// <param name="parameter">The parameter that is being updated.</param>
        /// <param name="value">The value to update to.</param>
        /// <returns>Athlete object of the currently authenticated athlete with the updated parameter.</returns>
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

        /// <summary>
        /// Updates the sex of the currently authenticated athlete.
        /// </summary>
        /// <param name="gender">The gender to update to.</param>
        /// <returns>The currently authenticated athlete.</returns>
        public async Task<Athlete> UpdateAthleteSex(Gender gender)
        {
            String putUrl = String.Format("{0}?sex={1}&access_token={2}", Endpoints.Athlete, gender.ToString().Substring(0, 1), Authentication.AccessToken);
            String json = await WebRequest.SendPutAsync(new Uri(putUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        #endregion

        #region Sync

        /// <summary>
        /// Receives the currently authenticated athlete.
        /// </summary>
        /// <returns>The currently authenticated athlete.</returns>
        public Athlete GetAthlete()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Athlete, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        /// <summary>
        /// Receives a Strava athlete.
        /// </summary>
        /// <param name="athleteId">The Strava Id of the athlete.</param>
        /// <returns>The AthleteSummary object of the athlete.</returns>
        public AthleteSummary GetAthlete(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Athletes, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<AthleteSummary>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the friends of the currently authenticated athlete.
        /// </summary>
        /// <returns>A list of the friends of the currently authenticated athlete.</returns>
        public List<AthleteSummary> GetFriends()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Friends, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets a list of friends of an athlete.
        /// </summary>
        /// <param name="athleteId">The Strava athlete id.</param>
        /// <returns>The list of friends of the athlete.</returns>
        public List<AthleteSummary> GetFriends(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", Endpoints.Friends, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets all the followers of the currently authenticated athlete.
        /// </summary>
        /// <returns>A list of athletes that follow the currently authenticated athlete.</returns>
        public List<AthleteSummary> GetFollowers()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Follower, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Get a list of athletes that follow an athlete.
        /// </summary>
        /// <param name="athleteId">The Strava athlete id.</param>
        /// <returns>A list of athletes that follow the specified athlete.</returns>
        public List<AthleteSummary> GetFollowers(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", Endpoints.Followers, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Get a list of athletes that both you and the specified athlete are following.
        /// </summary>
        /// <param name="athleteId">The Strava athlete id.</param>
        /// <returns>A list of athletes that both you and the specified athlete are following.</returns>
        public List<AthleteSummary> GetBothFollowing(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", Endpoints.Followers, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Updates the specified parameter of an athlete.
        /// </summary>
        /// <param name="parameter">The parameter that is being updated.</param>
        /// <param name="value">The value to update to.</param>
        /// <returns>Athlete object of the currently authenticated athlete with the updated parameter.</returns>
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
