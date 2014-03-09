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
    /// <summary>
    /// Used to get activity data from Strava.
    /// </summary>
    public class ActivityClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the ActivityClient class.
        /// </summary>
        /// <param name="auth">A IAuthenticator object that contains a valid Strava access token.</param>
        public ActivityClient(IAuthentication auth) : base(auth) { }

        #region Events

        /// <summary>
        /// ActivityReceived is raised whenever an activity is received from Strava.
        /// </summary>
        public event EventHandler<ActivityReceivedEventArgs> ActivityReceived;

        #endregion

        #region Async

        /// <summary>
        /// Gets a single activity from Strava asynchronously.
        /// </summary>
        /// <param name="id">The Strava activity id.</param>
        /// <param name="includeEfforts">Used to include all segment efforts in the result.</param>
        /// <returns>The activity with the specified id.</returns>
        public async Task<Activity> GetActivityAsync(String id, bool includeEfforts)
        {
            String getUrl = String.Format("{0}/{1}?include_all_efforts={2}&access_token={3}", Endpoints.Activity, id, includeEfforts, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Activity>.Unmarshal(json);
        }

        /// <summary>
        /// Gets all the activities recorded before the specified date from Strava asynchronously.
        /// </summary>
        /// <param name="before">The date.</param>
        /// <returns>A list of activities recorded before the specified date.</returns>
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

        /// <summary>
        /// Gets all the activities recorded before the specified date from Strava asynchronously.
        /// </summary>
        /// <param name="before">The date.</param>
        /// <param name="page">The page of the list of activities.</param>
        /// <param name="perPage">The amount of activities per page.</param>
        /// <returns>A list of activities recorded before the specified date.</returns>
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

        /// <summary>
        /// Gets all the activities recorded after the specified date from Strava asynchronously.
        /// </summary>
        /// <param name="after">The date.</param>
        /// <returns>A list of activities recorded after the specified date.</returns>
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

        /// <summary>
        /// Gets all the activities recorded after the specified date from Strava asynchronously.
        /// </summary>
        /// <param name="after">The date.</param>
        /// <param name="page">The page of the list of activities.</param>
        /// <param name="perPage">The amount of activities per page.</param>
        /// <returns>A list of activities recorded after the specified date.</returns>
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

        /// <summary>
        /// Gets all the comments of an activity asynchronously.
        /// </summary>
        /// <param name="activityId">The Strava Id of the activity.</param>
        /// <returns>A list of comments.</returns>
        public async Task<List<Comment>> GetCommentsAsync(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/comments?access_token={2}", Endpoints.Activity, activityId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Comment>>.Unmarshal(json);
        }

        /// <summary>
        /// Deletes an activity on Strava.
        /// </summary>
        /// <param name="activityId">The Strava Id of the activity to delete.</param>
        public async void DeleteActivity(String activityId)
        {
            String deleteUrl = String.Format("{0}/{1}?access_token={2}", Endpoints.Activities, activityId, Authentication.AccessToken);

            await WebRequest.SendDeleteAsync(new Uri(deleteUrl));
        }

        /// <summary>
        /// Gets a list of athletes that kudoed the specified activity asynchronously.
        /// </summary>
        /// <param name="activityId">The Strava Id of the activity.</param>
        /// <returns>A list of athletes that kudoed the specified activity.</returns>
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

        /// <summary>
        /// Gets all the activities asynchronously. Pagination is supported.
        /// </summary>
        /// <param name="page">The page of activities.</param>
        /// <param name="perPage">The amount of activities that are loaded per page.</param>
        /// <returns>A list of activities.</returns>
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

        /// <summary>
        /// Gets the total activity count of the currently authenticated athlete asynchronously.
        /// </summary>
        /// <returns>The total number of activities.</returns>
        public async Task<int> GetTotalActivityCountAsync()
        {
            List<ActivitySummary> activities = await GetAllActivitiesAsync();
            return activities.Count;
        }

        #endregion

        #region Sync

        /// <summary>
        /// Gets a single activity from Strava.
        /// </summary>
        /// <param name="id">The Strava activity id.</param>
        /// <param name="includeEfforts">Indicates whether efforts are included in the result or not.</param>
        /// <returns>The activity with the specified id.</returns>
        public Activity GetActivity(String id, bool includeEfforts)
        {
            String getUrl = String.Format("{0}/{1}?include_all_efforts={2}&access_token={3}", Endpoints.Activity, id, includeEfforts, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Activity>.Unmarshal(json);
        }

        /// <summary>
        /// Gets all the activities recorded before the specified date from Strava.
        /// </summary>
        /// <param name="before">The date.</param>
        /// <returns>A list of activities recorded before the specified date.</returns>
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

        /// <summary>
        /// Gets all the activities recorded before the specified date from Strava.
        /// </summary>
        /// <param name="before">The date.</param>
        /// <param name="page">The page of the list of activities.</param>
        /// <param name="perPage">The amount of activities per page.</param>
        /// <returns>A list of activities recorded before the specified date.</returns>
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

        /// <summary>
        /// Gets all the activities recorded after the specified date from Strava.
        /// </summary>
        /// <param name="after">The date.</param>
        /// <returns>A list of activities recorded after the specified date.</returns>
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

        /// <summary>
        /// Gets all the activities recorded after the specified date from Strava.
        /// </summary>
        /// <param name="after">The date.</param>
        /// <param name="page">The page of the list of activities.</param>
        /// <param name="perPage">The amount of activities per page.</param>
        /// <returns>A list of activities recorded after the specified date.</returns>
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

        /// <summary>
        /// Gets all the comments of an activity.
        /// </summary>
        /// <param name="activityId">The Strava Id of the activity.</param>
        /// <returns>A list of comments.</returns>
        public List<Comment> GetComments(String activityId)
        {
            String getUrl = String.Format("{0}/{1}/comments?access_token={2}", Endpoints.Activity, activityId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<Comment>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets a list of athletes that kudoed the specified activity.
        /// </summary>
        /// <param name="activityId">The Strava Id of the activity.</param>
        /// <returns>A list of athletes that kudoed the specified activity.</returns>
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

        /// <summary>
        /// Gets all the activities. Pagination is supported.
        /// </summary>
        /// <param name="page">The page of activities.</param>
        /// <param name="perPage">The amount of activities that are loaded per page.</param>
        /// <returns>A list of activities.</returns>
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

        /// <summary>
        /// Gets the latest activities of the currently authenticated athletes friends.
        /// </summary>
        /// <param name="count">Specifies how many activities should be loaded.</param>
        /// <returns>A list of activities from your friends.</returns>
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

        /// <summary>
        /// Gets the total activity count of the currently authenticated athlete.
        /// </summary>
        /// <returns>The number of activities.</returns>
        public int GetTotalActivityCount()
        {
            return GetAllActivities().Count;
        }

        #endregion
    }
}
