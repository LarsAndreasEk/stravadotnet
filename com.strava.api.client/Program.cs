using System;
using com.strava.api.Activities;
using com.strava.api.Api;
using com.strava.api.Authentication;

namespace com.strava.api.client
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Test();
            Console.ReadLine();
        }

        public static async void Test()
        {
            StaticAuthentication auth = new StaticAuthentication("72e8fa9d4f63477adc76555de382a033b6aedf6d");

            ActivityService service = new ActivityService(auth);

            Activity a = await service.GetActivityAsync("109557593");

            //   Activity ID
            Console.WriteLine(a.MaxHeartrate);
        }
    }
}
