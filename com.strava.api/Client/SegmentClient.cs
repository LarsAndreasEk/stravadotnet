using System;
using System.Collections.Generic;
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
        /// <returns>The full and unfiltered leaderboard.</returns>
        public async Task<Leaderboard> GetFullSegmentLeaderboardAsync(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, Authentication.AccessToken);
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
            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&access_token={3}",
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
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
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, Authentication.AccessToken);
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
            String getUrl = String.Format("{0}/{1}/leaderboard?gender={2}&access_token={3}",
                Endpoints.Leaderboard,
                segmentId,
                gender.ToString().Substring(0, 1),
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
        
        #endregion
    }
}
