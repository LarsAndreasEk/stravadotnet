using System;
using System.IO;
using System.Net;
using System.Text;
using com.strava.api.Activities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.strava.api.Http
{
    public class GetRequest
    {
        public GetRequest()
        {
            
        }

        public void Execute(string requestUri)
        {
            // GET https://www.strava.com/api/v3/activities/109557593?access_token=72e8fa9d4f63477adc76555de382a033b6aedf6d
            // 72e8fa9d4f63477adc76555de382a033b6aedf6d

            HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(new Uri("https://www.strava.com/api/v3/activities/109557593?access_token=72e8fa9d4f63477adc76555de382a033b6aedf6d"));
            Stream stream = request.GetResponse().GetResponseStream();

            StreamReader reader = new StreamReader(stream);

            StringBuilder json = new StringBuilder();
            
            while (!reader.EndOfStream)
            {
                json.Append(reader.ReadLine());
            }

            var root = JsonConvert.DeserializeObject<Activity>(json.ToString());

            Console.WriteLine(root.KudosCount);
            Console.WriteLine(root.ExternalId);

            //Console.WriteLine(json);
        }
    }
}
