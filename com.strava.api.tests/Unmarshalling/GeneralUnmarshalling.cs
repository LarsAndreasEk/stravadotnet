using System;
using com.strava.api.Common;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class GeneralUnmarshalling
    {
        [TestMethod]
        public void TestUnmarshallingToPrivateField()
        {
            String json = Resources.PrivateJson;

            Test test = Unmarshaller<Test>.Unmarshal(json);
            Assert.IsTrue(test.ShowPrivate.Equals("Test"));
        }
    }

    public class Test
    {
        [JsonProperty("private")]
        private String Private { get; set; }

        [JsonProperty("public")]
        public String Public { get; set; }

        public String ShowPrivate
        {
            get
            {
                return Private;
            }
        }
    }
}
