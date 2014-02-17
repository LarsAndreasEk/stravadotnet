using System;
using com.strava.api.Clubs;
using com.strava.api.Common;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class ClubUnmarshalling
    {
        private String _json = Resources.ClubJson;

        [TestMethod]
        public void TestClubUnmarshalling()
        {
            Club club = Unmarshaller<Club>.Unmarshal(_json);
            Assert.IsNotNull(club);
        }

        [TestMethod]
        public void TestFirstEnumeration()
        {
            Club club = Unmarshaller<Club>.Unmarshal(_json);
            Assert.IsTrue(club.ClubType.Equals(ClubType.Company));
        }

        [TestMethod]
        public void TestSecondEnumeration()
        {
            Club club = Unmarshaller<Club>.Unmarshal(_json);
            Assert.IsTrue(club.SportType.Equals(SportType.Cycling));
        }
    }
}
