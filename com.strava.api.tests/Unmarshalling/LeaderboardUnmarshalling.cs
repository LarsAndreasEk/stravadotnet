using System;
using com.strava.api.Activities;
using com.strava.api.Common;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class LeaderboardUnmarshalling
    {
        private readonly String _json = Resources.LeaderboardJson;

        [TestMethod]
        public void TestLeaderboardUnmarshalling()
        {
            Leaderboard l = Unmarshaller<Leaderboard>.Unmarshal(_json);
            Assert.IsNotNull(l);
        }
    }
}
