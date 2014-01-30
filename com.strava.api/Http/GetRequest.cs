using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace com.strava.api.Http
{
    public static class GetRequest
    {
        public static async Task<String> ExecuteAsync(string uri)
        {
            if (String.IsNullOrEmpty(uri))
                throw new ArgumentException("Parameter requestUri can not be null or empty. Please commit a valid Uri.");
            
            //  Anfrage
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            WebResponse response = await request.GetResponseAsync();

            //  Auslesen
            if (response != null)
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                return reader.ReadToEnd();
            }


            return String.Empty;
        }
    }
}
