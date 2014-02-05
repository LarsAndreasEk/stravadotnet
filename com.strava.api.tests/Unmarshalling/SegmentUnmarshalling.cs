using System;
using com.strava.api.Common;
using com.strava.api.Segments;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class SegmentUnmarshalling
    {
        private readonly String _json = Resources.SegmentJson;

        [TestMethod]
        public void TestSegmentUnmarshalling()
        {
            Segment segment = Unmarshaller<Segment>.Unmarshal(_json);
            Assert.IsNotNull(segment);
        }

        [TestMethod]
        public void TestSegmentId()
        {
            Segment segment = Unmarshaller<Segment>.Unmarshal(_json);
            Assert.IsTrue(segment.Id.Equals(229781));
        }

        [TestMethod]
        public void TestSegmentResourceState()
        {
            Segment segment = Unmarshaller<Segment>.Unmarshal(_json);
            Assert.IsTrue(segment.ResourceState.Equals(3));
        }

        [TestMethod]
        public void TestSegmentName()
        {
            Segment segment = Unmarshaller<Segment>.Unmarshal(_json);
            Assert.IsTrue(segment.Name.Equals("Hawk Hill"));
        }
    }
}
