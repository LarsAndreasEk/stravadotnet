using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using com.strava.api.Api;

namespace com.strava.api.Http
{
    public static class WebRequest
    {
        public static async Task<String> SendGetAsync(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
            }

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);

                //Request was successful
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Getting the Strava API usage data.
                    KeyValuePair<String, IEnumerable<String>> usage = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Usage"));

                    if (usage.Value != null)
                    {
                        //Setting the related Properties in the Limits-class.
                        Limits.Usage = new Usage(Int32.Parse(usage.Value.ElementAt(0).Split(',')[0]),
                            Int32.Parse(usage.Value.ElementAt(0).Split(',')[1]));
                    }

                    return await response.Content.ReadAsStringAsync();
                }
            }

            return String.Empty;
        }

        public static async Task<String> SendPostAsync(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
            }

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PostAsync(uri, null);

                //Request was successful
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return String.Empty;
        }

        public static async Task<String> SendPutAsync(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
            }

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PutAsync(uri, null);

                //Request was successful
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return String.Empty;
        }
    }
}
