using System;
using com.strava.api.Activities;
using com.strava.api.Common;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class PhotoUnmarshalling
    {
        private String _json = Resources.PhotoJson;

        [TestMethod]
        public void TestPhotoUnmarshalling()
        {
            Photo photo = Unmarshaller<Photo>.Unmarshal(_json);
            Assert.IsNotNull(photo);
        }
    }
}
