using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using com.strava.api.Activities;
using com.strava.api.Api;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Http;
using com.strava.api.Segments;

namespace com.strava.api.Client
{
    /// <summary>
    /// Segments are specific sections of road. Athletes’ times are compared on these segments and leaderboards are created.
    /// With this client you can get various data about segments.
    /// </summary>
    public class SegmentClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the SegmentClient class.
        /// </summary>
        /// <param name="auth">IAuthentication object containing a valid Strava access token.</param>
        public SegmentClient(IAuthentication auth) : base(auth) { }

        #region Async

        /// <summary>
        /// Gets all the records of an athlete asynchronously.
        /// </summary>
        /// <param name="athleteId">The Strava athlete id.</param>
        /// <returns>A list of segments where the athlete is the record holder.</returns>
        public async Task<List<SegmentEffort>> GetRecordsAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", Endpoints.Athlete, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets all the starred segments of the currently authenticated athlete asynchronously.
        /// </summary>
        /// <returns>A list of segments that are starred by the currently authenticated athlete.</returns>
        public async Task<List<SegmentSummary>> GetStarredSegmentsAsync()
        {
            String getUrl = String.Format("{0}/?access_token={1}", Endpoints.Starred, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the full and unfiltered leaderboard of a Strava segment asynchronously.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <returns>The full and unfiltered leaderboard></returns>
        public async Task<Leaderboard> GetFullSegmentLeaderboardAsync(String segmentId)
        {
            int page = 1;

            //Create one dummy request to get the number of entries.
            Leaderboard request = await GetSegmentLeaderboardAsync(segmentId, 1, 1);
            int totalAthletes = request.EntryCount;

            Leaderboard leaderboard = new Leaderboard
            {
                EffortCount = request.EffortCount,
                EntryCount = request.EntryCount
            };

            while ((page - 1) * 200 < totalAthletes)
            {
                Leaderboard l = await GetSegmentLeaderboardAsync(segmentId, page++, 200);
                
                foreach (LeaderboardEntry entry in l.Entries)
                {
                    leaderboard.Entries.Add(entry);
                }
            }

            return leaderboard;
        }

        /// <summary>
        /// Gets the leaderboard of a Strava segment.
        /// </summary>
        /// <param name="segmentId">The Strava segment id.</param>
        /// <param name="page">The page.</param>
        /// <param name="perPage">Defines how many entries will be loaded per page.</param>
        /// <returns>The segment leaderboard</returns>
        public async Task<Leaderboard> GetSegmentLeaderboardAsync(String segmentId, int page, int perPage)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&page={2}&per_page={3}&access_token={4}", 
                Endpoints.Leaderboard, 
                segmentId,
                page,
                perPage,
                Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the gender-filtered leaderboard of a segment asynchronsouly. This method requires the currently authenticated 
        /// athlete to have a Strava premium account.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <param name="gender">The gender used to filter the leaderboard.</param>
        /// <returns>The leaderboard filtered by gender.</returns>
        public async Task<Leaderboard> GetSegmentLeaderboardAsync(String segmentId, Gender gender)
        {
            int page = 1;

            //Create one dummy request to get the number of entries.
            Leaderboard request = GetSegmentLeaderboard(segmentId, gender, 1, 1);
            int totalAthletes = request.EntryCount;

            Leaderboard leaderboard = new Leaderboard
            {
                EffortCount = request.EffortCount,
                EntryCount = request.EntryCount
            };

            while ((page - 1) * 200 < totalAthletes)
            {
                Leaderboard l = await GetSegmentLeaderboardAsync(segmentId, gender, page++, 200);

                foreach (LeaderboardEntry entry in l.Entries)
                {
                    leaderboard.Entries.Add(entry);
                }
            }

            return leaderboard;
        }

        /// <summary>
        /// Gets the gender-filtered leaderboard of a segment. This method requires the currently authenticated 
        /// athlete to have a Strava premium account.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <param name="gender">The gender used to filter the leaderboard.</param>
        /// <param name="page">The result page.</param>
        /// <param name="perPage">Efforts shown per page.</param>
        /// <returns>The leaderboard filtered by gender.</returns>
        public async Task<Leaderboard> GetSegmentLeaderboardAsync(String segmentId, Gender gender, int page, int perPage)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&page={3}&per_page={4}&access_token={5}",
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
                page,
                perPage,
                Authentication.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the leaderboard filtered by time.
        /// </summary>
        /// <param name="segmentId">The Strava segment id.</param>
        /// <param name="filter">The time filter.</param>
        /// <returns>A time filtered leaderboard.</returns>
        public async Task<Leaderboard> GetSegmentLeaderboardAsync(String segmentId, TimeFilter filter)
        {
            int page = 1;

            //Create one dummy request to get the number of entries.
            Leaderboard request = await GetSegmentLeaderboardAsync(segmentId, filter, 1, 1);
            int totalAthletes = request.EntryCount;

            Leaderboard leaderboard = new Leaderboard
            {
                EffortCount = request.EffortCount,
                EntryCount = request.EntryCount
            };

            while ((page - 1) * 200 < totalAthletes)
            {
                Leaderboard l = await GetSegmentLeaderboardAsync(segmentId, filter, page++, 200);

                foreach (LeaderboardEntry entry in l.Entries)
                {
                    leaderboard.Entries.Add(entry);
                }
            }

            return leaderboard;
        }

        /// <summary>
        /// Gets the leaderboard filtered by time.
        /// </summary>
        /// <param name="segmentId">The Strava segment id.</param>
        /// <param name="filter">The time filter.</param>
        /// <param name="page">The result page.</param>
        /// <param name="perPage">Entries per page.</param>
        /// <returns>A time filtered leaderboard.</returns>
        public async Task<Leaderboard> GetSegmentLeaderboardAsync(String segmentId, TimeFilter filter, int page, int perPage)
        {
            String fltr = String.Empty;

            // ‘this_year’, ‘this_month’, ‘this_week’, ‘today’
            switch (filter)
            {
                case TimeFilter.ThisMonth:
                    fltr = "this_month";
                    break;
                case TimeFilter.ThisWeek:
                    fltr = "this_week";
                    break;
                case TimeFilter.ThisYear:
                    fltr = "this_year";
                    break;
                case TimeFilter.Today:
                    fltr = "today";
                    break;
            }

            String getUrl = String.Format("{0}/{1}/leaderboard?date_range={2}&page={3}&per_page={4}&access_token={5}",
                Endpoints.Leaderboard,
                segmentId,
                fltr,
                page,
                perPage,
                Authentication.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the gender-filtered and age-filtered leaderboard of a segment asynchronsouly. This method requires the currently authenticated 
        /// athlete to have a Strava premium account.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <param name="gender">The gender used to filter the leaderboard.</param>
        /// /// <param name="age">The age range used to filter the leaderboard.</param>
        /// <returns>The leaderboard filtered by gender and age.</returns>
        public async Task<Leaderboard> GetSegmentLeaderboardAsync(String segmentId, Gender gender, AgeGroup age)
        {
            String ageFilter = String.Empty;

            switch (age)
            {
                case AgeGroup.One:
                    ageFilter = "0_24";
                    break;
                case AgeGroup.Two:
                    ageFilter = "25_34";
                    break;
                case AgeGroup.Three:
                    ageFilter = "35_44";
                    break;
                case AgeGroup.Four:
                    ageFilter = "45_54";
                    break;
                case AgeGroup.Five:
                    ageFilter = "55_64";
                    break;
                case AgeGroup.Six:
                    ageFilter = "65_plus";
                    break;
            }

            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&age_group={3}&filter=age_group&access_token={4}",
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
                ageFilter,
                Authentication.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the gender-filtered and weight-class filtered leaderboard of a segment asynchronsouly. This method requires the currently 
        /// authenticated  athlete to have a Strava premium account.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <param name="gender">The gender used to filter the leaderboard.</param>
        /// /// <param name="weight">The weight class used to filter the leaderboard.</param>
        /// <returns>The leaderboard filtered by gender and weight class.</returns>
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
                Authentication.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the number of entries of a segment.
        /// </summary>
        /// <param name="segmentId">The Strava segment id.</param>
        /// <returns>The total number of entries of the specified Strava segment.</returns>
        public async Task<int> GetSegmentEntryCountAsync(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));
            Leaderboard leaderboard = Unmarshaller<Leaderboard>.Unmarshal(json);

            return leaderboard.EntryCount;
        }

        /// <summary>
        /// Gets the number of efforts of a segment.
        /// </summary>
        /// <param name="segmentId">The Strava segment id.</param>
        /// <returns>The total number of efforts of the specified Strava segment.</returns>
        public async Task<int> GetSegmentEffortCountAsync(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));
            Leaderboard leaderboard = Unmarshaller<Leaderboard>.Unmarshal(json);

            return leaderboard.EffortCount;
        }

        /// <summary>
        /// Returns an array of up to ten segments.
        /// </summary>
        /// <param name="southWest">The south western border of the boundary.</param>
        /// <param name="northEast">The north eastern border of the boundary.</param>
        /// <returns>Up to ten segments within the boundary box. When there are more than ten segments, the ten most 
        /// popular ones will be returned.</returns>
        public async Task<ExplorerResult> ExploreSegmentsAsync(Coordinate southWest, Coordinate northEast)
        {
            String bnds = String.Format("{0},{1},{2},{3}",
                southWest.Latitude.ToString(CultureInfo.InvariantCulture),
                southWest.Longitude.ToString(CultureInfo.InvariantCulture),
                northEast.Latitude.ToString(CultureInfo.InvariantCulture),
                northEast.Longitude.ToString(CultureInfo.InvariantCulture)
                );
            
            String getUrl = String.Format("{0}/explore?bounds={1}&access_token={2}",
                Endpoints.Leaderboard,
                bnds,
                Authentication.AccessToken);

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<ExplorerResult>.Unmarshal(json);
        }

        /// <summary>
        /// Returns an array of up to ten segments.
        /// </summary>
        /// <param name="southWest">The south western border of the boundary.</param>
        /// <param name="northEast">The north eastern border of the boundary.</param>
        /// <param name="minCat">The min category 0-5, lower is harder.</param>
        /// <param name="maxCat">The max category 0-5, lower is harder.</param>
        /// <returns>Up to ten segments within the boundary box. When there are more than ten segments, the ten most 
        /// popular ones will be returned.</returns>
        public async Task<ExplorerResult> ExploreSegmentsAsync(Coordinate southWest, Coordinate northEast, int minCat, int maxCat)
        {
            String bnds = String.Format("{0},{1},{2},{3}",
                southWest.Latitude.ToString(CultureInfo.InvariantCulture),
                southWest.Longitude.ToString(CultureInfo.InvariantCulture),
                northEast.Latitude.ToString(CultureInfo.InvariantCulture),
                northEast.Longitude.ToString(CultureInfo.InvariantCulture)
                );

            String getUrl = String.Format("{0}/explore?bounds={1}&min_cat={2}&max_cat={3}&access_token={4}",
                Endpoints.Leaderboard,
                bnds,
                minCat,
                maxCat,
                Authentication.AccessToken);

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));
            Debug.WriteLine(getUrl);
            return Unmarshaller<ExplorerResult>.Unmarshal(json);
        }

        #endregion

        #region Sync

        /// <summary>
        /// Gets all the records of an athlete.
        /// </summary>
        /// <param name="athleteId">The Strava athlete id.</param>
        /// <returns>A list of segments where the athlete is the record holder.</returns>
        public List<SegmentEffort> GetRecords(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", Endpoints.Athlete, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets all the starred segments of the currently authenticated athlete.
        /// </summary>
        /// <returns>A list of segments that are starred by the currently authenticated athlete.</returns>
        public List<SegmentSummary> GetStarredSegments()
        {
            String getUrl = String.Format("{0}/?access_token={1}", Endpoints.Starred, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentSummary>>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the full and unfiltered leaderboard of a Strava segment.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <returns>The full and unfiltered leaderboard.</returns>
        public Leaderboard GetFullSegmentLeaderboard(String segmentId)
        {
            int page = 1;

            //Create one dummy request to get the number of entries.
            Leaderboard request = GetSegmentLeaderboard(segmentId, 1, 1);
            int totalAthletes = request.EntryCount;

            Leaderboard leaderboard = new Leaderboard
            {
                EffortCount = request.EffortCount,
                EntryCount = request.EntryCount
            };

            while ((page - 1) * 200 < totalAthletes)
            {
                Leaderboard l = GetSegmentLeaderboard(segmentId, page++, 200);

                foreach (LeaderboardEntry entry in l.Entries)
                {
                    leaderboard.Entries.Add(entry);
                }
            }

            return leaderboard;
        }

        /// <summary>
        /// Gets the leaderboard of a Strava segment.
        /// </summary>
        /// <param name="segmentId">The Strava segment id.</param>
        /// <param name="page">The page.</param>
        /// <param name="perPage">Defines how many entries will be loaded per page.</param>
        /// <returns>The segment leaderboard</returns>
        public Leaderboard GetSegmentLeaderboard(String segmentId, int page, int perPage)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&page={2}&per_page={3}&access_token={4}",
                Endpoints.Leaderboard,
                segmentId,
                page,
                perPage,
                Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the gender-filtered leaderboard of a segment. This method requires the currently authenticated 
        /// athlete to have a Strava premium account.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <param name="gender">The gender used to filter the leaderboard.</param>
        /// <returns>The leaderboard filtered by gender.</returns>
        public Leaderboard GetSegmentLeaderboard(String segmentId, Gender gender)
        {
            int page = 1;

            //Create one dummy request to get the number of entries.
            Leaderboard request = GetSegmentLeaderboard(segmentId, gender, 1, 1);
            int totalAthletes = request.EntryCount;

            Leaderboard leaderboard = new Leaderboard
            {
                EffortCount = request.EffortCount,
                EntryCount = request.EntryCount
            };

            while ((page - 1) * 200 < totalAthletes)
            {
                Leaderboard l = GetSegmentLeaderboard(segmentId, gender, page++, 200);

                foreach (LeaderboardEntry entry in l.Entries)
                {
                    leaderboard.Entries.Add(entry);
                }
            }

            return leaderboard;
        }

        /// <summary>
        /// Gets the gender-filtered leaderboard of a segment. This method requires the currently authenticated 
        /// athlete to have a Strava premium account.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <param name="gender">The gender used to filter the leaderboard.</param>
        /// <param name="page">The result page.</param>
        /// <param name="perPage">Efforts shown per page.</param>
        /// <returns>The leaderboard filtered by gender.</returns>
        public Leaderboard GetSegmentLeaderboard(String segmentId, Gender gender, int page, int perPage)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&page={3}&per_page={4}&access_token={5}",
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
                page,
                perPage,
                Authentication.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the gender-filtered and age-filtered leaderboard of a segment. This method requires the currently authenticated 
        /// athlete to have a Strava premium account.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <param name="gender">The gender used to filter the leaderboard.</param>
        /// /// <param name="age">The age range used to filter the leaderboard.</param>
        /// <returns>The leaderboard filtered by gender and age.</returns>
        public Leaderboard GetSegmentLeaderboard(String segmentId, Gender gender, AgeGroup age)
        {
            String ageFilter = String.Empty;

            switch (age)
            {
                case AgeGroup.One:
                    ageFilter = "0_24";
                    break;
                case AgeGroup.Two:
                    ageFilter = "25_34";
                    break;
                case AgeGroup.Three:
                    ageFilter = "35_44";
                    break;
                case AgeGroup.Four:
                    ageFilter = "45_54";
                    break;
                case AgeGroup.Five:
                    ageFilter = "55_64";
                    break;
                case AgeGroup.Six:
                    ageFilter = "65_plus";
                    break;
            }

            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&age_group={3}&filter=age_group&access_token={4}",
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
                ageFilter,
                Authentication.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the gender-filtered and weight-class filtered leaderboard of a segment. This method requires the currently 
        /// authenticated  athlete to have a Strava premium account.
        /// </summary>
        /// <param name="segmentId">The Strava segment Id.</param>
        /// <param name="gender">The gender used to filter the leaderboard.</param>
        /// /// <param name="weight">The weight class used to filter the leaderboard.</param>
        /// <returns>The leaderboard filtered by gender and weight class.</returns>
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
                Authentication.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Gets the number of entries of a segment.
        /// </summary>
        /// <param name="segmentId">The Strava segment id.</param>
        /// <returns>The total number of entries of the specified Strava segment.</returns>
        public int GetSegmentEntryCount(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            Leaderboard leaderboard = Unmarshaller<Leaderboard>.Unmarshal(json);

            return leaderboard.EntryCount;
        }

        /// <summary>
        /// Gets the number of efforts of a segment.
        /// </summary>
        /// <param name="segmentId">The Strava segment id.</param>
        /// <returns>The total number of efforts of the specified Strava segment.</returns>
        public int GetSegmentEffortCount(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));
            Leaderboard leaderboard = Unmarshaller<Leaderboard>.Unmarshal(json);

            return leaderboard.EffortCount;
        }

        /// <summary>
        /// Gets the leaderboard filtered by time.
        /// </summary>
        /// <param name="segmentId">The Strava segment id.</param>
        /// <param name="filter">The time filter.</param>
        /// <returns>A time filtered leaderboard.</returns>
        public Leaderboard GetSegmentLeaderboard(String segmentId, TimeFilter filter)
        {
            String fltr = String.Empty;

            // ‘this_year’, ‘this_month’, ‘this_week’, ‘today’
            switch (filter)
            {
                case TimeFilter.ThisMonth:
                    fltr = "this_month";
                    break;
                case TimeFilter.ThisWeek:
                    fltr = "this_week";
                    break;
                case TimeFilter.ThisYear:
                    fltr = "this_year";
                    break;
                case TimeFilter.Today:
                    fltr = "today";
                    break;
            }

            String getUrl = String.Format("{0}/{1}/leaderboard?filter={2}&access_token={3}",
                Endpoints.Leaderboard,
                segmentId,
                fltr,
                Authentication.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        /// <summary>
        /// Returns an array of up to ten segments.
        /// </summary>
        /// <param name="southWest">The south western border of the boundary.</param>
        /// <param name="northEast">The north eastern border of the boundary.</param>
        /// <returns>Up to ten segments within the boundary box. When there are more than ten segments, the ten most 
        /// popular ones will be returned.</returns>
        public ExplorerResult ExploreSegments(Coordinate southWest, Coordinate northEast)
        {
            String bnds = String.Format("{0},{1},{2},{3}",
                southWest.Latitude.ToString(CultureInfo.InvariantCulture),
                southWest.Longitude.ToString(CultureInfo.InvariantCulture),
                northEast.Latitude.ToString(CultureInfo.InvariantCulture),
                northEast.Longitude.ToString(CultureInfo.InvariantCulture)
                );

            String getUrl = String.Format("{0}/explore?bounds={1}&access_token={2}",
                Endpoints.Leaderboard,
                bnds,
                Authentication.AccessToken);

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<ExplorerResult>.Unmarshal(json);
        }

        /// <summary>
        /// Returns an array of up to ten segments.
        /// </summary>
        /// <param name="southWest">The south western border of the boundary.</param>
        /// <param name="northEast">The north eastern border of the boundary.</param>
        /// <param name="minCat">The min category 0-5, lower is harder.</param>
        /// <param name="maxCat">The max category 0-5, lower is harder.</param>
        /// <returns>Up to ten segments within the boundary box. When there are more than ten segments, the ten most 
        /// popular ones will be returned.</returns>
        public ExplorerResult ExploreSegments(Coordinate southWest, Coordinate northEast, int minCat, int maxCat)
        {
            String bnds = String.Format("{0},{1},{2},{3}",
                southWest.Latitude.ToString(CultureInfo.InvariantCulture),
                southWest.Longitude.ToString(CultureInfo.InvariantCulture),
                northEast.Latitude.ToString(CultureInfo.InvariantCulture),
                northEast.Longitude.ToString(CultureInfo.InvariantCulture)
                );

            String getUrl = String.Format("{0}/explore?bounds={1}&min_cat={2}&max_cat={3}&access_token={4}",
                Endpoints.Leaderboard,
                bnds,
                minCat,
                maxCat,
                Authentication.AccessToken);

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<ExplorerResult>.Unmarshal(json);
        }
        
        #endregion
    }
}
