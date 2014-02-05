using System;
using com.strava.api.Athletes;
using com.strava.api.Common;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class AthleteUnmarshalling
    {
        private readonly String _json = Resources.AthleteJson;

        [TestMethod]
        public void TestAthleteUnmarshalling()
        {
            Athlete athlete = Unmarshaller<Athlete>.Unmarshal(_json);
            Assert.IsNotNull(athlete);
        }
    }
}
