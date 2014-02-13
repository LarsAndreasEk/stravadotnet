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
            Bike bike = Unmarshaller<Bike>.Unmarshal(_json);
            Assert.IsNotNull(bike);
        }

        [TestMethod]
        public void TestBikeUnmarshallingName()
        {
            Bike bike = Unmarshaller<Bike>.Unmarshal(_json);
            Assert.IsTrue(bike.Name.Equals("Canyon Roadlite AL 7.0"));
        }

        [TestMethod]
        public void TestBikeUnmarshallingBrand()
        {
            Bike bike = Unmarshaller<Bike>.Unmarshal(_json);
            Assert.IsTrue(bike.Brand.Equals("Canyon"));
        }

        [TestMethod]
        public void TestBikeUnmarshallingModel()
        {
            Bike bike = Unmarshaller<Bike>.Unmarshal(_json);
            Assert.IsTrue(bike.Model.Equals("Roadlite AL 7.0"));
        }

        [TestMethod]
        public void TestBikeUnmarshallingId()
        {
            Bike bike = Unmarshaller<Bike>.Unmarshal(_json);
            Assert.IsTrue(bike.Id.Equals("b814946"));
        }

        [TestMethod]
        public void TestBikeUnmarshallingPrimary()
        {
            Bike bike = Unmarshaller<Bike>.Unmarshal(_json);
            Assert.IsTrue(bike.IsPrimary);
        }

        [TestMethod]
        public void TestBikeUnmarshallingFrameType()
        {
            Bike bike = Unmarshaller<Bike>.Unmarshal(_json);
            Assert.IsTrue(bike.FrameType.Equals("3"));
        }

        [TestMethod]
        public void TestBikeUnmarshallingDescription()
        {
            Bike bike = Unmarshaller<Bike>.Unmarshal(_json);
            Assert.IsTrue(bike.Description.Equals(String.Empty));
        }
    }
}
