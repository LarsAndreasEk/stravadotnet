using System;
using com.strava.api.Authentication;

namespace com.strava.api.samples
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticAuthentication auth = new StaticAuthentication("6b0c8ccc24c472bdd38f8926fe3edd005fd7f4af");

            GetSingleActivity getSingleActivity = new GetSingleActivity();
            getSingleActivity.Run(auth);

            Console.ReadLine();
        }
    }
}
