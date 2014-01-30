using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace com.strava.api.Http
{
    public static class GetRequest
    {
        public static async Task<String> ExecuteAsync(Uri uri)
        {
            if (uri == null)
                throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return String.Empty;
        }
    }
}
