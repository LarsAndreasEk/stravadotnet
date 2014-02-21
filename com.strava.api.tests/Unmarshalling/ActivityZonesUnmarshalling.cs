using System;
using System.Collections.Generic;
using System.Linq;
using com.strava.api.Activities;
using com.strava.api.Common;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class ActivityZonesUnmarshalling
    {
        private String _json = Resources.ActivityZonesJson;

        [TestMethod]
        public void TestActivityZoneUnmarshalling()
        {
            List<ActivityZone> zone = Unmarshaller<List<ActivityZone>>.Unmarshal(_json);
            Assert.IsNotNull(zone);
        }

        [TestMethod]
        public void TestHeartRateMax()
        {
            List<ActivityZone> zone = Unmarshaller<List<ActivityZone>>.Unmarshal(_json);
            Assert.IsTrue(zone.ElementAt(0).Max.Equals(196));
        }

        [TestMethod]
        public void TestBikeWeight()
        {
            List<ActivityZone> zone = Unmarshaller<List<ActivityZone>>.Unmarshal(_json);
            Assert.IsTrue(zone.ElementAt(1).BikeWeight > 0);
        }

        [TestMethod]
        public void TestBucketSizes()
        {
            List<ActivityZone> zone = Unmarshaller<List<ActivityZone>>.Unmarshal(_json);
            Assert.IsTrue(zone.ElementAt(0).Buckets.Count == 5 && zone.ElementAt(1).Buckets.Count == 11);
        }
    }
}
