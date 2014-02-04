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
        private const String AthleteUrl = "https://www.strava.com/api/v3/athletes/";
        private readonly IAuthentication _authenticator;

        public AthleteService(IAuthentication authenticator)
        {
            if (authenticator == null)
            {
                throw new ArgumentException("The IAuthenticator object must not be null.");
            }

            _authenticator = authenticator;
        }


        public async Task<Athlete> GetCurrentAthleteAsync()
        {
            String getUrl = String.Format("{0}?access_token={1}", CurrentAthleteUrl, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Athlete>.Unmarshal(json);
        }

        public async Task<Athlete> GetAthleteAsync(String athleteId)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", AthleteUrl, athleteId, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Athlete>.Unmarshal(json);
        }

    }
}
