using System;
using com.strava.api.Http;

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
            var response = await GetRequest.ExecuteAsync("https://www.strava.com/api/v3/activities/109557593?access_token=72e8fa9d4f63477adc76555de382a033b6aedf6d");
            Console.WriteLine(response);
        }
    }
}
