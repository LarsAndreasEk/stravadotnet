using System.Net;

namespace com.strava.api.Http
{
    public class ResponseReceivedEventArgs
    {
        public HttpWebResponse Response { get; set; }

        public ResponseReceivedEventArgs(HttpWebResponse response)
        {
            Response = response;
        }
    }
}
