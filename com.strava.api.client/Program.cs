using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using com.strava.api.Activities;
using com.strava.api.Api;
using com.strava.api.Athletes;
using com.strava.api.Auth;
using com.strava.api.Authentication;
using com.strava.api.Client;
using com.strava.api.Clubs;
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
            StaticAuthentication auth = new StaticAuthentication("6b0c8ccc24c472bdd38f8926fe3edd005fd7f4af");

            StravaClient client = new StravaClient(auth);

            //WebAuthentication web = new WebAuthentication();
            //web.AuthCodeReceived += delegate(object sender, AuthCodeReceivedEventArgs args) { Console.WriteLine("Auth Code: " + args.AuthCode); };
            //web.AccessTokenReceived += delegate(object sender, TokenReceivedEventArgs args) { Console.WriteLine("Access Token: " + args.Token); };
            //web.GetTokenAsync("605", "87a5085fb5ded25ebb08a72131c1b9c6b1a83c7a", Scope.Full);
            
            #region Activity
            Activity a = await client.GetActivityAsync("109557593");
            Console.WriteLine(a.MaxHeartrate);
            #endregion

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

            #region Leaderboard

            //Leaderboard leaderboard = await client.GetSegmentLeaderboardAsync("5799831", Gender.Male, WeightClass.One);

            //foreach (var entry in leaderboard.Entries)
            //{
            //    Console.WriteLine(entry.AthleteId);
            //    Console.WriteLine(entry.AthleteName);
            //    Console.WriteLine(entry.AverageHeartrate);
            //    Console.WriteLine();
            //}
            
            #endregion

            #region Comments

            //List<Comment> comments = await client.GetCommentsAsync("112861810");

            //foreach (var comment in comments)
            //{
            //    Console.WriteLine(comment.Text);
            //    Console.WriteLine();
            //}

            #endregion

            //List<Athlete> kudoAthletes = await client.GetKudosAsync("112818941");
            
            //foreach (var kudos in kudoAthletes)
            //{
            //    Console.WriteLine(kudos.FirstName);
            //}

            #region Club

            Athlete athlete = await client.GetAthleteAsync();

            foreach (Club club in athlete.Clubs)
            {
                Console.WriteLine(club.Id);
            }

            Club c = await client.GetClubAsync("949");
            Console.WriteLine(c.Name);

            #endregion
        }
    }
}
