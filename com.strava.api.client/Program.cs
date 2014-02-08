using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using com.strava.api.Activities;
using com.strava.api.Api;
using com.strava.api.Athletes;
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

            #region Activity
            //ActivityService service = new ActivityService(auth);
            //Activity a = await service.GetActivityAsync("109557593");
            //Console.WriteLine(a.MaxHeartrate);
            #endregion

            //object o = await Http.WebRequest.SendGetAsync(new Uri("https://www.strava.com/api/v3/gear/814946?access_token=72e8fa9d4f63477adc76555de382a033b6aedf6d"));
            //Console.WriteLine(o);


            //Athlete
            AthleteService service = new AthleteService(auth);
            //Athlete a = await service.GetAthleteAsync("3471492");
            //Console.WriteLine(a.FirstName);

            //Athlete current = await service.GetCurrentAthleteAsync();
            //Console.WriteLine(current);

            //List<Athlete> friends = await service.GetCurrentAthleteFriends();
            //List<Athlete> friends = await service.GetFriends("528819");
            //Console.WriteLine(friends.Count);

            //List<Athlete> followers = await service.GetFollowers();
            //List<Athlete> followers = await service.GetFollowers("528819");
            //Console.WriteLine(followers.Count);
        }
    }
}
