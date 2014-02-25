using System.Net.Http;

namespace com.strava.api.Http
{
    public class AsyncResponseReceivedEventArgs
    {
        public HttpResponseMessage Response { get; set; }

        public AsyncResponseReceivedEventArgs(HttpResponseMessage response)
        {
            Response = response;
        }
    }
}
