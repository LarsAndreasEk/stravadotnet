using System;
using com.strava.api.Activities;
using com.strava.api.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class LocationUnmarshalling
    {
        private const String _json = "{ [ 37.839333333, -122.489833333 ] }";

        [TestMethod]
        public void TestLocationUnmarshalling()
        {
            Location location = Unmarshaller<Location>.Unmarshal(_json);
            Assert.IsNotNull(location);
        }
    }
}
