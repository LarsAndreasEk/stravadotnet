using System;
using System.Text;
using com.strava.api.Streams;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.General
{
    [TestClass]
    public class FlagsTest
    {
        [TestMethod]
        public void TestEnumFlags()
        {
            StreamType typeFlags = StreamType.Altitude | StreamType.Cadence | StreamType.Time;

            StringBuilder types = new StringBuilder();

            foreach (StreamType type in (StreamType[])Enum.GetValues(typeof(StreamType)))
            {
                if (typeFlags.HasFlag(type))
                {
                    types.Append(type.ToString().ToLower());
                    types.Append(",");
                }
            }

            types.Remove(types.ToString().Length - 1, 1);

            Assert.AreEqual(types.ToString(), "time,altitude,cadence");
        }
    }
}
