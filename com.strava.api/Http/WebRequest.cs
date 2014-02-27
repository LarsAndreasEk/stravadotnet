using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using com.strava.api.Api;

namespace com.strava.api.Http
{
    public static class WebRequest
    {
        public static event EventHandler<AsyncResponseReceivedEventArgs> AsyncResponseReceived;
        public static event EventHandler<ResponseReceivedEventArgs> ResponseReceived;

        public static async Task<String> SendGetAsync(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
            }

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);

                if (response != null)
                {
                    if (AsyncResponseReceived != null)
                    {
                        AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
                    }

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

                        //Getting the Strava API limits
                        KeyValuePair<String, IEnumerable<String>> limit = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Limit"));

                        if (limit.Value != null)
                        {
                            //Setting the related Properties in the Limits-class.
                            Limits.Limit = new Limit(Int32.Parse(limit.Value.ElementAt(0).Split(',')[0]),
                                Int32.Parse(limit.Value.ElementAt(0).Split(',')[1]));
                        }

                        return await response.Content.ReadAsStringAsync();
                    }
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

                if (response != null)
                {
                    if (AsyncResponseReceived != null)
                    {
                        AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
                    }

                    //Getting the Strava API usage data.
                    KeyValuePair<String, IEnumerable<String>> usage = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Usage"));

                    if (usage.Value != null)
                    {
                        //Setting the related Properties in the Limits-class.
                        Limits.Usage = new Usage(Int32.Parse(usage.Value.ElementAt(0).Split(',')[0]),
                            Int32.Parse(usage.Value.ElementAt(0).Split(',')[1]));
                    }

                    //Getting the Strava API limits
                    KeyValuePair<String, IEnumerable<String>> limit = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Limit"));

                    if (limit.Value != null)
                    {
                        //Setting the related Properties in the Limits-class.
                        Limits.Limit = new Limit(Int32.Parse(limit.Value.ElementAt(0).Split(',')[0]),
                            Int32.Parse(limit.Value.ElementAt(0).Split(',')[1]));
                    }

                    //Request was successful
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
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

                if (response != null)
                {
                    if (AsyncResponseReceived != null)
                    {
                        AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
                    }

                    //Getting the Strava API usage data.
                    KeyValuePair<String, IEnumerable<String>> usage = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Usage"));

                    if (usage.Value != null)
                    {
                        //Setting the related Properties in the Limits-class.
                        Limits.Usage = new Usage(Int32.Parse(usage.Value.ElementAt(0).Split(',')[0]),
                            Int32.Parse(usage.Value.ElementAt(0).Split(',')[1]));
                    }

                    //Getting the Strava API limits
                    KeyValuePair<String, IEnumerable<String>> limit = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Limit"));

                    if (limit.Value != null)
                    {
                        //Setting the related Properties in the Limits-class.
                        Limits.Limit = new Limit(Int32.Parse(limit.Value.ElementAt(0).Split(',')[0]),
                            Int32.Parse(limit.Value.ElementAt(0).Split(',')[1]));
                    }

                    //Request was successful
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }

            return String.Empty;
        }

        public static async Task<String> SendDeleteAsync(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
            }

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(uri);

                if (response != null)
                {
                    if (AsyncResponseReceived != null)
                    {
                        AsyncResponseReceived(null, new AsyncResponseReceivedEventArgs(response));
                    }

                    //Getting the Strava API usage data.
                    KeyValuePair<String, IEnumerable<String>> usage = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Usage"));

                    if (usage.Value != null)
                    {
                        //Setting the related Properties in the Limits-class.
                        Limits.Usage = new Usage(Int32.Parse(usage.Value.ElementAt(0).Split(',')[0]),
                            Int32.Parse(usage.Value.ElementAt(0).Split(',')[1]));
                    }

                    //Getting the Strava API limits
                    KeyValuePair<String, IEnumerable<String>> limit = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Limit"));

                    if (limit.Value != null)
                    {
                        //Setting the related Properties in the Limits-class.
                        Limits.Limit = new Limit(Int32.Parse(limit.Value.ElementAt(0).Split(',')[0]),
                            Int32.Parse(limit.Value.ElementAt(0).Split(',')[1]));
                    }

                    //Request was successful
                    if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }

            return String.Empty;
        }

        public static String SendGet(Uri uri)
        {
            HttpWebRequest httpRequest = (HttpWebRequest) System.Net.WebRequest.Create(uri);
            httpRequest.Method = "GET";
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Stream responseStream = httpResponse.GetResponseStream();

            if (responseStream != null)
            {
                if (ResponseReceived != null)
                {
                    ResponseReceived(null, new ResponseReceivedEventArgs(httpResponse));
                }

                StreamReader reader = new StreamReader(responseStream);
                String response = reader.ReadToEnd();

                return response;
            }

            return String.Empty;
        }

        public static String SendPut(Uri uri)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
            httpRequest.Method = "PUT";
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Stream responseStream = httpResponse.GetResponseStream();

            if (responseStream != null)
            {
                if (ResponseReceived != null)
                {
                    ResponseReceived(null, new ResponseReceivedEventArgs(httpResponse));
                }

                StreamReader reader = new StreamReader(responseStream);
                String response = reader.ReadToEnd();

                return response;
            }

            return String.Empty;
        }
    }
}
