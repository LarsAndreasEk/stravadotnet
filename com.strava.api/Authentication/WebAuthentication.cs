using System;
using System.Diagnostics;

namespace com.strava.api.Authentication
{
    public class WebAuthentication : IAuthentication
    {
        public event EventHandler<TokenReceivedEventArgs> AccessTokenReceived;
        public event EventHandler<AuthCodeReceivedEventArgs> AuthCodeReceived;

        public string AccessToken { get; set; }
        public String AuthCode { get; set; }

        public void GetTokenAsync(String clientId, String clientSecret, Scope scope, int callbackPort = 1895)
        {
            LocalWebServer server = new LocalWebServer(String.Format("http://*:{0}/", callbackPort));
            server.ClientId = clientId;
            server.ClientSecret = clientSecret;

            server.AccessTokenReceived += delegate(object sender, TokenReceivedEventArgs args)
            {
                if (AccessTokenReceived != null)
                {
                    AccessTokenReceived(this, args);
                    AccessToken = args.Token;
                }
            };

            server.AuthCodeReceived += delegate(object sender, AuthCodeReceivedEventArgs args)
            {
                if (AuthCodeReceived != null)
                {
                    AuthCodeReceived(this, args);
                    AuthCode = args.AuthCode;
                }
            };

            server.Start();

            String url = "https://www.strava.com/oauth/authorize";
            String scopeLevel = String.Empty;

            switch (scope)
            {
                case Scope.Full:
                    scopeLevel = "view_private,write";
                    break;
                case Scope.Public:
                    scopeLevel = "public";
                    break;
                case Scope.ViewPrivate:
                    scopeLevel = "view_private";
                    break;
                case Scope.Write:
                    scopeLevel = "write";
                    break;
            }

            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(String.Format("{0}?client_id={1}&response_type=code&redirect_uri=http://localhost:{2}&scope={3}&approval_prompt=force", url, clientId, callbackPort, scopeLevel));
            process.Start();
        }
    }
}