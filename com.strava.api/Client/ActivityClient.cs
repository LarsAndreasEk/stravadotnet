using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.strava.api.Activities;
using com.strava.api.Api;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Http;
using com.strava.api.Utilities;

namespace com.strava.api.Client
{
    public class ActivityClient : BaseClient
    {
        public ActivityClient(IAuthentication authentication) : base(authentication) { }

        #region Events

        public event EventHandler<ActivityReceivedEventArgs> ActivityReceived;

        #endregion

        #region Async

        public async Task<Activity> GetActivityAsync(String id, bool includeEfforts)
        {
            String getUrl = String.Format("{0}/{1}?include_all_efforts={2}&access_token={3}", Endpoints.Activity, id, includeEfforts, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Activity>.Unmarshal(json);
        }

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

        public async Task<List<ActivitySummary>> GetActivitiesBeforeAsync(DateTime before, int page, int perPage)
        {
            //Calculate the UNIX epoch
            long secondsBefore = DateConverter.GetSecondsSinceUnixEpoch(before);

            String getUrl = String.Format("{0}?before={1}&page={2}&per_page={3}&access_token={4}",
                Endpoints.Activities,
                secondsBefore,
                page,
                perPage,
                Authentication.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

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

        public async Task<List<ActivitySummary>> GetActivitiesAfterAsync(DateTime after, int page, int perPage)
        {
            //Calculate the UNIX epoch
            long secondsAfter = DateConverter.GetSecondsSinceUnixEpoch(after);

            String getUrl = String.Format("{0}?after={1}&page={2}&per_page={3}&access_token={4}",
                Endpoints.Activities,
                secondsAfter,
                page,
                perPage,
                Authentication.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public async Task<List<Comment>> GetCommentsAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/comments?access_token={2}", Endpoints.Activity, activityId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Comment>>.Unmarshal(json);
        }

        public async void DeleteActivity(String activityId)
        {
            String deleteUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Activities, activityId, Authentication.AccessToken);

            await WebRequest.SendDeleteAsync(new Uri(deleteUrl));
        }

        public async Task<List<Athlete>> GetKudosAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/kudos?access_token={2}", Endpoints.Activity, activityId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        public async Task<List<ActivityZone>> GetActivityZonesAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/zones?access_token={2}", Endpoints.Activity, activityId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivityZone>>.Unmarshal(json);
        }

        public async Task<List<ActivitySummary>> GetActivitiesAsync(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.Activities, page, perPage, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public async Task<List<ActivitySummary>> GetFollowersActivitiesAsync(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.ActivitiesFollowers, page, perPage, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

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

        #region Sync

        public Activity GetActivity(String id, bool includeEfforts)
        {
            String getUrl = String.Format("{0}/{1}?include_all_efforts={2}&access_token={3}", Endpoints.Activity, id, includeEfforts, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Activity>.Unmarshal(json);
        }

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

        public List<ActivitySummary> GetActivitiesBefore(DateTime before, int page, int perPage)
        {
            //Calculate the UNIX epoch
            long secondsBefore = DateConverter.GetSecondsSinceUnixEpoch(before);

            String getUrl = String.Format("{0}?before={1}&page={2}&per_page={3}&access_token={4}",
                Endpoints.Activities,
                secondsBefore,
                page,
                perPage,
                Authentication.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

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

        public List<ActivitySummary> GetActivitiesAfter(DateTime after, int page, int perPage)
        {
            //Calculate the UNIX epoch
            long secondsAfter = DateConverter.GetSecondsSinceUnixEpoch(after);

            String getUrl = String.Format("{0}?after={1}&page={2}&per_page={3}&access_token={4}",
                Endpoints.Activities,
                secondsAfter,
                page,
                perPage,
                Authentication.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public List<Comment> GetComments(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/comments?access_token={2}", Endpoints.Activity, activityId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<Comment>>.Unmarshal(json);
        }

        public List<Athlete> GetKudos(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/kudos?access_token={2}", Endpoints.Activity, activityId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<Athlete>>.Unmarshal(json);
        }

        public List<ActivityZone> GetActivityZones(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/zones?access_token={2}", Endpoints.Activity, activityId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivityZone>>.Unmarshal(json);
        }

        public List<ActivitySummary> GetActivities(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.Activities, page, perPage, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivitySummary>>.Unmarshal(json);
        }

        public List<ActivitySummary> GetFollowersActivities(int page, int perPage)
        {
            String getUrl = String.Format("{0}?page={1}&per_page={2}&access_token={3}", Endpoints.ActivitiesFollowers, page, perPage, Authentication.AccessToken);
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

        public int GetTotalActivityCount()
        {
            return GetAllActivities().Count;
        }

        #endregion
    }
}
