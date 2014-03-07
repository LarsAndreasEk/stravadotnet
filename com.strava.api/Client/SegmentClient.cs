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
    public class SegmentClient : BaseClient
    {
        public SegmentClient(IAuthentication auth) : base(auth) { }

        #region Async

        public async Task<List<SegmentEffort>> GetRecordsAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", Endpoints.Athlete, athleteId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        public async Task<List<SegmentSummary>> GetStarredSegmentsAsync()
        {
            String getUrl = String.Format("{0}/?access_token={1}", Endpoints.Starred, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentSummary>>.Unmarshal(json);
        }

        public async Task<Leaderboard> GetFullSegmentLeaderboardAsync(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

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
                Authentication.AccessToken
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
                Authentication.AccessToken
                );

            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

        #endregion

        #region Sync

        public List<SegmentEffort> GetRecords(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}/koms?access_token={2}", Endpoints.Athlete, athleteId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentEffort>>.Unmarshal(json);
        }

        public List<SegmentSummary> GetStarredSegments()
        {
            String getUrl = String.Format("{0}/?access_token={1}", Endpoints.Starred, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentSummary>>.Unmarshal(json);
        }

        public Leaderboard GetFullSegmentLeaderboard(String segmentId)
        {
            String getUrl = String.Format("{0}/{1}/leaderboard?filter=overall&access_token={2}", Endpoints.Leaderboard, segmentId, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }

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
                Authentication.AccessToken
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
                Authentication.AccessToken
                );

            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<Leaderboard>.Unmarshal(json);
        }
        
        #endregion
    }
}
