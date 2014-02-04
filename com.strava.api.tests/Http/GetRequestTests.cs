using System;
using com.strava.api.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Http
{
    [TestClass]
    public class GetRequestTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async void TestExecuteNull()
        {
            await WebRequest.SendGetAsync(null);
        }
    }
}
