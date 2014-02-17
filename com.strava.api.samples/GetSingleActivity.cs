using System;
using com.strava.api.Activities;
using com.strava.api.Authentication;
using com.strava.api.Client;

namespace com.strava.api.samples
{
    public class GetSingleActivity : ISample
    {
        public async void Run(IAuthentication auth)
        {
            StravaClient client = new StravaClient(auth);

            Console.WriteLine("Loading activity...");
            Activity activity = await client.GetActivityAsync("101703972");

            Console.WriteLine("Activity: {0}", activity.Name);
            Console.WriteLine("Distance: {0} km", (activity.Distance / 1000D).ToString("#.##"));
        }
    }
}
