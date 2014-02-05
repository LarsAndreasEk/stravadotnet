using System;
using com.strava.api.Common;
using com.strava.api.Segments;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class SegmentEffortUnmarshalling
    {
        private readonly String _json = Resources.SegmentEffortJson;

        [TestMethod]
        public void TestSegmentEffortUnmarshalling()
        {
            SegmentEffort effort = Unmarshaller<SegmentEffort>.Unmarshal(_json);
            Assert.IsNotNull(effort);
        }
    }
}
