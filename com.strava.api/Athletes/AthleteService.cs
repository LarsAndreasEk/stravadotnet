using System;
using System.Threading.Tasks;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Http;

namespace com.strava.api.Athletes
{
    public class AthleteService
    {
        private const String CurrentAthleteUrl = "https://www.strava.com/api/v3/athlete";
        private readonly IAuthentication _authenticator;

        public AthleteService(IAuthentication authenticator)
        {
            if (authenticator == null)
            {
                throw new ArgumentException("The IAuthenticator object must not be null.");
            }

            _authenticator = authenticator;
        }


        public async Task<Athlete> GetActivityAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", CurrentAthleteUrl, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Athlete>.Unmarshal(json);
        }

    }
}
