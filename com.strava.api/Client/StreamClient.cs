using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using com.strava.api.Api;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Http;
using com.strava.api.Streams;

namespace com.strava.api.Client
{
    public class StreamClient : BaseClient
    {
        public StreamClient(IAuthentication auth) : base(auth) { }

        #region Async

        public async Task<List<ActivityStream>> GetActivityStreamAsync(String activityId, StreamType typeFlags)
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

            String getUrl = String.Format("{0}/{1}/streams/{2}?access_token={3}", Endpoints.Activity, activityId, types, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<Streams.ActivityStream>>.Unmarshal(json);
        }

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

            String getUrl = String.Format("{0}/{1}/streams/{2}?access_token={3}", Endpoints.Leaderboard, segmentId, types, Authentication.AccessToken);
            String json = await WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller<List<SegmentStream>>.Unmarshal(json);
        }

        #endregion
        
        #region Sync

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

            String getUrl = String.Format("{0}/{1}/streams/{2}?access_token={3}", Endpoints.Activity, activityId, types, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<ActivityStream>>.Unmarshal(json);
        }

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

            String getUrl = String.Format("{0}/{1}/streams/{2}?access_token={3}", Endpoints.Leaderboard, segmentId, types, Authentication.AccessToken);
            String json = WebRequest.SendGet(new Uri(getUrl));

            return Unmarshaller<List<SegmentStream>>.Unmarshal(json);
        }

        #endregion

    }
}
