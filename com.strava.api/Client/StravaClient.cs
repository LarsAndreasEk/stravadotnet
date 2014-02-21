using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.strava.api.Activities;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Clubs;
using com.strava.api.Common;
using com.strava.api.Http;
using com.strava.api.Segments;

namespace com.strava.api.Client
{
    public class StravaClient
    {
        #region Members

        private readonly IAuthentication _authenticator;

        private const String ActivityUrl = "https://www.strava.com/api/v3/activities";

        private const String CurrentAthleteUrl = "https://www.strava.com/api/v3/athlete";
        private const String AthleteUrl = "https://www.strava.com/api/v3/athletes";

        private const String CurrentAthleteFriendsUrl = "https://www.strava.com/api/v3/athlete/friends";
        private const String FriendsUrl = "https://www.strava.com/api/v3/athletes";

        private const String CurrentFollowerUrl = "https://www.strava.com/api/v3/athlete/followers";
        private const String FollowerUrl = "https://www.strava.com/api/v3/athletes";

        private const String StarredUrl = "https://www.strava.com/api/v3/segments/starred";

        private const String LeaderboardUrl = "https://www.strava.com/api/v3/segments";

        private const String ClubUrl = "https://www.strava.com/api/v3/clubs";
        private const String ClubsUrl = "https://www.strava.com/api/v3/athlete/clubs";

        #endregion

        #region Ctor

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

        #endregion

        #region Methods

        #region Activity

        public async Task<Activity> GetActivityAsync(string id)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", ActivityUrl, id, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Activity>.Unmarshal(json);
        }

        public async Task<List<Comment>> GetCommentsAsync(string activityId)
        {
            String getUrl = String.Format("{0}/{1}/comments?access_token={2}", ActivityUrl, activityId, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<Comment>>.Unmarshal(json);
        }

        public async Task<List<Athlete>> GetKudosAsync(string activityId)
        {
            String getUrl = String.Format("{0}/{1}/kudos?access_token={2}", ActivityUrl, activityId, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        public async Task<List<ActivityZone>> GetActivityZonesAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/zones?access_token={2}", ActivityUrl, activityId, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<ActivityZone>>.Unmarshal(json);
        }

        #endregion

        #region Athlete

        public async Task<Athlete> GetAthleteAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", CurrentAthleteUrl, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        public async Task<AthleteSummary> GetAthleteAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", AthleteUrl, athleteId, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<AthleteSummary>.Unmarshal(json);
        }
        
        public async Task<List<AthleteSummary>> GetFriendsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", CurrentAthleteFriendsUrl, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFriendsAsync(string athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", FriendsUrl, athleteId, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFollowersAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", CurrentFollowerUrl, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFollowersAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", FollowerUrl, athleteId, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetBothFollowingAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", FollowerUrl, athleteId, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        #endregion

        #region Segments

        public async Task<List<SegmentEffort>> GetRecordsAsync(string athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", AthleteUrl, athleteId, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        public async Task<List<SegmentSummary>> GetStarredSegmentsAsync()
        {
            String getUrl = String.Format("{0}/?access_token={1}", StarredUrl, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<List<SegmentSummary>>.Unmarshal(json);
        }

        public async Task<Leaderboard> GetFullSegmentLeaderboardAsync(string segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?access_token={2}", LeaderboardUrl, segmentId, _authenticator.AccessToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        public async Task<Leaderboard> GetSegmentLeaderboardAsync(string segmentId, Gender gender)
        {
            String genderFilter = gender == Gender.Male ? "M" : "F";
            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&access_token={3}",
                LeaderboardUrl, 
                segmentId, 
                genderFilter,
                _authenticator.AccessToken
                );

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// This method requires a Strava premium account.
        /// </summary>
        /// <param name="segmentId"></param>
        /// <param name="gender"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public async Task<Leaderboard> GetSegmentLeaderboardAsync(string segmentId, Gender gender, AgeGroup age)
        {
            String ageFilter = String.Empty;
            String genderFilter = gender == Gender.Male ? "M" : "F";

            switch (age)
            {
                case AgeGroup.TwentyFourAndYounger:
                    ageFilter = "0_24";
                    break;
                case AgeGroup.TwentyFiveToThirtyFour:
                    ageFilter = "25_34";
                    break;
                case AgeGroup.ThirtyFiveToFourtyFour:
                    ageFilter = "35_44";
                    break;
                case AgeGroup.FourtyFiveToFiftyFour:
                    ageFilter = "45_54";
                    break;
                case AgeGroup.FiftyFiveToSixtyFour:
                    ageFilter = "55_64";
                    break;
                case AgeGroup.SixtyFiveAndOver:
                    ageFilter = "65_plus";
                    break;
            }

            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&age_group={3}&filter=age_group&access_token={4}",
                LeaderboardUrl,
                segmentId,
                genderFilter,
                ageFilter,
                _authenticator.AccessToken
                );

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// This method requires a Strava premium account.
        /// </summary>
        /// <param name="segmentId"></param>
        /// <param name="gender"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public async Task<Leaderboard> GetSegmentLeaderboardAsync(string segmentId, Gender gender, WeightClass weight)
        {
            String weightClass = String.Empty;
            String genderFilter = gender == Gender.Male ? "M" : "F";

            switch (weight)
            {
                case WeightClass.One:
                    weightClass = "0_54";
                    break;
                case WeightClass.Two:
                    weightClass = "55_64";
                    break;
                case WeightClass.Three:
                    weightClass = "65_74";
                    break;
                case WeightClass.Four:
                    weightClass = "75_84";
                    break;
                case WeightClass.Five:
                    weightClass = "85_94";
                    break;
                case WeightClass.Six:
                    weightClass = "95_plus";
                    break;
            }

            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&weight_class={3}&filter=weight_class&access_token={4}",
                LeaderboardUrl,
                segmentId,
                genderFilter,
                weightClass,
                _authenticator.AccessToken
                );

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        #endregion

        #region Clubs

        public async Task<Club> GetClubAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", ClubUrl, clubId, _authenticator.AccessToken);

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            // Unmarshalling
            return Unmarshaller<Club>.Unmarshal(json);
        }

        public async Task<List<ClubSummary>> GetClubsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", ClubsUrl, _authenticator.AccessToken);

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            // Unmarshalling
            return Unmarshaller<List<ClubSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetClubMembersAsync(String clubId)
        {
            //https://www.strava.com/api/v3/clubs/1/members
            String getUrl = String.Format("{0}/{1}/members?access_token={2}", ClubUrl, clubId, _authenticator.AccessToken);

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            // Unmarshalling
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        #endregion

        #endregion
    }
}
