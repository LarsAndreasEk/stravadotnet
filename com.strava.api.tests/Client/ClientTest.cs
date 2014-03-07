using System;
using com.strava.api.Authentication;
using com.strava.api.Client;
using com.strava.api.Streams;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Client
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async void TestFalseFlag()
        {
            DummyAuthenticator dummy = new DummyAuthenticator();
            StravaClient client = new StravaClient(dummy);
            await client.Streams.GetActivityStreamAsync(String.Empty, StreamType.LatLng);
        }
    }

    public class DummyAuthenticator : IAuthentication
    {
        public string AccessToken { get; set; }
    }
}
