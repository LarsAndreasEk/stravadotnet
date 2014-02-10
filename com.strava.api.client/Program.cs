using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using com.strava.api.Activities;
using com.strava.api.Api;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Client;
using com.strava.api.Segments;

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

            StravaClient client = new StravaClient(auth);

            #region Activity
            //ActivityService service = new ActivityService(auth);
            //Activity a = await service.GetActivityAsync("109557593");
            //Console.WriteLine(a.MaxHeartrate);
            #endregion

            //object o = await Http.WebRequest.SendGetAsync(new Uri("https://www.strava.com/api/v3/gear/814946?access_token=72e8fa9d4f63477adc76555de382a033b6aedf6d"));
            //Console.WriteLine(o);


            //Athlete
            //Athlete a = await client.GetAthleteAsync("3471492");
            //Console.WriteLine(a.FirstName);

            //Athlete current = await client.GetCurrentAthleteAsync();
            //Console.WriteLine(current);

            //List<Athlete> friends = await client.GetCurrentAthleteFriends();
            //List<Athlete> friends = await client.GetFriends("528819");
            //Console.WriteLine(friends.Count);

            //List<Athlete> followers = await client.GetFollowers();
            //List<Athlete> followers = await client.GetFollowers("528819");
            //Console.WriteLine(followers.Count);

            //List<Athlete> both = await client.GetBothFollowingAsync("528819");
            //Console.WriteLine(both.Count);

            //List<SegmentEffort> records = await client.GetRecordsAsync("528819");

            //foreach (SegmentEffort effort in records)
            //{
            //    Console.WriteLine(effort.Name);
            //}

            //List<Segment> starred = await client.GetStarredSegmentsAsync();
            //Console.WriteLine(starred.Count);

            //#region Leaderboard

            //Leaderboard leaderboard = await client.GetSegmentLeaderboardAsync("1300798");
            
            //foreach (var entry in leaderboard.Entries)
            //{
            //    Console.WriteLine(entry.AthleteId);
            //    Console.WriteLine(entry.AthleteName);
            //    Console.WriteLine(entry.AverageHeartrate);
            //    Console.WriteLine();
            //}
            
            //#endregion

        }
    }
}
