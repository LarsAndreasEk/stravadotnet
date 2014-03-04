using System;
using com.strava.api.Common;
using com.strava.api.Gear;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class GearUnmarshalling
    {
        private readonly String _json = Resources.GearJson;

        [TestMethod]
        public void TestBikeUnmarshalling()
        {
            Gear.Gear bike = Unmarshaller<Gear.Gear>.Unmarshal(_json);
            Assert.IsNotNull(bike);
        }

        [TestMethod]
        public void TestBikeUnmarshallingName()
        {
            Gear.Gear bike = Unmarshaller<Gear.Gear>.Unmarshal(_json);
            Assert.IsTrue(bike.Name.Equals("Canyon Roadlite AL 7.0"));
        }

        [TestMethod]
        public void TestBikeUnmarshallingBrand()
        {
            Gear.Gear bike = Unmarshaller<Gear.Gear>.Unmarshal(_json);
            Assert.IsTrue(bike.Brand.Equals("Canyon"));
        }

        [TestMethod]
        public void TestBikeUnmarshallingModel()
        {
            Gear.Gear bike = Unmarshaller<Gear.Gear>.Unmarshal(_json);
            Assert.IsTrue(bike.Model.Equals("Roadlite AL 7.0"));
        }

        [TestMethod]
        public void TestBikeUnmarshallingId()
        {
            Gear.Gear bike = Unmarshaller<Gear.Gear>.Unmarshal(_json);
            Assert.IsTrue(bike.Id.Equals("b814946"));
        }

        [TestMethod]
        public void TestBikeUnmarshallingPrimary()
        {
            Gear.Gear bike = Unmarshaller<Gear.Gear>.Unmarshal(_json);
            Assert.IsTrue(bike.IsPrimary);
        }

        [TestMethod]
        public void TestBikeUnmarshallingFrameType()
        {
            Gear.Gear bike = Unmarshaller<Gear.Gear>.Unmarshal(_json);
            Assert.IsTrue(bike.FrameType == BikeType.Road);
        }

        [TestMethod]
        public void TestBikeUnmarshallingDescription()
        {
            Gear.Gear bike = Unmarshaller<Gear.Gear>.Unmarshal(_json);
            Assert.IsTrue(bike.Description.Equals(String.Empty));
        }
    }
}
