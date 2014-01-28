using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.strava.api.Authentication;

namespace com.strava.api.Activities
{
    public class ActivityService
    {
        private IAuthentication _authenticator;

        public ActivityService(IAuthentication authenticator)
        {
            _authenticator = authenticator;
        }

        public ActivityResponse List()
        {


            return new ActivityResponse();
        }
    }
}
