using System.Net.Http;

namespace com.strava.api.Http
{
    public class ResponseReceivedEventArgs
    {
        public HttpResponseMessage Response { get; set; }

        public ResponseReceivedEventArgs(HttpResponseMessage response)
        {
            Response = response;
        }
    }
}
