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
using com.strava.api.Segments;
using com.strava.api.Utilities;

namespace com.strava.api.Client
{
    public class StravaClient
    {
        private readonly IAuthentication _authenticator;

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

        #region Events

        public event EventHandler<ActivityReceivedEventArgs> ActivityReceived; 

        #endregion

        #region Async

        #region Activity

        public async Task<Activity> GetActivityAsync(String id, bool includeEfforts)
        {
            String getUrl = String.Format("{0}/{1}?include_all_efforts={2}&access_token={3}", Endpoints.Activity, id, includeEfforts, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Activity>.Unmarshal(json);
        }

        public async Task<List<ActivitySummary>> GetActivityBeforeAsync(String id, DateTime before)
        {
            //Calculate the UNIX epoch
            long secondsBefore = DateConverter.GetSecondsSinceUnixEpoch(before);

            String getUrl = String.Format("{0}/{1}?before={2}&access_token={3}",
                Endpoints.Activities,
                id,
                secondsBefore,
                _authenticator.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public async Task<List<ActivitySummary>> GetActivityAfterAsync(String id, DateTime after)
        {
            //Calculate the UNIX epoch
            long secondsAfter = DateConverter.GetSecondsSinceUnixEpoch(after);

            String getUrl = String.Format("{0}/{1}?after={2}&access_token={3}",
                Endpoints.Activities,
                id,
                secondsAfter,
                _authenticator.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public async Task<List<Activity>> GetActivityAsync(String id, int page, int perPage)
        {
            if (perPage > 200)
            {
                throw new ArgumentException("The 'perPage' parameter must not be greater than 200.");
            }

            String getUrl = String.Format("{0}/{1}?per_page={2}&page={3}&access_token={4}",
                Endpoints.Activities,
                id,
                perPage,
                page,
                _authenticator.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Activity>>.Unmarshal(json);
        }

        public async Task<List<Comment>> GetCommentsAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/comments?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Comment>>.Unmarshal(json);
        }

        public async void DeleteActivity(String activityId)
        {
            String deleteUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Activities, activityId, _authenticator.AccessToken);

            await WebRequest.SendDeleteAsync(new Uri(deleteUrl));
        }

        public async Task<List<Athlete>> GetKudosAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/kudos?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        public async Task<List<ActivityZone>> GetActivityZonesAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/zones?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivityZone>>.Unmarshal(json);
        }

        public async Task<List<ActivitySummary>> GetActivitiesAsync(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.Activities, page, perPage, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public async Task<List<ActivitySummary>> GetFollowersActivitiesAsync(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.ActivitiesFollowers, page, perPage, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public async Task<List<ActivitySummary>> GetLatestFriendsActivitiesAsync(int count)
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            int page = 1;
            bool hasEntries = true;

            while (hasEntries)
            {
                List<ActivitySummary> request = await GetFollowersActivitiesAsync(page++, 20);

                if (request.Count == 0)
                {
                    hasEntries = false;
                }

                foreach (ActivitySummary activity in request)
                {
                    if (activities.Count < count)
                    {
                        activities.Add(activity);
                    }
                    else
                    {
                        return activities;
                    }
                }
            }

            return activities;
        }

        public async Task<List<ActivitySummary>> GetAllActivitiesAsync()
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            int page = 1;
            bool hasEntries = true;

            while (hasEntries)
            {
                List<ActivitySummary> request = await GetActivitiesAsync(page++, 200);

                if (request.Count == 0)
                {
                    hasEntries = false;
                }

                foreach (ActivitySummary activity in request)
                {
                    activities.Add(activity);

                    if (ActivityReceived != null)
                    {
                        ActivityReceived(null, new ActivityReceivedEventArgs(activity));
                    }
                }
            }

            return activities;
        }

        public async Task<int> GetTotalActivityCountAsync()
        {
            List<ActivitySummary> activities = await GetAllActivitiesAsync();
            return activities.Count;
        }
        
        #endregion

        #region Athlete

        public async Task<Athlete> GetAthleteAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Athlete, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        public async Task<AthleteSummary> GetAthleteAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Athlete, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<AthleteSummary>.Unmarshal(json);
        }
        
        public async Task<List<AthleteSummary>> GetFriendsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Friends, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFriendsAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", Endpoints.Friends, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFollowersAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Follower, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetFollowersAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", Endpoints.Followers, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetBothFollowingAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", Endpoints.Followers, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<Athlete> UpdateAthleteAsync(AthleteParameter parameter, String value)
        {
            String putUrl = String.Empty;

            switch (parameter)
            {
                case AthleteParameter.City:
                    putUrl = String.Format("{0}?city={1}&access_token={2}", Endpoints.Athlete, value, _authenticator.AccessToken);
                    break;
                case AthleteParameter.Country:
                    putUrl = String.Format("{0}?country={1}&access_token={2}", Endpoints.Athlete, value, _authenticator.AccessToken);
                    break;
                case AthleteParameter.State:
                    putUrl = String.Format("{0}?state={1}&access_token={2}", Endpoints.Athlete, value, _authenticator.AccessToken);
                    break;
                case AthleteParameter.Weight:
                    putUrl = String.Format("{0}?weight={1}&access_token={2}", Endpoints.Athlete, value, _authenticator.AccessToken);
                    break;
            }

            String json = await WebRequest.SendPutAsync(new Uri(putUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        public async Task<Athlete> UpdateAthleteSex(Gender gender)
        {
            String putUrl = String.Format("{0}?sex={1}&access_token={2}", Endpoints.Athlete, gender.ToString().Substring(0, 1), _authenticator.AccessToken);
            String json = await WebRequest.SendPutAsync(new Uri(putUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        #endregion

        #region Segments

        public async Task<List<SegmentEffort>> GetRecordsAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", Endpoints.Athlete, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        public async Task<List<SegmentSummary>> GetStarredSegmentsAsync()
        {
            String getUrl = String.Format("{0}/?access_token={1}", Endpoints.Starred, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentSummary>>.Unmarshal(json);
        }

        public async Task<Leaderboard> GetFullSegmentLeaderboardAsync(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        public async Task<Leaderboard> GetSegmentLeaderboardAsync(String segmentId, Gender gender)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&access_token={3}",
                Endpoints.Leaderboard, 
                segmentId, 
                gender.ToString().Substring(0, 1),
                _authenticator.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        public async Task<Leaderboard> GetSegmentLeaderboardAsync(String segmentId, Gender gender, AgeGroup age)
        {
            String ageFilter = String.Empty;

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
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
                ageFilter,
                _authenticator.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        public async Task<Leaderboard> GetSegmentLeaderboardAsync(String segmentId, Gender gender, WeightClass weight)
        {
            String weightClass = String.Empty;

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
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
                weightClass,
                _authenticator.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        #endregion

        #region Clubs

        public async Task<Club> GetClubAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Club>.Unmarshal(json);
        }

        public async Task<List<ClubSummary>> GetClubsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Clubs, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ClubSummary>>.Unmarshal(json);
        }

        public async Task<List<AthleteSummary>> GetClubMembersAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/members?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public async Task<List<ActivitySummary>> GetLatestClubActivitiesAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/activities?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
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
                _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        #endregion

        #region General

        public async Task<Athlete> RefreshLimitAndUsageAsync()
        {
            return await GetAthleteAsync();
        }

        #endregion

        #endregion

        #region Sync

        #region Activity

        public Activity GetActivity(String id, bool includeEfforts)
        {
            String getUrl = String.Format("{0}/{1}?include_all_efforts={2}&access_token={3}", Endpoints.Activity, id, includeEfforts, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Activity>.Unmarshal(json);
        }

        public List<ActivitySummary> GetActivityBefore(String id, DateTime before)
        {
            //Calculate the UNIX epoch
            long secondsBefore = DateConverter.GetSecondsSinceUnixEpoch(before);

            String getUrl = String.Format("{0}/{1}?before={2}&access_token={3}",
                Endpoints.Activities,
                id,
                secondsBefore,
                _authenticator.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public List<ActivitySummary> GetActivityAfter(String id, DateTime after)
        {
            //Calculate the UNIX epoch
            long secondsAfter = DateConverter.GetSecondsSinceUnixEpoch(after);

            String getUrl = String.Format("{0}/{1}?after={2}&access_token={3}",
                Endpoints.Activities,
                id,
                secondsAfter,
                _authenticator.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public List<Activity> GetActivity(String id, int page, int perPage)
        {
            if (perPage > 200)
            {
                throw new ArgumentException("The 'perPage' parameter must not be greater than 200.");
            }

            String getUrl = String.Format("{0}/{1}?per_page={2}&page={3}&access_token={4}",
                Endpoints.Activities,
                id,
                perPage,
                page,
                _authenticator.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<Activity>>.Unmarshal(json);
        }

        public List<Comment> GetComments(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/comments?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<Comment>>.Unmarshal(json);
        }

        public List<Athlete> GetKudos(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/kudos?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        public List<ActivityZone> GetActivityZones(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/zones?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivityZone>>.Unmarshal(json);
        }

        public List<ActivitySummary> GetActivities(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.Activities, page, perPage, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public List<ActivitySummary> GetFollowersActivities(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.ActivitiesFollowers, page, perPage, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public List<ActivitySummary> GetAllActivities()
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            int page = 1;
            bool hasEntries = true;

            while (hasEntries)
            {
                List<ActivitySummary> request = GetActivities(page++, 200);

                if (request.Count == 0)
                {
                    hasEntries = false;
                }

                foreach (ActivitySummary activity in request)
                {
                    activities.Add(activity);

                    if (ActivityReceived != null)
                    {
                        ActivityReceived(null, new ActivityReceivedEventArgs(activity));
                    }
                }
            }

            return activities;
        }

        public List<ActivitySummary> GetLatestFriendsActivities(int count)
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            int page = 1;
            bool hasEntries = true;

            while (hasEntries)
            {
                List<ActivitySummary> request = GetFollowersActivities(page++, 20);

                if (request.Count == 0)
                {
                    hasEntries = false;
                }

                foreach (ActivitySummary activity in request)
                {
                    if (activities.Count < count)
                    {
                        activities.Add(activity);
                    }
                    else
                    {
                        return activities;
                    }
                }
            }

            return activities;
        }

        public int GetTotalActivityCount()
        {
            return GetAllActivities().Count;
        }

        #endregion

        #region Athlete

        public Athlete GetAthlete()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Athlete, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        public AthleteSummary GetAthlete(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Athlete, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<AthleteSummary>.Unmarshal(json);
        }

        public List<AthleteSummary> GetFriends()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Friends, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetFriends(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", Endpoints.Friends, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetFollowers()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Follower, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetFollowers(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", Endpoints.Followers, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetBothFollowing(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", Endpoints.Followers, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public Athlete UpdateAthlete(AthleteParameter parameter, String value)
        {
            String putUrl = String.Empty;

            switch (parameter)
            {
                case AthleteParameter.City:
                    putUrl = String.Format("{0}?city={1}&access_token={2}", Endpoints.Athlete, value, _authenticator.AccessToken);
                    break;
                case AthleteParameter.Country:
                    putUrl = String.Format("{0}?country={1}&access_token={2}", Endpoints.Athlete, value, _authenticator.AccessToken);
                    break;
                case AthleteParameter.State:
                    putUrl = String.Format("{0}?state={1}&access_token={2}", Endpoints.Athlete, value, _authenticator.AccessToken);
                    break;
                case AthleteParameter.Weight:
                    putUrl = String.Format("{0}?weight={1}&access_token={2}", Endpoints.Athlete, value, _authenticator.AccessToken);
                    break;
            }

            String json = WebRequest.SendPut(new Uri(putUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        #endregion

        #region Segments

        public List<SegmentEffort> GetRecords(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", Endpoints.Athlete, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        public List<SegmentSummary> GetStarredSegments()
        {
            String getUrl = String.Format("{0}/?access_token={1}", Endpoints.Starred, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentSummary>>.Unmarshal(json);
        }

        public Leaderboard GetFullSegmentLeaderboard(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        public Leaderboard GetSegmentLeaderboard(String segmentId, Gender gender)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&access_token={3}",
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
                _authenticator.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        public Leaderboard GetSegmentLeaderboard(String segmentId, Gender gender, AgeGroup age)
        {
            String ageFilter = String.Empty;

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
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
                ageFilter,
                _authenticator.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        public Leaderboard GetSegmentLeaderboard(String segmentId, Gender gender, WeightClass weight)
        {
            String weightClass = String.Empty;

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
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
                weightClass,
                _authenticator.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        #endregion

        #region Clubs

        public Club GetClub(String clubId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Club>.Unmarshal(json);
        }

        public List<ClubSummary> GetClubs()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Clubs, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ClubSummary>>.Unmarshal(json);
        }

        public List<AthleteSummary> GetClubMembers(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/members?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        public List<ActivitySummary> GetLatestClubActivities(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/activities?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
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
                _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        #endregion

        #region General

        public Athlete RefreshLimitAndUsage()
        {
            return GetAthlete();
        }

        #endregion

        #endregion
    }
}
