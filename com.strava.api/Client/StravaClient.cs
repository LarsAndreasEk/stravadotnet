using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.strava.api.Activities;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Http;
using com.strava.api.Segments;

namespace com.strava.api.Client
{
    public class StravaClient
    {
        private IAuthentication _authenticator;

        private const String ActivityUrl = "https://www.strava.com/api/v3/activities";

        private const String CurrentAthleteUrl = "https://www.strava.com/api/v3/athlete";
        private const String AthleteUrl = "https://www.strava.com/api/v3/athletes";

        private const String CurrentAthleteFriendsUrl = "https://www.strava.com/api/v3/athlete/friends";
        private const String FriendsUrl = "https://www.strava.com/api/v3/athletes";

        private const String CurrentFollowerUrl = "https://www.strava.com/api/v3/athlete/followers";
        private const String FollowerUrl = "https://www.strava.com/api/v3/athletes";

        private const String StarredUrl = "https://www.strava.com/api/v3/segments/starred";

        private const String LeaderboardUrl = "https://www.strava.com/api/v3/segments";

        public StravaClient(IAuthentication authenticator)
        {
            if (authenticator != null)
            {
                _authenticator = authenticator;    
            }
            else
            {
                throw new ArgumentException("The IAuthentication object must not be null.");
            }
        }

        #region Activity

        public async Task<Activity> GetActivityAsync(string id)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", ActivityUrl, id, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Activity>.Unmarshal(json);
        }

        #endregion

        #region Athlete

        public async Task<Athlete> GetAthleteAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", CurrentAthleteUrl, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        public async Task<Athlete> GetAthleteAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", AthleteUrl, athleteId, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Athlete>.Unmarshal(json);
        }
        
        public async Task<List<Athlete>> GetFriends()
        {
            String getUrl = String.Format("{0}?access_token={1}", CurrentAthleteFriendsUrl, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        public async Task<List<Athlete>> GetFriendsAsync(string athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", FriendsUrl, athleteId, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        public async Task<List<Athlete>> GetFollowersAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", CurrentFollowerUrl, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        public async Task<List<Athlete>> GetFollowersAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", FollowerUrl, athleteId, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        public async Task<List<Athlete>> GetBothFollowingAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", FollowerUrl, athleteId, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        #endregion

        #region Segments

        public async Task<List<SegmentEffort>> GetRecordsAsync(string athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", AthleteUrl, athleteId, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        public async Task<List<Segment>> GetStarredSegmentsAsync()
        {
            String getUrl = String.Format("{0}/?access_token={1}", StarredUrl, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<Segment>>.Unmarshal(json);
        }

        public async Task<Leaderboard> GetSegmentLeaderboardAsync(string segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?access_token={2}", LeaderboardUrl, segmentId, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        #endregion
    }
}
