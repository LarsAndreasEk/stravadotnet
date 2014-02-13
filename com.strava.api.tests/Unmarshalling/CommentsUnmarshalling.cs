using System;
using System.Collections.Generic;
using com.strava.api.Activities;
using com.strava.api.Common;
using com.strava.api.tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.strava.api.tests.Unmarshalling
{
    [TestClass]
    public class CommentsUnmarshalling
    {
        private String _json = Resources.CommentsJson;

        [TestMethod]
        public void TestCommentsUnmarshalling()
        {
            List<Comment> comments = Unmarshaller<List<Comment>>.Unmarshal(_json);
            Assert.IsNotNull(comments);
        }

        [TestMethod]
        public void TestCommentsCount()
        {
            List<Comment> comments = Unmarshaller<List<Comment>>.Unmarshal(_json);
            Assert.IsTrue(comments.Count == 3);
        }
    }
}
