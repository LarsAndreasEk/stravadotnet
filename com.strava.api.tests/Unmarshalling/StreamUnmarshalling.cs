using System;
using com.strava.api.Common;
using com.strava.api.Streams;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class StreamUnmarshalling
    {
        private String _json = Resources.StreamJson;

        [TestMethod]
        public void TestStreamUnmarshalling()
        {
            ActivityStream stream = Unmarshaller<ActivityStream>.Unmarshal(_json);
            Assert.IsNotNull(stream);
        }

        [TestMethod]
        public void TestStreamType()
        {
            ActivityStream stream = Unmarshaller<ActivityStream>.Unmarshal(_json);
            Assert.AreEqual(stream.StreamType, StreamType.LatLng);
        }

        [TestMethod]
        public void TestSeriesType()
        {
            ActivityStream stream = Unmarshaller<ActivityStream>.Unmarshal(_json);
            Assert.AreEqual(stream.SeriesType, "distance");
        }

        [TestMethod]
        public void TestOriginalSize()
        {
            ActivityStream stream = Unmarshaller<ActivityStream>.Unmarshal(_json);
            Assert.AreEqual(stream.OriginalSize, 512);
        }

        [TestMethod]
        public void TestDataCount()
        {
            ActivityStream stream = Unmarshaller<ActivityStream>.Unmarshal(_json);
            Assert.AreEqual(stream.Data.Count, 8);
        }

        [TestMethod]
        public void TestResolution()
        {
            ActivityStream stream = Unmarshaller<ActivityStream>.Unmarshal(_json);
            Assert.AreEqual(stream.Resolution, "low");
        }
    }
}
