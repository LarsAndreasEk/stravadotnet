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
    public class StravaClient
    {
        private readonly IAuthentication _authenticator;

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

        public ActivityClient Activities { get; set; }
        public AthleteClient Athletes { get; set; }
        public ClubClient Clubs { get; set; }
        public GearClient Gear { get; set; }
        public SegmentClient Segments { get; set; }
        public StreamClient Streams { get; set; }

        #endregion

        #region Events

        public event EventHandler<ActivityReceivedEventArgs> ActivityReceived; 

        #endregion

        #region Async

        #region Activity

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<Activity> GetActivityAsync(String id, bool includeEfforts)
        {
            String getUrl = String.Format("{0}/{1}?include_all_efforts={2}&access_token={3}", Endpoints.Activity, id, includeEfforts, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Activity>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivitySummary>> GetActivitiesBeforeAsync(DateTime before)
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            int page = 1;
            bool hasEntries = true;

            while (hasEntries)
            {
                List<ActivitySummary> request = await GetActivitiesBeforeAsync(before, page++, 200);

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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivitySummary>> GetActivitiesBeforeAsync(DateTime before, int page, int perPage)
        {
            //Calculate the UNIX epoch
            long secondsBefore = DateConverter.GetSecondsSinceUnixEpoch(before);

            String getUrl = String.Format("{0}?before={1}&page={2}&per_page={3}&access_token={4}",
                Endpoints.Activities,
                secondsBefore,
                page,
                perPage,
                _authenticator.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivitySummary>> GetActivitiesAfterAsync(DateTime after)
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            int page = 1;
            bool hasEntries = true;

            while (hasEntries)
            {
                List<ActivitySummary> request = await GetActivitiesAfterAsync(after, page++, 200);

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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivitySummary>> GetActivitiesAfterAsync(DateTime after, int page, int perPage)
        {
            //Calculate the UNIX epoch
            long secondsAfter = DateConverter.GetSecondsSinceUnixEpoch(after);

            String getUrl = String.Format("{0}?after={1}&page={2}&per_page={3}&access_token={4}",
                Endpoints.Activities,
                secondsAfter,
                page,
                perPage,
                _authenticator.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<Comment>> GetCommentsAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/comments?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Comment>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async void DeleteActivity(String activityId)
        {
            String deleteUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Activities, activityId, _authenticator.AccessToken);

            await WebRequest.SendDeleteAsync(new Uri(deleteUrl));
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<Athlete>> GetKudosAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/kudos?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivityZone>> GetActivityZonesAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/zones?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivityZone>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivitySummary>> GetActivitiesAsync(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.Activities, page, perPage, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivitySummary>> GetFollowersActivitiesAsync(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.ActivitiesFollowers, page, perPage, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivitySummary>> GetFriendsActivitiesAsync(int count)
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<int> GetTotalActivityCountAsync()
        {
            List<ActivitySummary> activities = await GetAllActivitiesAsync();
            return activities.Count;
        }
        
        #endregion

        #region Athlete

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<Athlete> GetAthleteAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Athlete, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<AthleteSummary> GetAthleteAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Athlete, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<AthleteSummary>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<AthleteSummary>> GetFriendsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Friends, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<AthleteSummary>> GetFriendsAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", Endpoints.Friends, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<AthleteSummary>> GetFollowersAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Follower, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<AthleteSummary>> GetFollowersAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", Endpoints.Followers, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<AthleteSummary>> GetBothFollowingAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", Endpoints.Followers, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<Athlete> UpdateAthleteSex(Gender gender)
        {
            String putUrl = String.Format("{0}?sex={1}&access_token={2}", Endpoints.Athlete, gender.ToString().Substring(0, 1), _authenticator.AccessToken);
            String json = await WebRequest.SendPutAsync(new Uri(putUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        #endregion

        #region Segments

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<SegmentEffort>> GetRecordsAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", Endpoints.Athlete, athleteId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<SegmentSummary>> GetStarredSegmentsAsync()
        {
            String getUrl = String.Format("{0}/?access_token={1}", Endpoints.Starred, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<Leaderboard> GetFullSegmentLeaderboardAsync(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<Club> GetClubAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Club>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ClubSummary>> GetClubsAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Clubs, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ClubSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<AthleteSummary>> GetClubMembersAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/members?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivitySummary>> GetLatestClubActivitiesAsync(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/activities?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        #region Gear

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<Gear.Gear> GetGearAsync(String gearId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Gear, gearId, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Gear.Gear>.Unmarshal(json);
        }

        #endregion

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<Athlete> RefreshLimitAndUsageAsync()
        {
            return await GetAthleteAsync();
        }

        #region Streams

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<ActivityStream>> GetActivityStreamAsync(String activityId, StreamType typeFlags)
        {
            StringBuilder types = new StringBuilder();

            foreach (StreamType type in (StreamType[]) Enum.GetValues(typeof (StreamType)))
            {
                if (typeFlags.HasFlag(type))
                {
                    types.Append(type.ToString().ToLower());
                    types.Append(",");
                }
            }

            types.Remove(types.ToString().Length - 1, 1);

            String getUrl = String.Format("{0}/{1}/streams/{2}?access_token={3}", Endpoints.Activity, activityId, types, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Streams.ActivityStream>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public async Task<List<SegmentStream>> GetSegmentStreamAsync(String segmentId, SegmentStreamType typeFlags)
        {
            // Only distance, altitude and latlng stream types are available.

            StringBuilder types = new StringBuilder();

            foreach (SegmentStreamType type in (StreamType[])Enum.GetValues(typeof(SegmentStreamType)))
            {
                if (typeFlags.HasFlag(type))
                {
                    types.Append(type.ToString().ToLower());
                    types.Append(",");
                }
            }

            types.Remove(types.ToString().Length - 1, 1);

            String getUrl = String.Format("{0}/{1}/streams/{2}?access_token={3}", Endpoints.Segments, segmentId, types, _authenticator.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentStream>>.Unmarshal(json);
        }

        #endregion

        #endregion

        #region Sync

        #region Activity

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public Activity GetActivity(String id, bool includeEfforts)
        {
            String getUrl = String.Format("{0}/{1}?include_all_efforts={2}&access_token={3}", Endpoints.Activity, id, includeEfforts, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Activity>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivitySummary> GetActivitiesBefore(DateTime before)
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            int page = 1;
            bool hasEntries = true;

            while (hasEntries)
            {
                List<ActivitySummary> request = GetActivitiesBefore(before, page++, 200);

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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivitySummary> GetActivitiesBefore(DateTime before, int page, int perPage)
        {
            //Calculate the UNIX epoch
            long secondsBefore = DateConverter.GetSecondsSinceUnixEpoch(before);

            String getUrl = String.Format("{0}?before={1}&page={2}&per_page={3}&access_token={4}",
                Endpoints.Activities,
                secondsBefore,
                page,
                perPage,
                _authenticator.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivitySummary> GetActivitiesAfter(DateTime after)
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            int page = 1;
            bool hasEntries = true;

            while (hasEntries)
            {
                List<ActivitySummary> request = GetActivitiesAfter(after, page++, 200);

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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivitySummary> GetActivitiesAfter(DateTime after, int page, int perPage)
        {
            //Calculate the UNIX epoch
            long secondsAfter = DateConverter.GetSecondsSinceUnixEpoch(after);

            String getUrl = String.Format("{0}?after={1}&page={2}&per_page={3}&access_token={4}",
                Endpoints.Activities,
                secondsAfter,
                page,
                perPage,
                _authenticator.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<Comment> GetComments(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/comments?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<Comment>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<Athlete> GetKudos(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/kudos?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivityZone> GetActivityZones(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/zones?access_token={2}", Endpoints.Activity, activityId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivityZone>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivitySummary> GetActivities(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.Activities, page, perPage, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivitySummary> GetFollowersActivities(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.ActivitiesFollowers, page, perPage, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivitySummary> GetFriendsActivities(int count)
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public int GetTotalActivityCount()
        {
            return GetAllActivities().Count;
        }

        #endregion

        #region Athlete

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public Athlete GetAthlete()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Athlete, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public AthleteSummary GetAthlete(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Athlete, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<AthleteSummary>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<AthleteSummary> GetFriends()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Friends, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<AthleteSummary> GetFriends(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/friends?access_token={2}", Endpoints.Friends, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<AthleteSummary> GetFollowers()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Follower, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<AthleteSummary> GetFollowers(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/followers?access_token={2}", Endpoints.Followers, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<AthleteSummary> GetBothFollowing(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/both-following?access_token={2}", Endpoints.Followers, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<SegmentEffort> GetRecords(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", Endpoints.Athlete, athleteId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<SegmentSummary> GetStarredSegments()
        {
            String getUrl = String.Format("{0}/?access_token={1}", Endpoints.Starred, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public Leaderboard GetFullSegmentLeaderboard(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public Club GetClub(String clubId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Club>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ClubSummary> GetClubs()
        {
            String getUrl = String.Format("{0}?access_token={1}", Endpoints.Clubs, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ClubSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<AthleteSummary> GetClubMembers(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/members?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<AthleteSummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivitySummary> GetLatestClubActivities(String clubId)
        {
            String getUrl = String.Format("{0}/{1}/activities?access_token={2}", Endpoints.Club, clubId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
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

        #region Gear

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public Gear.Gear GetGear(String gearId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Gear, gearId, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Gear.Gear>.Unmarshal(json);
        }

        #endregion

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public Athlete RefreshLimitAndUsage()
        {
            return GetAthlete();
        }

        #region Streams

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<ActivityStream> GetActivityStream(String activityId, StreamType typeFlags)
        {
            StringBuilder types = new StringBuilder();

            foreach (StreamType type in (StreamType[])Enum.GetValues(typeof(StreamType)))
            {
                if (typeFlags.HasFlag(type))
                {
                    types.Append(type.ToString().ToLower());
                    types.Append(",");
                }
            }

            types.Remove(types.ToString().Length - 1, 1);

            String getUrl = String.Format("{0}/{1}/streams/{2}?access_token={3}", Endpoints.Activity, activityId, types, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivityStream>>.Unmarshal(json);
        }

        [Obsolete("This method is out of date. Please use the StravaClient Client objects. This method will be removed in a future release.")]
        public List<SegmentStream> GetSegmentStream(String segmentId, SegmentStreamType typeFlags)
        {
            // Only distance, altitude and latlng stream types are available.

            StringBuilder types = new StringBuilder();

            foreach (SegmentStreamType type in (StreamType[])Enum.GetValues(typeof(SegmentStreamType)))
            {
                if (typeFlags.HasFlag(type))
                {
                    types.Append(type.ToString().ToLower());
                    types.Append(",");
                }
            }

            types.Remove(types.ToString().Length - 1, 1);

            String getUrl = String.Format("{0}/{1}/streams/{2}?access_token={3}", Endpoints.Segments, segmentId, types, _authenticator.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentStream>>.Unmarshal(json);
        }

        #endregion

        #endregion

        public override string ToString()
        {
            return String.Format("StravaClient Version {0}", Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}
